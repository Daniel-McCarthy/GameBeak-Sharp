using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SFML.Graphics;

namespace GameBeak.Classes
{
    class GameWindow
    {

        public Image screen = new Image(160, 144);

        private Color[] bgPixels = new Color[256 * 256];
        private Color[] windowPixels = new Color[256 * 256];
        private Color[] spritePixels = new Color[256 * 256];
        private Color[] tileDebugPixels = new Color[256 * 256];
        private byte[] scrollXValues = new byte[256];
        public int gpuMode = 1; //BGB defaults this to 1, V-Blank. This should be true.
        private bool poweringOn = true;

        private Stopwatch screenUpdateWatch = new Stopwatch();

        public GameWindow()
        {
            Color pink = new Color(Core.beakGPU.returnColor(0, 0));
            //This creates a new Color from existing values so that the original color is not modified

            for (int i = 0; i < (256 * 256); i++)
            {
                bgPixels[i] = new Color(pink);
                windowPixels[i] = new Color(pink);
                spritePixels[i] = new Color(pink);
            }
        }


        public GameWindow(string title, int width, int height)
        {
            Color pink = Core.beakGPU.returnColor(0, 0);

            for (int i = 0; i < (256 * 256); i++)
            {
                bgPixels[i] = new Color(pink);
                windowPixels[i] = new Color(pink);
                spritePixels[i] = new Color(pink);
            }
        }

        public void resetScreens()
        {
            Color pink = Core.beakGPU.returnColor(0, 0);

            for (int i = 0; i < (256 * 256); i++)
            {
                bgPixels[i] = new Color(pink);
                windowPixels[i] = new Color(pink);
                spritePixels[i] = new Color(pink);
            }
        }


        public void updateLCD(int clocks, ref int lineClocksSinceLastUpdate, ref int refreshClocksSinceLastUpdate, ref int clocksSinceLastVBlank)
        {
            //if (beakMemory.getLCDEnabled())
            //{
            byte ly = Core.beakMemory.getLCDLY();
            byte originalLY = ly;

            if (gpuMode == 0)// || !beakGPU.getLCDOn()) //(Should be more accurate? Causes Bust A Move to be extremely slow when LCD is off)
            {
                //H-Blank
                //if greater than 204, inc ly, if ly 143 set mode to 1 and draw, else mode 2
                //40: SML 80: Tetris
                if ((clocks - lineClocksSinceLastUpdate) >= 204)//40)//80)//40)//80)//56)//102)//204)
                {
                    //if (!poweringOn)
                    {
                        ly++;
                        Core.beakMemory.setLCDLY(ly);
                    }

                    if (ly >= 144)
                    {
                        Core.beakGPU.setLCDMode(1);
                        gpuMode = 1;
                        clocksSinceLastVBlank = clocks;
                        //beakGPU.setLCDStatus((beakGPU.getLCDStatus() & 0xC7) | 0x8);
                        //Set LCD Interrupt if V-Blank Event is set
                        if ((Core.beakGPU.getLCDStatus() & 0x8) > 0)
                        {
                            Core.beakMemory.writeMemory(0xFF0F, (byte)(Core.beakMemory.readMemory(0xFF0F) | 0x02));
                        }

                        if ((clocks - refreshClocksSinceLastUpdate) >= 16384)//32768)//680)//12)
                        {
                            if (Core.beakMemory.getLCDEnabled())
                            {
                                drawScreenFromMaps(Core.beakGPU.getScrollX(), Core.beakGPU.getScrollY());

                                Core.mainWindow.updateScreen();
                                
                                screenUpdateWatch.Stop();
                                if(screenUpdateWatch.ElapsedMilliseconds == 0)
                                {
                                    screenUpdateWatch.Start();
                                }
                                else
                                {
                                    
                                    if(screenUpdateWatch.ElapsedMilliseconds < 17)
                                    {
                                        Thread.Sleep((int)(17 - screenUpdateWatch.ElapsedMilliseconds));
                                    }

                                    screenUpdateWatch.Restart();
                                }
                                
                            }
                            refreshClocksSinceLastUpdate = clocks;
                        }
                        //Set VBLANK Interrupt Flag
                        if (Core.beakGPU.getLCDOn())
                        {
                            Core.beakMemory.writeMemory(0xFF0F, (byte)(Core.beakMemory.readMemory(0xFF0F) | 0x1));
                        }

                        refreshClocksSinceLastUpdate = clocks;
                        //memset(spritePixels, 0, 256 * 256 * 4);

                        for(int i = 0; i < spritePixels.Length; i++)
                        {
                            spritePixels[i] = new Color(Color.Transparent);
                        }
                    }
                    else
                    {
                        Core.beakGPU.setLCDMode(2);
                        gpuMode = 2;
                        //beakGPU.setLCDStatus((beakGPU.getLCDStatus() & 0xC7) | 0x10);

                        //Set LCD Interrupt if OAM Event is set
                        if ((Core.beakGPU.getLCDStatus() & 0x10) > 0)
                        {
                            Core.beakMemory.writeMemory(0xFF0F, (byte)(Core.beakMemory.readMemory(0xFF0F) | 0x02));
                        }
                    }


                    lineClocksSinceLastUpdate = clocks;
                }

            }
            else if (gpuMode == 1)
            {
                //V-Blank
                //if greater than 456, inc ly, if ly > 153, set mode to 2, set ly to 0
                //50: SML 100: Tetris

                if ((clocks - lineClocksSinceLastUpdate) >= 456)//100)//50)//100)//114)//228)//456)
                {
                    if (!poweringOn)
                    {
                        ly++;
                        Core.beakMemory.setLCDLY(ly);
                    }
                    /*
			        if (ly >= 154)
			        {

				        //Set LCD Interrupt if OAM event is enabled
				        if ((beakGPU.getLCDStatus() & 0x10) > 0)
				        {
					        beakMemory.writeMemory(0xFF0F, (byte)(beakMemory.readMemory(0xFF0F) | 0x02));
				        }

				        ly = 0;
				        beakMemory.setLCDLY(ly);
			        }
			        */

                    lineClocksSinceLastUpdate = clocks;
                }

                if ((clocks - clocksSinceLastVBlank) >= 4560)
                {

                    Core.beakGPU.setLCDMode(2);
                    gpuMode = 2;
                    //beakGPU.setLCDStatus((beakGPU.getLCDStatus() & 0xC7) | 0x10);
                    lineClocksSinceLastUpdate = clocks;//-1;
                    poweringOn = false;

                    //Set LCD Interrupt if OAM event is enabled
                    if ((Core.beakGPU.getLCDStatus() & 0x10) > 0)
                    {
                        Core.beakMemory.writeMemory(0xFF0F, (byte)(Core.beakMemory.readMemory(0xFF0F) | 0x02));
                    }

                    ly = 0;
                    Core.beakMemory.setLCDLY(ly);
                }

            }
            else if (gpuMode == 2)
            {
                //OAM Mode
                //if greater than 80, set mode to 3
                //15: SML 30: Tetris
                /*
               if (lineClocksSinceLastUpdate == -1)
               {
                   lineClocksSinceLastUpdate = clocks;
               }
               */
                if ((clocks - lineClocksSinceLastUpdate) >= 80)//15)//30)//15)//20)//40)//80)
                {
                    Core.beakGPU.setLCDMode(3);
                    gpuMode = 3;
                    //beakGPU.setLCDStatus(beakGPU.getLCDStatus() & 0xC7);

                    lineClocksSinceLastUpdate = clocks;

                    if (Core.beakMemory.getLCDEnabled())
                    {
                        if (Core.beakGPU.getBackGroundEnabled())
                        {
                            Core.beakGPU.drawLineFromBGMap((byte)(Core.beakGPU.getScrollY() + ly));
                            scrollXValues[(byte)(Core.beakGPU.getScrollY() + ly)] = Core.beakGPU.getScrollX();
                        }
                    }
                }

            }
            else
            {
                //VRAM Mode
                //if greater than 172, set mode to 0
                //30: SML 60: Tetris
                if ((clocks - lineClocksSinceLastUpdate) >= 172)//30)//60)//30)//43)//86)//172)
                {
                    Core.beakGPU.setLCDMode(0);
                    gpuMode = 0;
                    //beakGPU.setLCDStatus((beakGPU.getLCDStatus() & 0xC7) | 0x4);

                    //Set LCD Interrupt if H-Blank Event is set
                    if ((Core.beakGPU.getLCDStatus() & 0x4) > 0)
                    {
                        Core.beakMemory.writeMemory(0xFF0F, (byte)(Core.beakMemory.readMemory(0xFF0F) | 0x02));
                    }

                    if (Core.beakMemory.getLCDEnabled())
                    {
                        if (Core.beakGPU.getSpriteEnabled())
                        {
                            Core.beakGPU.drawLineFromSpriteMap(ly);
                        }

                        if (Core.beakGPU.getWindowEnabled())
                        {
                            Core.beakGPU.drawLineFromWindowMap(ly);
                        }

                    }
                    lineClocksSinceLastUpdate = clocks;
                }

            }

            if (ly != originalLY)
            {

                //LCDLY Compare Interrupt
                if (Core.beakGPU.getLCDOn() && (Core.beakGPU.getLCDLY() == Core.beakGPU.getLCDLYCompare()))
                {
                    //Request interrupt of Interrupt for LCDLYCompare set
                    if (Core.beakGPU.getLCDLYCCheckEnabled() > 0)
                    {
                        Core.beakMemory.writeMemory(0xFF0F, (byte)(Core.beakMemory.readMemory(0xFF0F) | 0x02));
                    }

                    //Enable Coincidence Flag
                    Core.beakGPU.setLCDStatus((byte)(Core.beakGPU.getLCDStatus() | 0x04));
                }
                else
                {
                    //Disable Coincidence Flag
                    Core.beakGPU.setLCDStatus((byte)(Core.beakGPU.getLCDStatus() & 0xFB));
                }

            }

            //}
            //else
            //{
            //window->clear(Color::White);
            //window->display();
            //}

        }

        public void setBGPixel(byte x, byte y, Color color)
        {
            bgPixels[x + (y * 256)] = new Color(color);
        }

        public Color getBGPixel(byte x, byte y)
        {
            return new Color(bgPixels[x + (y * 256)]);
        }

        public void setWindowPixel(byte x, byte y, Color color)
        {
            windowPixels[x + (y * 256)] =  new Color(color);
        }

        public void setSpritePixel(byte x, byte y, Color color)
        {
            spritePixels[x + (y * 256)] = new Color(color);
        }

        /*
         * Draw the full window (only what is on-screen) to Image screen variable
         */
        public void drawScreenFromMaps(byte scrollX, byte scrollY)
        {

            
            if (Core.beakGPU.getBackGroundEnabled())
            {

                byte x = 0;
                byte y = 0;


                for (int i = 0; i < 160; i++)
                {
                    
                    for (int j = 0; j < 144; j++)
                    {
                        y = (byte)(scrollY + j);
                        x = (byte)(scrollXValues[y] + i);

                        screen.SetPixel((uint)i, (uint)j, new Color(bgPixels[x + (y * 256)]));
                    }

                }
            }
            
            
            if (Core.beakGPU.getWindowEnabled())
            {
                //Draw Window
                int winX = (Core.beakGPU.getWindowX() - 7);
                int winY = (Core.beakGPU.getWindowY());

                bool yTest = (winY <= 144) && ((winY + 256) >= 0);
                bool xTest = (winX < 160) && ((winX + 256) > 0);

                if (xTest && yTest)
                {
                    int xShift = 0;
                    int yShift = 0;
                    int x = 0;
                    int y = 0;

                    if (winX < 0)
                    {
                        xShift = (0 - winX);
                    }
                    else
                    {
                        x = winX;
                    }

                    if (winY < 0)
                    {
                        yShift = (0 - winY);
                    }
                    else
                    {
                        y = winY;
                    }

                    for (int i = 0; (i + x + xShift) < 160; i++)
                    {
                        for (int j = 0; (j + y + yShift) < 144; j++)
                        {
                            screen.SetPixel((uint)(x + xShift + i  - 1), (uint)(y + yShift + j), new Color(windowPixels[(xShift + i) + ((yShift + j) * 256)]));
                        }

                    }

                }

            }
            
            //Draw Sprites
            if (Core.beakGPU.getSpriteEnabled())
            {
                byte x = 0;
                byte y = 0;
                while (y < 144)
                {
                    if (spritePixels[((x) + ((y) * 256))].A != 0)
                    {
                        screen.SetPixel(x, y, new Color(spritePixels[(x) + (y * 256)]));

                    }

                    if (x < 159)
                    {
                        x++;
                    }
                    else
                    {
                        x = 0;
                        y++;
                    }

                }
            }

            for (int i = 0; i < (256 * 256); i++)
            {
                spritePixels[i].A = 0;
            }

            //drawImageToScreen(screen);

        }

        /*
         * Draw the full window (including data extending outside screen) to an Image file
         */
        public Image drawFullScreenMaps()
        {

            Image fullScreen = new Image(256, 256, Color.Transparent);

            if (Core.beakGPU.getBackGroundEnabled())
            {
                for (int x = 0; x < 256; x++)
                {

                    for (int y = 0; y < 256; y++)
                    {
                        fullScreen.SetPixel((uint)x, (uint)y, new Color(bgPixels[x + (y * 256)]));
                    }

                }
            }

            if (Core.beakGPU.getWindowEnabled())
            {
                //Draw Window
                int winX = (Core.beakGPU.getWindowX() - 7);
                int winY = Core.beakGPU.getWindowY();

                bool yTest = (winY <= 256) && ((winY + 256) >= 0);
                bool xTest = (winX < 256) && ((winX + 256) > 0);

                if (xTest && yTest)
                {
                    int xShift = 0;
                    int yShift = 0;
                    int x = 0;
                    int y = 0;

                    if (winX < 0)
                    {
                        xShift = (0 - winX);
                    }
                    else
                    {
                        x = winX;
                    }

                    if (winY < 0)
                    {
                        yShift = (0 - winY);
                    }
                    else
                    {
                        y = winY;
                    }

                    for (int i = 0; (i + x + xShift) < 160; i++)
                    {
                        for (int j = 0; (j + y + yShift) < 144; j++)
                        {
                            //fullScreen.setPixel(beakGPU.getScrollX() + (x + xShift + i) , beakGPU.getScrollY() + (y + yShift + j), windowPixels[(xShift + i) + ((yShift + j) * 256)]);
                            fullScreen.SetPixel((uint)(x + xShift + i), (uint)(y + yShift + j), windowPixels[(xShift + i) + ((yShift + j) * 256)]);
                        }

                    }

                }

            }


            //Draw Sprites
            if (Core.beakGPU.getSpriteEnabled())
            {
                byte x = 0;
                byte y = 0;
                while (y < 256)
                {
                    if (spritePixels[((x) + ((y) * 256))].A != 0)
                    {
                        //fullScreen.setPixel(beakGPU.getScrollX() + x, beakGPU.getScrollY() + y, spritePixels[(x)+(y * 256)]);
                        fullScreen.SetPixel(x, y, new Color(spritePixels[(x) + (y * 256)]));
                    }

                    if (x < 255)
                    {
                        x++;
                    }
                    else
                    {
                        x = 0;
                        y++;
                    }

                }
            }

            //drawImageToScreen(fullScreen);
            return fullScreen;
        }



        public int getGPUMode()
        {
            return gpuMode;
        }


    }
}
