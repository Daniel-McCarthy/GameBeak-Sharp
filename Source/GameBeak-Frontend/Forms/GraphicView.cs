using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core = GameBeak_Frontend.Classes.Core;

using gb = GameBeak_Frontend.Classes;

namespace GameBeak_Frontend.Forms
{
    public partial class GraphicView : Form
    {
        private Bitmap tileScreen = new Bitmap(160, 160);
        private Bitmap fullScreen = new Bitmap(256, 256);
        private Bitmap spritePreview = new Bitmap(8, 8);
        private bool canvasMode = true;

        private byte spritePage = 0;

        public GraphicView()
        {
            InitializeComponent();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void drawTileView()
        {
            ushort baseAddress = 0x8000;

            List<List<gb.Color>> tile = new List<List<gb.Color>>();

            for (int i = 0; i < 360; i++)
            {
                tile.Clear();

                ushort tileOffset = (ushort)(i * 16);

                ushort tileAddress = (ushort)(baseAddress + tileOffset);

                for (ushort j = 0; j < 16; j += 2)
                {
                    byte rowHalf1 = Core.beakMemory.readMemory((ushort)(tileAddress + j));
                    byte rowHalf2 = Core.beakMemory.readMemory((ushort)(tileAddress + j + 1));

                    List<gb.Color> row = new List<gb.Color>();

                    for (int k = 0; k < 8; k++)
                    {
                        row.Add(Core.beakGPU.returnColor((((rowHalf1 & 0x80) >> 7)) | ((rowHalf2 & 0x80) >> 6)));
                        rowHalf1 <<= 1;
                        rowHalf2 <<= 1;
                    }

                    tile.Add(row);
                }

                drawTile(i, tile);

            }

            pictureBox1.Image = tileScreen;
        }

        void drawTile(int tileNumber, List<List<gb.Color>> tile)
        {
            int y = tileNumber / 20;
            int x = tileNumber - (20 * y);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    gb.Color color = tile[0][j];
                    tileScreen.SetPixel((x * 8) + j, (y * 8) + i, Color.FromArgb(color.a, color.r, color.g, color.b));
                }

                tile.Remove(tile.First());
            }

        }

        void drawSpriteIcon(PictureBox pictureBox, byte tileNumber)
        {
            ushort baseAddress = 0x8000;

            List<List<gb.Color>> tile = new List<List<gb.Color>>();


            ushort tileOffset = (ushort)(tileNumber * 16);

            ushort tileAddress = (ushort)(baseAddress + tileOffset);

            for (ushort j = 0; j < 16; j += 2)
            {
                byte rowHalf1 = Core.beakMemory.readMemory((ushort)(tileAddress + j));
                byte rowHalf2 = Core.beakMemory.readMemory((ushort)(tileAddress + j + 1));

                List<gb.Color> row = new List<gb.Color>();

                for (int k = 0; k < 8; k++)
                {
                    row.Add(Core.beakGPU.returnColor((((rowHalf1 & 0x80) >> 7)) | ((rowHalf2 & 0x80) >> 6)));
                    rowHalf1 <<= 1;
                    rowHalf2 <<= 1;
                }

                tile.Add(row);
            }

       
            //Draw Tile to Picture Box
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    gb.Color color = tile[0][j];
                    spritePreview.SetPixel(j, i, Color.FromArgb(color.a, color.r, color.g, color.b));
                }

                tile.Remove(tile.First());
            }



            pictureBox.Image = new Bitmap(spritePreview, new Size (spritePreview.Width * 4, spritePreview.Height * 4));
        }

        private void drawFullView()
        {
            for (int i = 0; i < (256 * 256); i++)
            {
                int y = (i / 256);
                int x = (i - (256 * y));

                gb.Color pixel = Core.beakWindow.getBGPixel((byte)x, (byte)y);
                fullScreen.SetPixel(x, y, Color.FromArgb(pixel.a, pixel.r, pixel.g, pixel.b));
            }

            pictureBox1.Image = fullScreen;
        }

        private void updateSpriteView()
        {
            byte pageShift = (byte)(spritePage * 16);

            //Sprite 1
            byte shift = (byte)(pageShift + 4);

            byte spriteY = Core.beakMemory.readMemory((ushort)(0xFE00 + shift));
            byte spriteX = Core.beakMemory.readMemory((ushort)(0xFE01 + shift));
            byte tileNumber = Core.beakMemory.readMemory((ushort)(0xFE02 + shift));

            sprite1XPosValueLabel.Text = spriteX.ToString("X2");
            sprite1YPosValueLabel.Text = spriteY.ToString("X2");
            sprite1TileNumberValueLabel.Text = tileNumber.ToString("X2");

            sprite1OAMAddressValueLabel.Text = 0xFE00.ToString("X4");

            drawSpriteIcon(sprite1PictureBox, tileNumber);

            //Sprite 2
            shift = (byte)(pageShift + 8);

            spriteY = Core.beakMemory.readMemory((ushort)(0xFE00 + shift));
            spriteX = Core.beakMemory.readMemory((ushort)(0xFE01 + shift));
            tileNumber = Core.beakMemory.readMemory((ushort)(0xFE02 + shift));

            sprite2XPosValueLabel.Text = spriteX.ToString("X2");
            sprite2YPosValueLabel.Text = spriteY.ToString("X2");
            sprite2TileNumberValueLabel.Text = tileNumber.ToString("X2");

            sprite2OAMAddressValueLabel.Text = 0xFE04.ToString("X4");

            drawSpriteIcon(sprite2PictureBox, tileNumber);


            //Sprite 3
            shift = (byte)(pageShift + 12);

            spriteY = Core.beakMemory.readMemory((ushort)(0xFE00 + shift));
            spriteX = Core.beakMemory.readMemory((ushort)(0xFE01 + shift));
            tileNumber = Core.beakMemory.readMemory((ushort)(0xFE02 + shift));

            sprite3XPosValueLabel.Text = spriteX.ToString("X2");
            sprite3YPosValueLabel.Text = spriteY.ToString("X2");
            sprite3TileNumberValueLabel.Text = tileNumber.ToString("X2");

            sprite1OAMAddressValueLabel.Text = 0xFE08.ToString("X4");

            drawSpriteIcon(sprite3PictureBox, tileNumber);

            //Sprite 4
            shift = (byte)(pageShift + 16);

            spriteY = Core.beakMemory.readMemory((ushort)(0xFE00 + shift));
            spriteX = Core.beakMemory.readMemory((ushort)(0xFE01 + shift));
            tileNumber = Core.beakMemory.readMemory((ushort)(0xFE02 + shift));

            sprite4XPosValueLabel.Text = spriteX.ToString("X2");
            sprite4YPosValueLabel.Text = spriteY.ToString("X2");
            sprite4TileNumberValueLabel.Text = tileNumber.ToString("X2");

            sprite1OAMAddressValueLabel.Text = 0xFE10.ToString("X4");

            drawSpriteIcon(sprite4PictureBox, tileNumber);
        }

        private void updateRadioButtons()
        {
            bool tileViewChecked = tileViewRadioButton.Checked;
            bool spriteViewChecked = spriteViewRadioButton.Checked;
            bool fullViewChecked = fullViewRadioButton.Checked;

            if(tileViewChecked ||  fullViewChecked)
            {
                canvasMode = true;
            }
            else
            {
                canvasMode = false;
            }

            refresh();
        }

        private void refresh()
        {
            if (canvasMode)
            {
                spriteViewGroupBox.Visible = false;
                spriteViewGroupBox.Enabled = false;

                pageLeftButton.Visible = pageLeftButton.Enabled = false;
                pageRightButton.Visible = pageRightButton.Enabled = false;

                pictureBox1.Visible = true;

                if (tileViewRadioButton.Checked)
                {
                    drawTileView();
                }
                else
                {
                    drawFullView();
                }
            }
            else
            {
                updateSpriteView();
                spriteViewGroupBox.Visible = true;
                spriteViewGroupBox.Enabled = true;
                pageLeftButton.Visible = pageLeftButton.Enabled = true;
                pageRightButton.Visible = pageRightButton.Enabled = true;
                pictureBox1.Visible = false;
            }
        }

        private void tileViewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            updateRadioButtons();
        }

        private void spriteViewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            updateRadioButtons();
        }

        private void fullViewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            updateRadioButtons();
        }

        private void pageLeftButton_Click(object sender, EventArgs e)
        {
            if (spritePage > 0)
            {
                spritePage--;
                refresh();
            }
        }

        private void pageRightButton_Click(object sender, EventArgs e)
        {
            if(spritePage < 16)
            {
                spritePage++;
                refresh();
            }
        }
    }
}
