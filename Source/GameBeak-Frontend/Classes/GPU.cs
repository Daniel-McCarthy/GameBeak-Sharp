using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SFML.Graphics;


namespace GameBeak.Classes
{
    class GPU
    {

        //These are the default colors that will represent the 4 color palette of the GMB
        private static Color darkestPink = new Color(72, 24, 59, 255); //Pink Black //48183BFF
        private static Color darkPink = new Color(255, 131, 217, 255); //Dark Pink //FF83D9FF
        private static Color lightPink = new Color(255, 214, 245, 255); //Light Pink //FFD6F5FF
        private static Color lightestPink = new Color(255, 241, 254, 255); //Pink WHITE //FFF1FEFF

        public List<Color> gameBeakPalette = new List<Color>
        {
            lightestPink, lightPink, darkPink, darkestPink,
            lightestPink, lightPink, darkPink, darkestPink,
            lightestPink, lightPink, darkPink, darkestPink
        };


        public byte getLCDStatus()
        {
            return Core.beakMemory.readMemory(0xFF41);
        }

        public void setLCDStatus(byte newStatus)
        {
            Core.beakMemory.directMemoryWrite(0xFF41, newStatus);
        }

        public void setLCDMode(byte status)
        {
            Core.beakMemory.directMemoryWrite(0xFF41, (byte)((getLCDStatus() & 0xFC) | status));
        }

        public byte getLCDMode()
        {
            return (byte)(getLCDStatus() & 0x03);
        }

        public byte getLCDLYCCheckEnabled()
        {
            return (byte)((getLCDStatus() & 0x40) >> 6);
        }

        public byte getLCDLYCompare()
        {
            return Core.beakMemory.readMemory(0xFF45);
        }

        public byte getLCDLY()
        {
            return Core.beakMemory.readMemory(0xFF44);
        }

        public byte getLCDControl()
        {
            return Core.beakMemory.readMemory(0xFF40);
        }

        public bool getLCDOn()
        {
            return ((getLCDControl() & 0x80) >> 7) > 0;
        }

        public bool getWindowTileMapLocation()
        {
            return ((getLCDControl() & 0x40) >> 6) > 0;
        }

        public bool getWindowEnabled()
        {
            return ((getLCDControl() & 0x20) >> 5) > 0;
        }

        public bool getBackGroundWindowTileSetLocation()
        {
            return ((getLCDControl() & 0x10) >> 4) > 0;
        }

        public bool getBackGroundTileMapLocation()
        {
            return ((getLCDControl() & 0x08) >> 3) > 0;
        }

        public bool getSpriteSize()
        {
            return ((getLCDControl() & 0x04) >> 2) > 0;
        }

        public bool getSpriteEnabled()
        {
            return ((getLCDControl() & 0x02) >> 1) > 0;
        }

        public bool getBackGroundEnabled()
        {
            return (getLCDControl() & 0x01) > 0;
        }

        //DrawLineFromMap: Draws a single specific line of the background map
        public void drawLineFromBGMap(int lineY)
        {

            int mapAddress;
            int baseAddress;

            if (getBackGroundTileMapLocation())
            {
                mapAddress = 0x9C00;
            }
            else
            {
                mapAddress = 0x9800;
            }

            if (getBackGroundWindowTileSetLocation())
            {
                baseAddress = 0x8000;
            }
            else
            {
                baseAddress = 0x8800;
            }

            int lineToDraw = lineY % 8;

            ushort tileY = 0;
            ushort tileX = 0;
            ushort tileIndex = 0;
            ushort tileIDAddress = 0;
            ushort tileID = 0;
            ushort tileOffset = 0;
            ushort tileAddress = 0;
            byte rowHalf1 = 0;
            byte rowHalf2 = 0;

            for (int i = 0; i < 32; i++)
            {
                tileY = (ushort)((lineY) / 8);
                tileX = (ushort)(i);
                tileIndex = (ushort)(tileX + (32 * tileY));
                tileIDAddress = (ushort)(mapAddress + tileIndex);

                tileID = Core.beakMemory.readMemory(tileIDAddress);

                if (baseAddress == 0x8800)
                {
                    if (tileID > 0x7F)
                    {
                        tileID -= 0x80;
                    }
                    else
                    {
                        tileID += 0x80;
                    }
                }

                tileOffset = (ushort)(tileID * 16);
                tileAddress = (ushort)(baseAddress + tileOffset);


                rowHalf1 = Core.beakMemory.readMemory((ushort)(tileAddress + (lineToDraw * 2)));
                rowHalf2 = Core.beakMemory.readMemory((ushort)(tileAddress + (lineToDraw * 2) + 1));

                for (int j = 0; j < 8; j++)
                {
                    Core.beakWindow.setBGPixel((byte)((i * 8) + j), (byte)lineY, returnColor(((rowHalf1 & 0x80) >> 7) | ((rowHalf2 & 0x80) >> 6), 0));
                    rowHalf1 <<= 1;
                    rowHalf2 <<= 1;

                }

            }

        }

        public void drawLineFromWindowMap(int lineY)
        {

            int mapAddress;
            int baseAddress;

            if (getWindowTileMapLocation())
            {
                mapAddress = 0x9C00;
            }
            else
            {
                mapAddress = 0x9800;
            }

            if (getBackGroundWindowTileSetLocation())
            {
                baseAddress = 0x8000;
            }
            else
            {
                baseAddress = 0x8800;
            }

            int lineToDraw = lineY % 8;

            int tileY = 0;
            int tileX = 0;
            int tileIndex = 0;
            int tileIDAddress = 0;
            int tileID = 0;
            int tileOffset = 0;
            int tileAddress = 0;
            byte rowHalf1 = 0;
            byte rowHalf2 = 0;

            for (int i = 0; i < 32; i++)
            {

                tileY = (lineY) / 8;
                tileX = (i);
                tileIndex = tileX + (32 * tileY);
                tileIDAddress = mapAddress + tileIndex;

                tileID = Core.beakMemory.readMemory((ushort)(tileIDAddress));

                if (baseAddress == 0x8800)
                {
                    if (tileID > 0x7F)
                    {
                        tileID -= 0x80;
                    }
                    else
                    {
                        tileID += 0x80;
                    }
                }

                tileOffset = tileID * 16;
                tileAddress = baseAddress + tileOffset;

                rowHalf1 = Core.beakMemory.readMemory((ushort)(tileAddress + (lineToDraw * 2)));
                rowHalf2 = Core.beakMemory.readMemory((ushort)(tileAddress + (lineToDraw * 2) + 1));

                for (int j = 0; j < 8; j++)
                {
                    Core.beakWindow.setWindowPixel((byte)((i * 8) + j), (byte)lineY, returnColor(((rowHalf1 & 0x80) >> 7) | ((rowHalf2 & 0x80) >> 6), 0));
                    rowHalf1 &= 0x7F;
                    rowHalf1 <<= 1;
                    rowHalf2 &= 0x7F;
                    rowHalf2 <<= 1;

                }

            }


        }


        public void drawLineFromSpriteMap(int lineY)
        {
            //Todo: Support priority.

            ushort mapAddress = 0xFE00;
            int baseAddress = 0x8000;

            //False: 8x8 | True: 8x16
            bool spriteSize = getSpriteSize();

            int y = 0;
            byte x = 0;
            int tileY = 0;
            int tileX = 0;
            int tileIndex = 0;
            int tileIDAddress = 0;
            int tileID = 0;
            int tileOffset = 0;
            int tileAddress = 0;
            byte rowHalf1 = 0;
            byte rowHalf2 = 0;
            int lineToDraw = 0;

            byte tileNumber = 0;
            byte tileFlags = 0;
            bool priority = false;
            bool yFlip = false;
            bool xFlip = false;
            bool palette = false;

            byte scrollX = getScrollX();
            byte scrollY = getScrollY();

            Color bgColor = returnColor(0, 0);

            for (int i = 0; i < 40; i++)
            {
                y = Core.beakMemory.readMemory((ushort)((mapAddress + (i * 4)))) - 16;

                if (y > -8)
                {

                    x = (byte)(Core.beakMemory.readMemory((ushort)((mapAddress + (i * 4) + 1))) - 8);

                    bool isSpriteOnLine = (y <= lineY) && ((y + ((spriteSize == false) ? 8 : 16)) > lineY);
                    //(y <= lineY)  if the start of the sprite is at lineY or before it
                    //(y + (spriteSize == 0) ? 8 : 16)) > lineY) if the end of the sprite is past lineY (By way of commenting, this isn't the problem)


                    if (isSpriteOnLine)
                    {


                        lineToDraw = lineY - y;

                        tileNumber = Core.beakMemory.readMemory((ushort)(mapAddress + (i * 4) + 2));
                        tileFlags = Core.beakMemory.readMemory((ushort)(mapAddress + (i * 4) + 3));
                        priority = ((tileFlags & 0x80) >> 7) > 0; //If 1, displays in front of window. Otherwise is below window and above BG
                        yFlip = ((tileFlags & 0x40) >> 6) > 0; //Vertically flipped if 1, else 0.
                        xFlip = ((tileFlags & 0x20) >> 5) > 0; //Horizontally flipped if 1, else 0;
                        palette = ((tileFlags & 0x10) >> 4) > 0; //Palette is OBJ0PAL if 0, else OBJ1PAL

                        tileOffset = tileNumber * 16;
                        tileAddress = baseAddress + tileOffset;

                        if (yFlip)
                        {
                        }

                        rowHalf1 = Core.beakMemory.readMemory((ushort)(tileAddress + (lineToDraw * 2)));
                        rowHalf2 = Core.beakMemory.readMemory((ushort)(tileAddress + (lineToDraw * 2) + 1));

                        if (xFlip)
                        {
                            rowHalf1 = Binary.reverseBits(rowHalf1);
                            rowHalf2 = Binary.reverseBits(rowHalf2);
                        }

                        for (int j = 0; j < 8; j++)
                        {
                            byte colorNumber = (byte)(((rowHalf1 & 0x80) >> 7) | ((rowHalf2 & 0x80) >> 6));

                            if (colorNumber > 0)
                            {
                                if (!priority || (priority && (Core.beakWindow.getBGPixel((byte)(scrollX + x + j), (byte)(lineY + scrollY)).Equals(bgColor))))
                                {
                                    Core.beakWindow.setSpritePixel((byte)(x + j), (byte)lineY, returnColor(colorNumber, ((palette) ? 1 : 0) + 1)); //Plus 1 because 0 is BG palette, so value must be 1 or 2 to access OBJ1 or OBj2.
                                }
                            }

                            rowHalf1 <<= 1;
                            rowHalf2 <<= 1;
                        }

                    }
                }
            }
        }

        public byte getScrollX()
        {
            return Core.beakMemory.readMemory(0xFF43);
        }

        public byte getScrollY()
        {
            return Core.beakMemory.readMemory(0xFF42);
        }

        public byte getWindowX()
        {
            return Core.beakMemory.readMemory(0xFF4B);
        }

        public byte getWindowY()
        {
            return Core.beakMemory.readMemory(0xFF4A);
        }

        public Color returnColor(int colorNumber)
        {
            return new Color(gameBeakPalette[colorNumber + (Core.paletteSetting * 12)]);
        }

        public Color returnColor(int colorNumber, int palette)
        {
            //Palette: 0 = BGP
            //Palette: 1 = 0BP0
            //Palette: 2 = 0BP1

            //Palette decides between BGP (0xFF47), 0BP0 (0xFF48), and 0BP1 (0xFF49)
            //Color number decides which color slot is selected from the palette data.
            //The value returned from the palette data is then used to index from the emulator's palette array.

            byte paletteData = Core.beakMemory.readMemory((ushort)(0xFF47 + palette));
            colorNumber = (paletteData & (3 << (colorNumber * 2))) >> (colorNumber * 2);//(colorNumber + 1);
            return new Color(gameBeakPalette[colorNumber + (Core.paletteSetting << 2)]);

            //return gameBeakPalette[((Core.beakMemory.readMemory((ushort)(0xFF47 + palette)) & (3 << (colorNumber * 2))) >> (colorNumber * 2)) + (Core.paletteSetting * 12) + (palette << 2)];


            //The palette variable is being used to select the memory location of the palette
            //The palette data that is retrieved is made up of 8 bits. 4 colors represented by 2 bits each.
            //The 2 bit groups can represent numbers 0-3 and represent how light or dark the color we want is supposed to be.
            //Once we retrieve the correct grouping it will be used to index the exact color to be used from the emulator's palette array.
            //To retrieve the appropriate grouping we have to mask the 2 bits we want. The number 3 will
            //retrieve the first 2 bits, and we can shift the number three to select the next three groupings if needed.
            //We use the color number to decide how much 3 needs to be shifted (if at all) to get the set of bits we want.
            //We then use it again to decide how much they need to be shifted right (if at all) to reduce the number to 0-3
            //Finally, we have the index we will use to index the palette, and we can add the value of paletteSettng * 4 (or << 2) (multiples of 4 to select correct group)
            //To index the grey or pink set of colors depending on the mode.


            //Below is identical functionality, but simply much slower.
            //return gameBeakPalette[ returnHalfNibble( returnPalette(palette), colorNumber) ];
        }

        public byte returnPalette(byte palette)
        {
            //Palette: 0 = BGP
            //Palette: 1 = 0BP0
            //Palette: 2 = 0BP1
            return Core.beakMemory.readMemory((ushort)(0xFF47 + palette));
        }

    }
}
