using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Core = GameBeak.Classes.Core;

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

        Classes.Canvas drawCanvas = new Classes.Canvas();
        public SFML.Graphics.Sprite frame;

        public MainWindow()
        {
            InitializeComponent();

            // Add drawing canvas to screen
            drawCanvas.Size = new Size(320, 288);

            // Move canvas below menu strip with small padding
            Point canvasLocation = new Point(0, menuStrip1.Location.Y + menuStrip1.Height + 5);
            drawCanvas.Location = canvasLocation;
            Controls.Add(drawCanvas);

            // Set the window size to match the space required for the menu strip and canvas
            Size windowSize = new Size(320, canvasLocation.Y + 288);
            this.Size = windowSize;
            this.MaximumSize = windowSize;
            this.MinimumSize = windowSize;
        }


        /*
         *  Load Rom File 
        */
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool alreadyEmulating = Core.run;
            Core.paused = true;
            string filePath = (openFileDialog1.ShowDialog() == DialogResult.OK) ? openFileDialog1.FileName : "Error: No such file found.";

            if(File.Exists(filePath))
            { 
                if (alreadyEmulating)
                {
                    Classes.GameBeak_Main.resetCore();
                }

                Core.beakMemory.loadRom(filePath, true);
                Core.rom.romFilePath = filePath;

                Core.rom.readRomHeader();

                Core.GBCMode = (Core.rom.isGBCRom() && !Core.ForceDMGMode);

                if(Core.GBCMode)
                {
                    Core.beakMemory.initializeGameBoyColorValues();
                }
                else
                {
                    Core.beakMemory.initializeGameBoyValues();
                }

                Core.run = true;
                Core.paused = false;

                if (emulatorThread == null)
                {
                    emulatorThread = new Thread(global::GameBeak.Classes.GameBeak_Main.startEmulator);
                    emulatorThread.Start();
                }

                resumeToolStripMenuItem.Enabled = true;
                pauseToolStripMenuItem.Enabled = true;

            }
            else
            {
                MessageBox.Show(filePath);

                if (Core.rom != null)
                {
                    Core.rom.romFilePath = "";
                }
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

            //Tell the thread to stop when it finishes it's current loop
            Core.run = false;

            int loops = 0;
            while(emulatorThread != null && emulatorThread.IsAlive)
            {
                //Attempt to wait for the thread to be ready to be stopped.
                if(emulatorThread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    Thread.Sleep(800);
                    emulatorThread.Abort();
                }

                //If the thread is not exiting after several attempts to check, just end it.
                if (loops++ > 20)
                {
                    emulatorThread.Abort();
                }

                //Wait before trying again
                Thread.Sleep(100);

            }
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

        private void forceDMGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core.ForceDMGMode = true;
            forceDMGToolStripMenuItem.Checked = true;
            automaticSelectionToolStripMenuItem.Checked = false;
        }

        private void automaticSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core.ForceDMGMode = false;
            forceDMGToolStripMenuItem.Checked = false;
            automaticSelectionToolStripMenuItem.Checked = true;
        }
    }
}