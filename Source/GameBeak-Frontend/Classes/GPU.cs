using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace GameBeak_Frontend.Classes
{
    class GPU
    {
        private static Color darkestPink = new Color(72, 24, 59, 255); //Pink Black //48183BFF
        private static Color darkPink = new Color(255, 131, 217, 255); //Dark Pink //FF83D9FF
        private static Color lightPink = new Color(255, 214, 245, 255); //Light Pink //FFD6F5FF
        private static Color lightestPink = new Color(255, 241, 254, 255); //Pink WHITE //FFF1FEFF

        private List<Color> gameBeakPalette = new List<Color>
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
                    Core.beakWindow.setBGPixel((i * 8) + j, lineY, returnColor(((rowHalf1 & 0x80) >> 7) | ((rowHalf2 & 0x80) >> 6), 0));
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
                    Core.beakWindow.setWindowPixel((i * 8) + j, lineY, returnColor(((rowHalf1 & 0x80) >> 7) | ((rowHalf2 & 0x80) >> 6), 0));
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
                y = Core.beakMemory.readMemory((ushort)((mapAddress + (i * 4)) - 16));

                if (y > -8)
                {

                    x = Core.beakMemory.readMemory((ushort)((mapAddress + (i * 4) + 1) - 8));

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
                            lineToDraw = 8 - lineToDraw;
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
                                if (!priority || (priority && (Core.beakWindow.getBGPixel(scrollX + x + j, lineY + scrollY) == bgColor)))
                                {
                                    Core.beakWindow.setSpritePixel(x + j, lineY, returnColor(colorNumber, Convert.ToInt32(palette) + 1)); //Plus 1 because 0 is BG palette, so value must be 1 or 2 to access OBJ1 or OBj2.
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
            return gameBeakPalette[colorNumber + (Core.paletteSetting * 12)];
        }

        public Color returnColor(int colorNumber, int palette)
        {
            //Palette: 0 = BGP
            //Palette: 1 = 0BP0
            //Palette: 2 = 0BP1

            //Palette decides between BGP (0xFF47), 0BP0 (0xFF48), and 0BP1 (0xFF49)
            //Color number decides which color slot is selected from the palette data.
            //The value returned from the palette data is then used to index from the emulator's palette array.

            //unsigned char paletteData = beakMemory.readMemory(0xFF47 + palette);
            //colorNumber = (paletteData & (3 << (colorNumber * 2))) >> (colorNumber * 2);//(colorNumber + 1);
            //return gameBeakPalette[colorNumber + paletteSetting << 2)];

            return gameBeakPalette[((Core.beakMemory.readMemory((ushort)(0xFF47 + palette)) & (3 << (colorNumber * 2))) >> (colorNumber * 2)) + (Core.paletteSetting * 12) + (palette << 2)];


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

        public void loadPalettesFromXML(FileStream inputFile)
        {
            string line;
            List<byte> colorValues = new List<byte>();

            StreamReader fileReader = new StreamReader(inputFile);

            while (!fileReader.EndOfStream)
            {
                line = fileReader.ReadLine();

                bool test1 = (line.Contains("<bgp>")) && (line.Contains("</bgp>"));
                bool test2 = (line.Contains("<0bp0>")) && (line.Contains("</0bp0>"));
                bool test3 = (line.Contains("<0bp1>")) && (line.Contains("</0bp1>"));

                if (test1 || test2 || test3)
                {
                    int first = line.IndexOf('>') + 1;
                    int last = line.LastIndexOf('<');

                    line = line.Substring(first, last - first);

                    for (int i = 0; i < 4; i++)
                    {
                        byte r = byte.Parse(line.Substring(0, 2));
                        byte g = byte.Parse(line.Substring(2, 2));
                        byte b = byte.Parse(line.Substring(4, 2));

                        colorValues.Add(r);
                        colorValues.Add(g);
                        colorValues.Add(b);

                        if (line.Length > 8)
                        {
                            line = line.Substring(9, line.Length - 9);
                        }
                    }

                }
            }
            if ((colorValues.Count / 36) > 0)
            {
                int paletteOffset = 0;
                int colorOffset = 0;

                while (colorValues.Count >= (4 * 3))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        byte r = colorValues.First();
                        colorValues.RemoveAt(0);
                        byte g = colorValues.First();
                        colorValues.RemoveAt(0);
                        byte b = colorValues.First();
                        colorValues.RemoveAt(0);

                        Color color = new Color(r, g, b, 255);


                        Core.beakGPU.gameBeakPalette[(paletteOffset * 4) + colorOffset] = color;

                        if (colorOffset >= 3)
                        {
                            colorOffset = 0;
                        }
                        else
                        {
                            colorOffset++;
                        }
                    }

                    paletteOffset++;
                }
            }

            fileReader.Close();
            inputFile.Close();
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
