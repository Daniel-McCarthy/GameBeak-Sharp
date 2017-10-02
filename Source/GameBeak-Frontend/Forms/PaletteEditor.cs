using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GameBeak_Frontend.Forms
{
    public partial class PaletteEditor : Form
    {
        private List<Color> palettes = new List<Color>();
        private List<string> paletteNames = new List<string>();

        public PaletteEditor()
        {
            InitializeComponent();
        }


        private void setPreviewColor(PictureBox preview, Color previewColor)
        {
            preview.BackColor = previewColor;
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


    }
}
