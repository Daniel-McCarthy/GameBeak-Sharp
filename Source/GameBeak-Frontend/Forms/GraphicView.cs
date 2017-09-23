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

        public GraphicView()
        {
            InitializeComponent();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if(tileViewRadioButton.Checked)
            {
                drawTileView();
            }
            else
            {
                drawFullView();
            }
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

        private void drawFullView()
        {
            for (int i = 0; i < (256 * 256); i++)
            {
                int y = (i / 256);
                int x = (i - (256 * y));

                gb.Color pixel = Core.beakWindow.getBGPixel(x, y);
                fullScreen.SetPixel(x, y, Color.FromArgb(pixel.a, pixel.r, pixel.g, pixel.b));
            }

            pictureBox1.Image = fullScreen;
        }
    }
}
