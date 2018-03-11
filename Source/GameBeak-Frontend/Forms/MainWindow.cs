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
using Core = GameBeak.Classes.Core;
using GameBeak = GameBeak.Classes;
using System.Threading;
using GameBeak.Forms;

namespace GameBeak
{
    public partial class MainWindow : Form
    {
        private Thread emulatorThread;

        private AssemblyView assemblyView;
        private MemoryView memoryView;
        private GraphicView graphicView;
        private PaletteEditor paletteEditor;

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
                emulatorThread = new Thread(global::GameBeak.Classes.GameBeak_Main.startEmulator);
                emulatorThread.Start();

                resumeToolStripMenuItem.Enabled = true;
                pauseToolStripMenuItem.Enabled = true;

            }
            else
            {
                MessageBox.Show(filePath);
            }
        }

        public void updateScreen()
        {
            SFML.Graphics.Texture texture = new SFML.Graphics.Texture(Core.beakWindow.screen);
            SFML.Graphics.Sprite sprite = new SFML.Graphics.Sprite(texture);
            sprite.Scale = new SFML.System.Vector2f(2, 2);
            drawCanvas.drawFrame(sprite);
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

            if(e.KeyCode == Keys.ShiftKey)
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

            if (e.KeyCode == Keys.ShiftKey)
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

        private void paletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (paletteEditor == null || paletteEditor.IsDisposed)
            {
                paletteEditor = new PaletteEditor();
                paletteEditor.Show();
            }
            else
            {
                paletteEditor.Show();
                paletteEditor.BringToFront();
            }
        }

        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core.paused = false;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core.paused = true;
        }
    }

}