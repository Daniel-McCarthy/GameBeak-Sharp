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
        private Bitmap graphicScreen = new Bitmap(160, 160);

        public GraphicView()
        {
            InitializeComponent();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if(tileViewRadioButton.Enabled)
            {
                drawTileView();
            }
            else
            {
                drawFullView();
            }
        }

    }
}
