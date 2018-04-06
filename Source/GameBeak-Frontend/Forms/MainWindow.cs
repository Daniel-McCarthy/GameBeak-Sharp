﻿using System;
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

            //Add drawing canvas to screen
            Controls.Add(drawCanvas);
            drawCanvas.Location = new Point(0, 27);
        }


        /*
         *  Load Rom File 
        */
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = (openFileDialog1.ShowDialog() == DialogResult.OK) ? openFileDialog1.FileName : "Error: No such file found.";

            if(File.Exists(filePath))
            {
                Core.beakMemory.memoryPointer = 0x0100;

                Core.beakMemory.loadRom(filePath, true);
                Core.beakMemory.romFilePath = filePath;

                Core.paused = true;

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