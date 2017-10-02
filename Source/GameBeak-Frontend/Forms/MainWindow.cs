using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
//using SFML;
//using SFML.Graphics;
//using SFML.Window;
using System.Windows;

//using sf = SFML.Graphics;
using Core = GameBeak_Frontend.Classes.Core;
using GameBeak = GameBeak_Frontend.Classes;
using System.Threading;
using GameBeak_Frontend.Forms;

namespace GameBeak_Frontend
{
    public partial class MainWindow : Form
    {
        private Thread emulatorThread;

        private AssemblyView assemblyView;
        private MemoryView memoryView;
        private GraphicView graphicView;

        public MainWindow()
        {
            InitializeComponent();
        }


        /*
         *  Load Rom File 
        */
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = (openFileDialog1.ShowDialog() == DialogResult.OK) ? openFileDialog1.FileName : "Error: No such file found.";

            if(File.Exists(filePath))
            {
                byte[] rom = File.ReadAllBytes(filePath);

                //NativeMethods.setRom(rom, rom.Length);
                Core.beakMemory.memoryPointer = 0x0100;
                Core.beakMemory.loadRom(rom);

                //NativeMethods.setPauseState(true);
                Core.paused = true;

                //emulatorThread = new Thread(NativeMethods.initiateEmulator);
                emulatorThread = new Thread(GameBeak_Frontend.Classes.GameBeak_Main.startEmulator);
                emulatorThread.Start();

            }
            else
            {
                MessageBox.Show(filePath);
            }
        }

        public void updateScreen()
        {

            //Convert SFML Image to Bitmap
            Tuple<int, int> screenSize = Core.beakWindow.screen.getSize();

            Bitmap bmp = new Bitmap(screenSize.Item1, screenSize.Item2);

            for (int x = 0; x < screenSize.Item1; x++)
            {
                for (int y = 0; y < screenSize.Item2; y++)
                {
                    Color pixel = Color.FromArgb((int)Core.beakWindow.screen.getPixel(x, y).getARGBInt());
                    bmp.SetPixel(x, y, pixel);
                }
            }

            pictureBox1.Image = bmp;
                
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

            if(emulatorThread != null)
                emulatorThread.Abort();
        }

        private void assemblyViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (assemblyView == null || assemblyView.IsDisposed)
            {
                assemblyView = new AssemblyView();
                assemblyView.Show();
            }
            else
            {
                assemblyView.Show();
                assemblyView.BringToFront();
            }
        }

        private void memoryViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (memoryView == null || memoryView.IsDisposed)
            {
                memoryView = new MemoryView();
                memoryView.Show();
            }
            else
            {
                memoryView.Show();
                memoryView.BringToFront();
            }
        }

        /*
            bool keyUp = false;
            bool keyDown = false;
            bool keyLeft = false;
            bool keyRight = false;
            bool keyStart = false;
            bool keySelect = false;
            bool keyA = false;
            bool keyB = false;
         */
        private void MainWindow_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                //this.BackColor = System.Drawing.Color.Aqua;
                Core.beakInput.setKeyInput(0, true);
            }

            if(e.KeyCode == Keys.Down)
            {
                Core.beakInput.setKeyInput(1, true);
            }

            if(e.KeyCode == Keys.Left)
            {
                Core.beakInput.setKeyInput(2, true);
            }

            if(e.KeyCode == Keys.Right)
            {
                Core.beakInput.setKeyInput(3, true);
            }

            if(e.KeyCode == Keys.Enter)
            {
                Core.beakInput.setKeyInput(4, true);
            }

            if(e.KeyCode == Keys.RShiftKey)
            {
                Core.beakInput.setKeyInput(5, true);
            }

            if(e.KeyCode == Keys.Z)
            {
                Core.beakInput.setKeyInput(6, true);
            }

            if(e.KeyCode == Keys.X)
            {
                Core.beakInput.setKeyInput(7, true);
            }
        }

        private void MainWindow_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Up)
            {
                //this.BackColor = System.Drawing.Color.Aqua;
                Core.beakInput.setKeyInput(0, false);
            }

            if (e.KeyCode == Keys.Down)
            {
                Core.beakInput.setKeyInput(1, false);
            }

            if (e.KeyCode == Keys.Left)
            {
                Core.beakInput.setKeyInput(2, false);
            }

            if (e.KeyCode == Keys.Right)
            {
                Core.beakInput.setKeyInput(3, false);
            }

            if (e.KeyCode == Keys.Enter)
            {
                Core.beakInput.setKeyInput(4, false);
            }

            if (e.KeyCode == Keys.RShiftKey)
            {
                Core.beakInput.setKeyInput(5, false);
            }

            if (e.KeyCode == Keys.Z)
            {
                Core.beakInput.setKeyInput(6, false);
            }

            if (e.KeyCode == Keys.X)
            {
                Core.beakInput.setKeyInput(7, false);
            }
            
        }

        //Open Graphic View Window
        private void graphicViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graphicView == null || graphicView.IsDisposed)
            {
                graphicView = new GraphicView();
                graphicView.Show();
            }
            else
            {
                graphicView.Show();
                graphicView.BringToFront();
            }
        }
    }

    }
}