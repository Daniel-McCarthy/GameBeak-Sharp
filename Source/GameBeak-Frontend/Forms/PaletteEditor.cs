using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using SFML.Graphics;

using Core = GameBeak.Classes.Core;
using GameBeak = GameBeak.Classes;

namespace GameBeak.Forms
{
    public partial class PaletteEditor : Form
    {
        private List<Color> palettes = new List<Color>();
        private List<string> paletteNames = new List<string>();

        public PaletteEditor()
        {
            InitializeComponent();
        }

        private void setPalette()
        {
            int index = paletteNameListBox.SelectedIndex;

            if (index >= 0)
            {

                Core.beakGPU.gameBeakPalette[0] = convertColor(palettes[(index * 12) + 0]);
                Core.beakGPU.gameBeakPalette[1] = convertColor(palettes[(index * 12) + 1]);
                Core.beakGPU.gameBeakPalette[2] = convertColor(palettes[(index * 12) + 2]);
                Core.beakGPU.gameBeakPalette[3] = convertColor(palettes[(index * 12) + 3]);

                Core.beakGPU.gameBeakPalette[4] = convertColor(palettes[(index * 12) + 4]);
                Core.beakGPU.gameBeakPalette[5] = convertColor(palettes[(index * 12) + 5]);
                Core.beakGPU.gameBeakPalette[6] = convertColor(palettes[(index * 12) + 6]);
                Core.beakGPU.gameBeakPalette[7] = convertColor(palettes[(index * 12) + 7]);

                Core.beakGPU.gameBeakPalette[8] = convertColor(palettes[(index * 12) + 8]);
                Core.beakGPU.gameBeakPalette[9] = convertColor(palettes[(index * 12) + 9]);
                Core.beakGPU.gameBeakPalette[10] = convertColor(palettes[(index * 12) + 10]);
                Core.beakGPU.gameBeakPalette[11] = convertColor(palettes[(index * 12) + 11]);
            }

        }

        private Color convertColor(Color color)
        {
            return new Color(color.R, color.G, color.B, color.A);
        }

        //Ok Button / Set Selected Palette and Close
        private void okButton_Click(object sender, EventArgs e)
        {
            setPalette();
            this.Close();
        }

        //Cancel Button / Close Window
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaletteEditor_Load(object sender, EventArgs e)
        {
            FileStream palettesFile = openCreatePalettesXML();
            loadPalettesFromXML(palettesFile);

            for(int i = 0; i < paletteNames.Count; i++)
            {
                paletteNameListBox.Items.Add(paletteNames[i]);
            }

            //Set first palette to preview
            setPalettePreviews(0);

            paletteNameListBox.SelectedIndex = 0;
        }

        //Set Color of Preview Box
        private void setPreviewColor(PictureBox preview, Color previewColor)
        {
            preview.BackColor = System.Drawing.Color.FromArgb(previewColor.A, previewColor.R, previewColor.G, previewColor.B);
        }

        public void loadPalettesFromXML(FileStream inputFile)
        {
            string line;
            List<byte> colorValues = new List<byte>();

            StreamReader fileReader = new StreamReader(inputFile);

            while (!fileReader.EndOfStream)
            {
                line = fileReader.ReadLine();

                if(line.Contains("<name>"))
                {
                    int first = line.IndexOf('>') + 1;
                    int last = line.LastIndexOf('<');

                    paletteNames.Add(line.Substring(first, last - first));
                }

                bool test1 = (line.Contains("<bgp>")) && (line.Contains("</bgp>"));
                bool test2 = (line.Contains("<0bp0>")) && (line.Contains("</0bp0>"));
                bool test3 = (line.Contains("<0bp1>")) && (line.Contains("</0bp1>"));

                if (test1 || test2 || test3)
                {
                    int first = line.IndexOf('>') + 1;
                    int last = line.LastIndexOf('<');

                    line = line.Substring(first, last - first);

                    for (int i = 0; i < 4; i++)
                    {
                        byte r = byte.Parse(line.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                        byte g = byte.Parse(line.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                        byte b = byte.Parse(line.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

                        colorValues.Add(r);
                        colorValues.Add(g);
                        colorValues.Add(b);

                        if (line.Length > 8)
                        {
                            line = line.Substring(9, line.Length - 9);
                        }
                    }

                }
            }
            if ((colorValues.Count / 36) > 0)
            {
                int paletteOffset = 0;
                int colorOffset = 0;

                while (colorValues.Count >= (4 * 3))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        byte r = colorValues.First();
                        colorValues.RemoveAt(0);
                        byte g = colorValues.First();
                        colorValues.RemoveAt(0);
                        byte b = colorValues.First();
                        colorValues.RemoveAt(0);

                        Color color = new Color(r, g, b, 255);


                        palettes.Add(color);

                        if (colorOffset >= 3)
                        {
                            colorOffset = 0;
                        }
                        else
                        {
                            colorOffset++;
                        }
                    }

                    paletteOffset++;
                }
            }

            fileReader.Close();
            inputFile.Close();
        }

        public FileStream openCreatePalettesXML()
        {
            //open XML palette file
            string path = AppDomain.CurrentDomain.BaseDirectory;//System.Reflection.Assembly.GetEntryAssembly().Location;
            path = Path.Combine(path, "palettes.xml");

            if (File.Exists(path))
            {
                FileStream palettesFile = File.Open(path, FileMode.Open);
                return palettesFile;
            }
            else
            {
                StreamWriter palettesWriter = new StreamWriter(path);

                palettesWriter.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                palettesWriter.WriteLine("<colorschemes>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>BlackWhite</name>");
                palettesWriter.WriteLine("\t\t<bgp>FFFFFFFF|B9B9B9FF|696969FF|000000FF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>FFFFFFFF|B9B9B9FF|696969FF|000000FF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>FFFFFFFF|B9B9B9FF|696969FF|000000FF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>Green</name>");
                palettesWriter.WriteLine("\t\t<bgp>E0FFEBFF|88D058FF|34B73CFF|084703FF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>E0FFEBFF|88D058FF|34B73CFF|084703FF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>E0FFEBFF|88D058FF|34B73CFF|084703FF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>Pink</name>");
                palettesWriter.WriteLine("\t\t<bgp>FFF1FEFF|FFD6F5FF|FF83D9FF|48183BFF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>FFF1FEFF|FFD6F5FF|FF83D9FF|48183BFF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>FFF1FEFF|FFD6F5FF|FF83D9FF|48183BFF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>PinkAlt</name>");
                palettesWriter.WriteLine("\t\t<bgp>FFF0F5FF|FFBADEFF|FF74D9FF|520528FF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>FFF0F5FF|FFBADEFF|FF74D9FF|520528FF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>FFF0F5FF|FFBADEFF|FF74D9FF|520528FF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>Ultra-Pink</name>");
                palettesWriter.WriteLine("\t\t<bgp>52263EFF|FE04E8FF|CCE20AFF|AA7C94FF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>FE9EB6FF|52263EFF|E69EB6FF|AA7C94FF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>FE9EB6FF|52263EFF|E69EB6FF|AA7C94FF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>GrapeCherry</name>");
                palettesWriter.WriteLine("\t\t<bgp>FFE3FEFF|CBA0BAFF|975076FF|5A0033FF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>FFE3FEFF|CBA0BAFF|975076FF|5A0033FF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>FFE3FEFF|CBA0BAFF|975076FF|5A0033FF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>MintPink</name>");
                palettesWriter.WriteLine("\t\t<bgp>FFA5CEFF|19C7F0FF|33EF12FF|511733FF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>FFA5CEFF|19C7F0FF|33EF12FF|511733FF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>FFA5CEFF|19C7F0FF|33EF12FF|511733FF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>KiGB</name>");
                palettesWriter.WriteLine("\t\t<bgp>9CB916FF|8CAA14FF|306430FF|103F10FF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>9CB916FF|8CAA14FF|306430FF|103F10FF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>9CB916FF|8CAA14FF|306430FF|103F10FF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>BGB</name>");
                palettesWriter.WriteLine("\t\t<bgp>E0F8D0FF|88C070FF|346856FF|081820FF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>E0F8D0FF|88C070FF|346856FF|081820FF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>E0F8D0FF|88C070FF|346856FF|081820FF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>NO$GMB</name>");
                palettesWriter.WriteLine("\t\t<bgp>FCE88CFF|DCB45CFF|987C3CFF|4C3C1CFF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>FCE88CFF|DCB45CFF|987C3CFF|4C3C1CFF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>FCE88CFF|DCB45CFF|987C3CFF|4C3C1CFF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>PLAYGUY</name>");
                palettesWriter.WriteLine("\t\t<bgp>FFEEACFF|ACA473FF|5A5239FF|000000FF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>FFEEACFF|ACA473FF|5A5239FF|000000FF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>FFEEACFF|ACA473FF|5A5239FF|000000FF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>DREAMGBC</name>");
                palettesWriter.WriteLine("\t\t<bgp>FFFFFFFF|00B2B5FF|00868CFF|000000FF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>FFFFFFFF|00B2B5FF|00868CFF|000000FF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>FFFFFFFF|00B2B5FF|00868CFF|000000FF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>HEBOWIN</name>");
                palettesWriter.WriteLine("\t\t<bgp>FFFFFFFF|7FCC7FFF|3399B2FF|000000FF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>FFFFFFFF|FFCCCCFF|7F3333FF|000000FF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>FFFFFFFF|7FCC7FFF|3399B2FF|000000FF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>FPGABOY</name>");
                palettesWriter.WriteLine("\t\t<bgp>BFB9FDFF|6E58D7FF|28196BFF|000000FF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>BFB9FDFF|6E58D7FF|28196BFF|000000FF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>BFB9FDFF|6E58D7FF|28196BFF|000000FF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t<scheme>");
                palettesWriter.WriteLine("\t\t<name>GBC UP A</name>");
                palettesWriter.WriteLine("\t\t<bgp>FFFFFFFF|FFCCCCFF|7F3333FF|000000FF</bgp>");
                palettesWriter.WriteLine("\t\t<0bp0>FFFFFFFF|CCFFCCFF|337F33FF|000000FF</0bp0>");
                palettesWriter.WriteLine("\t\t<0bp1>FFFFFFFF|FFCCCCFF|7F3333FF|000000FF</0bp1>");
                palettesWriter.WriteLine("\t</scheme>\n");

                palettesWriter.WriteLine("\t</colorschemes>");

                palettesWriter.Close();

                FileStream palettesFile = File.Open(path, FileMode.Open);
                return palettesFile;
            }


        }

        private void paletteNameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPalettePreviews(paletteNameListBox.SelectedIndex);
        }

        private void setPalettePreviews(int index)
        {
            if (index > -1)
            {
                setPreviewColor(bgColorPreview1, palettes[(index * 12) + 0]);
                setPreviewColor(bgColorPreview2, palettes[(index * 12) + 1]);
                setPreviewColor(bgColorPreview3, palettes[(index * 12) + 2]);
                setPreviewColor(bgColorPreview4, palettes[(index * 12) + 3]);

                setPreviewColor(bp0ColorPreview1, palettes[(index * 12) + 4]);
                setPreviewColor(bp0ColorPreview2, palettes[(index * 12) + 5]);
                setPreviewColor(bp0ColorPreview3, palettes[(index * 12) + 6]);
                setPreviewColor(bp0ColorPreview4, palettes[(index * 12) + 7]);

                setPreviewColor(bp1ColorPreview1, palettes[(index * 12) + 8]);
                setPreviewColor(bp1ColorPreview2, palettes[(index * 12) + 9]);
                setPreviewColor(bp1ColorPreview3, palettes[(index * 12) + 10]);
                setPreviewColor(bp1ColorPreview4, palettes[(index * 12) + 11]);
            }
            else
            {
                setPreviewColor(bgColorPreview1, Color.White);
                setPreviewColor(bgColorPreview2, Color.White);
                setPreviewColor(bgColorPreview3, Color.White);
                setPreviewColor(bgColorPreview4, Color.White);

                setPreviewColor(bp0ColorPreview1, Color.White);
                setPreviewColor(bp0ColorPreview2, Color.White);
                setPreviewColor(bp0ColorPreview3, Color.White);
                setPreviewColor(bp0ColorPreview4, Color.White);

                setPreviewColor(bp1ColorPreview1, Color.White);
                setPreviewColor(bp1ColorPreview2, Color.White);
                setPreviewColor(bp1ColorPreview3, Color.White);
                setPreviewColor(bp1ColorPreview4, Color.White);
            }
        }

        //Select Palette
        private void paletteNameListBox_DoubleClick(object sender, EventArgs e)
        {
            setPalette();
        }


        //Set Palette Color Dialogues
        private void bgColorPreview1_DoubleClick(object sender, EventArgs e)
        {
            setPaletteColorDialogue(bgColorPreview1, 0);
        }

        private void bgColorPreview2_DoubleClick(object sender, EventArgs e)
        {
            setPaletteColorDialogue(bgColorPreview2, 1);
        }

        private void bgColorPreview3_DoubleClick(object sender, EventArgs e)
        {
            setPaletteColorDialogue(bgColorPreview3, 2);
        }

        private void bgColorPreview4_DoubleClick(object sender, EventArgs e)
        {
            setPaletteColorDialogue(bgColorPreview4, 3);
        }

        private void bp0ColorPreview1_DoubleClick(object sender, EventArgs e)
        {
            setPaletteColorDialogue(bp0ColorPreview1, 4);
        }

        private void bp0ColorPreview2_DoubleClick(object sender, EventArgs e)
        {
            setPaletteColorDialogue(bp0ColorPreview2, 5);
        }

        private void bp0ColorPreview3_DoubleClick(object sender, EventArgs e)
        {
            setPaletteColorDialogue(bp0ColorPreview3, 6);
        }

        private void bp0ColorPreview4_DoubleClick(object sender, EventArgs e)
        {
            setPaletteColorDialogue(bp0ColorPreview4, 7);
        }

        private void bp1ColorPreview1_DoubleClick(object sender, EventArgs e)
        {
            setPaletteColorDialogue(bp1ColorPreview1, 8);
        }

        private void bp1ColorPreview2_DoubleClick(object sender, EventArgs e)
        {
            setPaletteColorDialogue(bp1ColorPreview2, 9);
        }

        private void bp1ColorPreview3_DoubleClick(object sender, EventArgs e)
        {
            setPaletteColorDialogue(bp1ColorPreview3, 10);
        }

        private void bp1ColorPreview4_DoubleClick(object sender, EventArgs e)
        {
            setPaletteColorDialogue(bp1ColorPreview4, 11);
        }

        private void setPaletteColorDialogue(PictureBox box, int previewIndex)
        {
            colorDialog1.ShowDialog();

            System.Drawing.Color selectedColor = colorDialog1.Color;

            //Set Preview Color
            box.BackColor = selectedColor;

            //Set Palette Color
            int index = paletteNameListBox.SelectedIndex;
            palettes[(index * 12) + previewIndex] = new Color(selectedColor.R, selectedColor.G, selectedColor.B);

        }

        //Create New Color Palette
        private void newButton_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Enter Palette Name:", "GameBeak  - Palette", "", 10, 10);

            paletteNameListBox.Items.Add(name);

            for (int i = 0; i < 12; i++)
            {
                palettes.Add(Color.White);
            }

            paletteNameListBox.SelectedIndex = paletteNameListBox.Items.Count - 1;

            setPalettePreviews(paletteNameListBox.SelectedIndex);
        }

        //Remove Palette From List
        private void deleteButton_Click(object sender, EventArgs e)
        {
            int paletteLocation = paletteNameListBox.SelectedIndex;

            palettes.RemoveRange(paletteLocation * 12, 12);

            paletteNameListBox.Items.RemoveAt(paletteLocation);

            if (paletteNameListBox.Items.Count > 0)
            {
                if (paletteLocation <= 0)
                {
                    paletteNameListBox.SelectedIndex = 0;
                }
                else
                {

                    paletteNameListBox.SelectedIndex = paletteLocation - 1;
                }
            }

        }

        //Save Current Palettes to Palettes File
        private void saveButton_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = Path.Combine(path, "palettes.xml");

            //If no copy, make one
            bool palettesFileExists = File.Exists(path);
            bool palettesFileCopyExists = File.Exists(path + ".copy");

            if (palettesFileExists && !palettesFileCopyExists)
            {
                File.Copy(path, path + ".copy");
            }

            //Delete Original Palettes File
            if(palettesFileExists)
            {
                File.Delete(path);
            }

            StreamWriter fileWriter = File.CreateText(path);

            writeFile();

            void writeFile()
            {
                writeFileStart();
                writePalettes();
                writeFileEnd();
            }

            void writeFileStart()
            {
                fileWriter.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                fileWriter.WriteLine("<colorschemes>\n");
            }

            void writeFileEnd()
            {
                fileWriter.WriteLine("\t</colorschemes>");
            }

            void writePalettes()
            {
                int colorOffset = 0;

                for (int i = 0; i < paletteNameListBox.Items.Count; i++)
                {
                    if ((palettes.Count - colorOffset) >= 12)
                    {

                        fileWriter.WriteLine("\t<scheme>");
                        writePaletteName((string)paletteNameListBox.Items[i]);

                        writeSchemeLine(colorOffset, 0, "bgp");
                        writeSchemeLine(colorOffset, 4, "0bp0");
                        writeSchemeLine(colorOffset, 8, "0bp1");

                        fileWriter.WriteLine("\t</scheme>\n");
                    }

                    colorOffset += 12;
                }
            }

            void writePaletteName(string name)
            {
                fileWriter.WriteLine("\t\t<name>" + name + "</name>");
            }

            void writeSchemeLine(int schemeIndex, int offset, string paletteType)
            {
                string color1 = palettes[schemeIndex + offset + 0].ToInteger().ToString("X8");
                string color2 = palettes[schemeIndex + offset + 1].ToInteger().ToString("X8");
                string color3 = palettes[schemeIndex + offset + 2].ToInteger().ToString("X8");
                string color4 = palettes[schemeIndex + offset + 3].ToInteger().ToString("X8");

                fileWriter.WriteLine("\t\t<" + paletteType  + ">" + color1 + '|' + color2 + '|' + color3 + '|' + color4 + "</" + paletteType  + ">");
            }

            fileWriter.Close();
        }
    }
}
