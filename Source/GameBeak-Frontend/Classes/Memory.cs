using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace GameBeak.Classes
{
    class Memory
    {
        private byte[] ramMap = new byte[0x10000];
        private byte[] externalVRAMBank = new byte[0x2000]; //CGB Only
        private byte[] internalRam = new byte[0x8000]; //CGB Only
        private byte[] externalRam = new byte[0x1E000];
        public bool ramEnabled = false;

        private short regAF = 0;
        private short regBC = 0;
        private short regDE = 0;
        private short regHL = 0;

        public short stackPointer = 0;
        public short memoryPointer = 0x0100;

        //GBC Only Registers
        private byte[] backgroundPaletteRam = new byte[0x40];
        private byte[] spritePaletteRam     = new byte[0x40];
        private byte internalRamBank = 1; //CGB Only
        private byte vramBank = 0; //CGB Only

        public bool loadRom(string path)
        {
            if (File.Exists(path))
            {
                byte[] romFile = File.ReadAllBytes(path);

                if (romFile != null && romFile.Length > 0)
                {
                    if (romFile.Length <= 0x500000)
                    {
                        Core.rom = new Rom(romFile);
                    }
                    else
                    {
                        MessageBox.Show("Error: Rom too large. It does not fit in GameBoy's memory.");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Error: Rom was unable to be opened or contains no data.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Error: Rom does not exist.");
                return false;
            }

            return true;
        }

        public bool loadRom(byte[] romFile)
        {

            if ((romFile.Length != 0) && (romFile.Length > 0))
            {
                if (romFile.Length <= 0x500000)
                {
                    Core.rom = new Rom(romFile);
                }
                else
                {
                    MessageBox.Show("Error: Rom too large. It does not fit in GameBoy's memory.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Error: Rom was unable to be opened or contains no data.");
                return false;
            }

            return true;
        }

        /*
        Load Rom and Attempt to Load Save if selected
        */
        
        public bool loadRom(string path, bool findAndLoadSaveFile)
        {

            loadRom(path);

            if (findAndLoadSaveFile)
            {
                //Attempt to open file, if it was successful close it and call the full loadSave function
                string savePath = path.Substring(0, path.LastIndexOf('.')) + ".sav";

                if(File.Exists(savePath))
                {
                    loadSaveFile(savePath);

                }
            }

            return true;
        }

        public void writeToExternalRam(uint address, byte value)
        {
            if (address < externalRam.Length)
            {
                externalRam[address] = value;
            }
        }

        public byte readFromExternalRam(uint address)
        {
            return externalRam[address];
        }

        public void writeRom0ToRam()
        {
            for (uint i = 0; i <= 0x3FFF; i++)
            {
                ramMap[i] = Core.rom.readByte(i);
            }
        }

        public void writeFullRomToRam()
        {
            for (uint i = 0; i <= 0x7FFF; i++)
            {
                ramMap[i] = Core.rom.readByte(i);
            }
        }

        public byte readSpritePaletteRam(byte address)
        {
            return spritePaletteRam[address];
        }

        public byte readBackgroundPaletteRam(byte address)
        {
            return backgroundPaletteRam[address];
        }

        public byte readVRAMBankRam(ushort address, byte bank)
        {
            //In GBC mode there are two swappable banks. The current vramBank is loaded in the ramMap. The other bank is loaded in an external bank.
            //Therefore if the selected bank isn't the current vram bank, the bank must me in the external bank.

            //If not in GBC mode, then then only bank available is bank 0, which will always be loaded in the ram map in this mode.

            if(Core.GBCMode && vramBank != bank)
            {
                if(address >= 0x8000)
                {
                    address -= 0x8000;
                }

                return externalVRAMBank[address];
            }
            else
            {
                return ramMap[address];
            }
        }

        public byte readMemory(ushort address)
        {
            /*
            if (accessBreakpoint && memoryPointer == accessBreakpointAddress)
            {
                paused = true;
            }
            */

            if (address == 0xFF41)
            {
                return (byte)(ramMap[address] | 0x80);
            }
            else if (address == 0xFF4D && Core.GBCMode)
            {
                // Get Speed Mode

                byte returnValue = 0;
                returnValue |= (byte)(Core.beakCPU.preparingSpeedChange ? 1 : 0);
                returnValue |= (byte)(Core.beakCPU.doubleSpeedMode ? 0x80 : 0);

                return returnValue;

            }
            else if (address == 0xFF4F && Core.GBCMode)
            {
                // Read VRAM Bank Number
                return (byte)(0b11111110 | (vramBank & 0b00000001));
            }
            else if (address == 0xFF69 && Core.GBCMode)
            {
                // Read Background Palette Ram Data.

                // BG Index: Bits 0,1,2,3,4,5: Index value. Bit 6: Unused. Bit 7: Auto-increment index on write. 0: Disabed, 1: Enabled.
                byte bgIndexData = ramMap[0xFF68];
                // Retrieve index data for palette ram read.
                byte index = (byte)(bgIndexData & 0b00111111);

                return backgroundPaletteRam[index];
            }
            else if (address == 0xFF6B && Core.GBCMode)
            {
                // Read Sprite Palette Ram Data.

                // Sprite Index: Bits 0,1,2,3,4,5: Index value. Bit 6: Unused. Bit 7: Auto-increment index on write. 0: Disabed, 1: Enabled.
                byte spriteIndexData = ramMap[0xFF6A];
                // Retrieve index data for palette ram read.
                byte index = (byte)(spriteIndexData & 0b00111111);

                return spritePaletteRam[index];
            }
            else
            {
                return ramMap[address];
            }
        }

        public byte[] readMemory(int address, int bytes)
        {
            byte[] returnMemory = new byte[bytes];

            for (int i = 0; i < bytes; i++)
            {
                returnMemory[i] = (byte)(ramMap[address + i]);
            }

            return returnMemory;
        }

        //DMA Transfer
        public void transferDMA(byte address)
        {
            //TODO:This should occur over time, not all at once


            if (address <= 0xF1)
            {
                ushort baseAddress = (ushort)(address << 8);//*= 100;

                for (int i = 0; i < 160; i++)
                {
                    writeMemory((ushort)(0xFE00 + i), readMemory((ushort)(baseAddress + i)));
                }
            }
        }

        public void directMemoryWrite(ushort address, byte value)
        {
            /*
                Write to Ram without ordinary restrictions. Only to be used by hardware emulating functions and not game instructions.
            */

            ramMap[address] = value;
        }

        public void writeMemory(ushort address, byte value)
        {
            if (Core.rom.mapperSetting > 0 && address <= 0x7FFF)
            {
                if (Core.rom.mapperSetting <= 3)
                {
                    
                    Mappers.MBC1.writeMBC1Value(address, value);
                }
                else if (Core.rom.mapperSetting <= 6)
                {
                    Mappers.MBC2.writeMBC2Value(address, value);
                }
                else if (Core.rom.mapperSetting <= 9)
                {
                    //8: Rom+Ram
                    //9: Rom+Ram+Battery
                }
                else if (Core.rom.mapperSetting <= 0x0D)
                {
                    //0B: MMM01
                    //0C: MMM01+Ram
                    //0D: MMM01+Ram+Battery
                }
                else if (Core.rom.mapperSetting <= 0x10)
                {
                    //0F: MBC3+Timer+Battery
                    //10: MBC3+Timer+Ram+Battery
                    //11: MBC3
                    //12: MBC3+Ram
                    //13: MBC3+Ram+Battery

                    //Add this later: MBC3 is not currently ready (RTC)
                    Mappers.MBC3.writeMBC3Value(address, value);
                }
                else if (Core.rom.mapperSetting <= 0x1E)
                {
                    Mappers.MBC5.writeMBC5Value(address, value);
                }
                //TODO: Add more MBC controllers

            }
            else
            {
                if (address >= 0x8000 && address <= 0xFFFF)
                {
                    if (address == (ushort)0xFF46)
				    {
                        //Initiate DMA Transfer Register
                        transferDMA(value);
                    }
				    else if (address == (ushort)0xFF41)
				    {
                        //Set LCDC Status
                        ramMap[address] = (byte)((ramMap[address] & 0x87) | (value & 0x78) | 0x80); //Bit 7 is always 1, Bit 0, 1, and 2 are read only. //&0x87 clears bits 3, 4, 5, 6 from Stat. &0xF8 clears all but bit bit 0, 1, 2, and 7 from value being written.
                    }
                    else if (address == 0xFF4D && Core.GBCMode)
                    {
                        // Set Speed Mode

                        bool newSpeedSetting = (value & 0b0000 - 0001) == 1;

                        if(Core.beakCPU.doubleSpeedMode != newSpeedSetting)
                        {
                            Core.beakCPU.preparingSpeedChange = true;
                        }
                    }
                    else if (address == 0xFF4F && Core.GBCMode)
                    {
                        // Swap VRAM Bank
                        swapVRAMBank(value);
                    }
                    else if (address == 0xFF55 && Core.GBCMode)
                    {
                        // Initiate GBC HDMA Transfer.
                        ushort sourceAddress = (ushort)((ramMap[0xFF51] << 8) | ramMap[0xFF52]);
                        ushort targetAddress = (ushort)((ramMap[0xFF53] << 8) | ramMap[0xFF54]);

                        // Mask off low 4 bits from addresses.
                        sourceAddress &= 0xFFF0;
                        targetAddress &= 0x1FF0;

                        int byteTransferAmount = value * 16;

                        for(int i = 0; i < byteTransferAmount; i++)
                        {
                            ramMap[0x8000 + targetAddress + i] = ramMap[sourceAddress + i];
                        }
                    }
                    else if (address == 0xFF68 && Core.GBCMode)
				    {
                        // Set GBC Background Palette Index
                        ramMap[address] = (byte)(0x40 | (value));
                        // Bit 7: Increment on Write setting //Bit 6: Unused //Bit 0,1,2,3,4,5 Index (0-3F)
                    }
                    else if (address == 0xFF69 && Core.GBCMode)
                    {
                        // Write to Background Palette Ram.

                        // BG Index: Bits 0,1,2,3,4,5: Index value. Bit 6: Unused. Bit 7: Auto-increment index on write. 0: Disabed, 1: Enabled.
                        byte bgIndexData = ramMap[0xFF68];
                        bool bgIndexAutoIncrement = (bgIndexData & 0x80) != 0;

                        // Retrieve index data for palette ram write.
                        byte index = (byte)(bgIndexData & 0b00111111);

                        // Write data to palette ram at index.
                        backgroundPaletteRam[index] = value;

                        // Increment index data if auto-increment is enabled.
                        if (bgIndexAutoIncrement)
                        {
                            byte newIndexData = (byte)(index + 1);
                            newIndexData |= 0b11000000; // Set unused and auto-increment bits to enabled.
                            ramMap[0xFF68] = newIndexData;
                        }
                    }
                    else if (address == 0xFF6A && Core.GBCMode)
                    {
                        // Set GBC Sprite Palette Index
                        ramMap[address] = (byte)(0x40 | (value));
                        // Bit 7: Increment on Write setting //Bit 6: Unused //Bit 0,1,2,3,4,5 Index (0-3F)
                    }
                    else if (address == 0xFF6B && Core.GBCMode)
                    {
                        // Write to Sprite Palette Ram.

                        // Sprite Index: Bits 0,1,2,3,4,5: Index value. Bit 6: Unused. Bit 7: Auto-increment index on write. 0: Disabed, 1: Enabled.
                        byte spriteIndexData = ramMap[0xFF6A];
                        bool spriteIndexAutoIncrement = (spriteIndexData & 0x80) != 0;

                        // Retrieve index data for palette ram write.
                        byte index = (byte)(spriteIndexData & 0b00111111);

                        // Write data to palette ram at index.
                        spritePaletteRam[index] = value;

                        // Increment index data if auto-increment is enabled.
                        if (spriteIndexAutoIncrement)
                        {
                            byte newIndexData = (byte)(index + 1);
                            newIndexData |= 0b11000000; // Set unused and auto-increment bits to enabled.
                            ramMap[0xFF6A] = newIndexData;
                        }
                    }
                    else if (address == 0xFF70 && Core.GBCMode)
                    {
                        // Swap Internal Ram Bank at 0xD000
                        byte bankValue = (byte)(value & 0b111);

                        if (bankValue == 0)
                            bankValue = 1;

                        swapInternalRamBank(bankValue);
                    }
                    else
				    {
                        if (address >= 0xC000 && address <= 0xDDFF)
                        {
                            //ECHO. Anything written to here also gets written to CXXXX
                            ramMap[address + 0x2000] = value;
                        }
                        else if (address >= 0xE000 && address <= 0xFDFF)
                        {
                            ramMap[address - 0x2000] = value;
                        }

                        ramMap[address] = value;
                    }
                }
            }
        }

        public void writeMemory(ushort address, short value)
        {
            writeMemory((ushort)(address + 1), (byte)((value & 0xFF00) >> 8));
            writeMemory((ushort)(address), (byte)(value & 0x00FF));
        }

        public void swapVRAMBank(byte newBank)
        {
            // Mask away unused data.
            newBank &= 0b00000001;

            if (vramBank != newBank)
            {
                // Swap bank in GB vram with bank in external VRAM.
                for (int i = 0; i < 0x2000; i++)
                {
                    byte temporarySwapByte = externalVRAMBank[i];   // Hold new data from external bank.
                    externalVRAMBank[i] = ramMap[0x8000 + i];       // Write previous bank data to external bank.
                    ramMap[0x8000 + 1] = temporarySwapByte;         // Write new bank data to GB VRAM region.
                }

                // Set new bank number to the vram bank value.
                vramBank = newBank;
            }
        }

        public void swapInternalRamBank(byte newBank)
        {
            if (internalRamBank != newBank)
            {
                if (newBank < 8)
                {
                    ushort oldBankAddress = (ushort)(internalRamBank * 0x1000);
                    ushort bankAddress = (ushort)(newBank * 0x1000);
                    ushort ramAddress = 0xD000; //0xC000-CFFF is bank 0; //0xD000-DFFF is swappable

                    //Write current GB ram data to internal ram bank
                    for (int i = 0; i < 0x1000; i++)
                    {
                        internalRam[oldBankAddress + i] = ramMap[ramAddress + i];
                    }

                    //Write new internal ram bank data to GB ram
                    for (int i = 0; i < 0x1000; i++)
                    {
                        ramMap[ramAddress + i] = internalRam[bankAddress + i];
                    }

                    // Set new bank number to the internal ram bank value.
                    internalRamBank = newBank;
                }
            }
        }


        public void toggleZFlag()
        {
            byte flag = getF();
            flag ^= 0x80; //Toggles left most bit
            setF(flag);
        }

        public void setZFlag(bool setting)
        {
            if (setting)
            {
                byte flag = getF();
                flag |= 0x80; //Sets left most bit to 1
                setF(flag);
            }
            else
            {
                byte flag = getF();
                flag &= 0x7F; //Sets left most bit to 0
                setF(flag);
            }
        }

        public bool getZFlag()
        {
            byte flag = getF();
            if (((flag & 0x80) >> 7) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void toggleNFlag()
        {
            byte flag = getF();
            flag ^= 0x40; //Toggles second to left most bit
            setF(flag);
        }

        public void setNFlag(bool setting)
        {
            if (setting)
            {
                byte flag = getF();
                flag |= 0x40; //Sets second to left most bit to 1
                setF(flag);
            }
            else
            {
                byte flag = getF();
                flag &= 0xBF; //Sets second to left most bit to 0
                setF(flag);
            }
        }

        public bool getNFlag()
        {
            byte flag = getF();
            if (((flag & 0x40) >> 6) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void toggleHFlag()
        {
            byte flag = getF();
            flag ^= 0x20; //Toggles third to left most bit
            setF(flag);
        }

        public void setHFlag(bool setting)
        {
            if (setting)
            {
                byte flag = getF();
                flag |= 0x20; //Sets third to left most bit to 1
                setF(flag);
            }
            else
            {
                byte flag = getF();
                flag &= 0xDF; //Sets third to left most bit to 0
                setF(flag);
            }
        }

        public bool getHFlag()
        {
            byte flag = getF();
            if (((flag & 0x20) >> 5) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void toggleCFlag()
        {
            byte flag = getF();
            flag ^= 0x10; //Toggles fourth to left most bit
            setF(flag);
        }

        public void setCFlag(bool setting)
        {
            if (setting)
            {
                byte flag = getF();
                flag |= 0x10; //Sets fourth to left most bit to 1
                setF(flag);
            }
            else
            {
                byte flag = getF();
                flag &= 0xEF; //Sets fourth to left most bit to 0
                setF(flag);
            }
        }

        public bool getCFlag()
        {
            byte flag = getF();
            if (((flag & 0x10) >> 4) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public byte getA()
        {
            return (byte)((regAF & 0xFF00) >> 8);
        }

        public byte getF()
        {
            return (byte)(regAF & 0x00FF);
        }

        public short getAF()
        {
            return regAF;
        }

        public byte getB()
        {
            return (byte)((regBC & 0xFF00) >> 8);
        }

        public byte getC()
        {
            return (byte)(regBC & 0x00FF);
        }

        public short getBC()
        {
            return regBC;
        }

        public byte getD()
        {
            return (byte)((regDE & 0xFF00) >> 8);
        }

        public byte getE()
        {
            return (byte)(regDE & 0x00FF);
        }

        public short getDE()
        {
            return regDE;
        }

        public byte getH()
        {
            return (byte)((regHL & 0xFF00) >> 8);
        }

        public byte getL()
        {
            return (byte)(regHL & 0x00FF);
        }

        public short getHL()
        {
            return regHL;
        }

        public void setA(byte newA)
        {
            regAF = (short)(regAF & 0x00FF);
            regAF |= (short)(newA << 8);
        }

        public void setF(byte newF)
        {
            regAF = (short)(regAF & 0xFF00);
            regAF |= newF;
        }

        public void setAF(short newAF)
        {
            regAF = (short)(newAF & 0xFFF0);
        }

        public void setB(byte newB)
        {
            regBC = (short)(regBC & 0x00FF);
            regBC |= (short)(newB << 8);
        }

        public void setC(byte newC)
        {
            regBC = (short)(regBC & 0xFF00);
            regBC |= newC;
        }

        public void setBC(short newBC)
        {
            regBC = newBC;
        }

        public void setD(byte newD)
        {
            regDE = (short)(regDE & 0x00FF);
            regDE |= (short)(newD << 8);
        }

        public void setE(byte newE)
        {
            regDE = (short)(regDE & 0xFF00);
            regDE |= newE;
        }

        public void setDE(short newDE)
        {
            regDE = newDE;
        }

        public void setH(byte newH)
        {
            regHL = (short)(regHL & 0x00FF);
            regHL |= (short)(newH << 8);
        }

        public void setL(byte newL)
        {
            regHL = (short)(regHL & 0xFF00);
            regHL |= newL;
        }

        public void setHL(short newHL)
        {
            regHL = newHL;
        }

        public byte getLCDControl()
        {
            return readMemory(0xFF40);
        }

        public bool getLCDEnabled()
        {
            return (((getLCDControl() & 0x80) >> 7) > 0); //Bit 7
        }

        public byte getLCDLY()
        {
            return readMemory((ushort)0xFF44);
        }

        public void setLCDLY(byte newLY)
        {
            writeMemory((ushort)0xFF44, newLY);
        }

        public void setStackPointer(ushort nn)
        {
            stackPointer = (short)nn;
        }

        public void clearRegistersFlagsAndMemory()
        {
            setAF(0x0000);
            setBC(0x0000);
            setDE(0x0000);
            setHL(0x0000);
            setStackPointer((ushort)0x0000);
            
            for(int i = 0; i < ramMap.Length; i++)
            {
                ramMap[i] = 0;
            }
        }

        public void clearRegistersAndFlags()
        {
            setAF(0x0000);
            setBC(0x0000);
            setDE(0x0000);
            setHL(0x0000);
            setStackPointer((ushort)0x0000);
        }

        public void initializeGameBoyValues()
        {

            setAF(0x01B0);
            setBC(0x013);
            setDE(0x0D8);
            setHL(0x14D);
            setStackPointer((ushort)0xFFFE);

            Random random1 = new Random();
            for (ushort i = 0xC000; i <= 0xDFFF; i++)
            {
                byte randNum = (byte)random1.Next(0xFF);
                writeMemory(i, randNum);
            }

            //Initialize High Ram (0xFFFF is not a part of high ram)
            for (ushort i = 0xFF80; i < 0xFFFF; i++)
            {
                byte randNum = (byte)random1.Next(0xFF);
                writeMemory(i, randNum);
            }

            ramMap[(ushort)0xFF00] = ((byte)0xCF); //Joypad
            ramMap[(ushort)0xFF04] = ((byte)0xAB);
            ramMap[(ushort)0xFF05] = ((byte)0x00); //TIMA
            ramMap[(ushort)0xFF06] = ((byte)0x00); //TMA
            ramMap[(ushort)0xFF07] = ((byte)0x00); //TAC
            ramMap[(ushort)0xFF0F] = ((byte)0xE1); //IF
            ramMap[(ushort)0xFF10] = ((byte)0x80); //NR10
            ramMap[(ushort)0xFF11] = ((byte)0xBF); //NR11
            ramMap[(ushort)0xFF12] = ((byte)0xF3); //NR12
            ramMap[(ushort)0xFF14] = ((byte)0xBF); //NR14
            ramMap[(ushort)0xFF16] = ((byte)0x3F); //NR21
            ramMap[(ushort)0xFF17] = ((byte)0x00); //NR22
            ramMap[(ushort)0xFF19] = ((byte)0xBF); //NR24
            ramMap[(ushort)0xFF1A] = ((byte)0x7F); //NR30
            ramMap[(ushort)0xFF1B] = ((byte)0xFF); //NR31
            ramMap[(ushort)0xFF1C] = ((byte)0x9F); //NR32
            ramMap[(ushort)0xFF1E] = ((byte)0xBF); //NR33
            ramMap[(ushort)0xFF20] = ((byte)0xFF); //NR41
            ramMap[(ushort)0xFF21] = ((byte)0x00); //NR42
            ramMap[(ushort)0xFF22] = ((byte)0x00); //NR43
            ramMap[(ushort)0xFF23] = ((byte)0xBF); //NR30
            ramMap[(ushort)0xFF24] = ((byte)0x77); //NR50
            ramMap[(ushort)0xFF25] = ((byte)0xF3); //NR51
            ramMap[(ushort)0xFF26] = ((byte)0xF1); //NR52 //F1 for GB //F0 for SGB
            ramMap[(ushort)0xFF40] = ((byte)0x91); //LCD Ctrl
            ramMap[(ushort)0xFF41] = ((byte)0x85); //LCD Status
            ramMap[(ushort)0xFF42] = ((byte)0x00); //SCY
            ramMap[(ushort)0xFF43] = ((byte)0x00); //SCX
            ramMap[(ushort)0xFF44] = ((byte)0x00); //LY
            ramMap[(ushort)0xFF45] = ((byte)0x00); //LYC
            ramMap[(ushort)0xFF47] = ((byte)0xFC); //BGP
            ramMap[(ushort)0xFF48] = ((byte)0xFF); //OBP0
            ramMap[(ushort)0xFF49] = ((byte)0xFF); //0BP1
            ramMap[(ushort)0xFF4A] = ((byte)0x00); //WY
            ramMap[(ushort)0xFF4B] = ((byte)0x00); //WX
            ramMap[(ushort)0xFFFF] = ((byte)0x00); //IE


        }

        public void initializeGameBoyColorValues()
        {

            setA(0x11); //AF: 0x1180
            setF(0x80);
            setB(0x00); //BC: 0x0000
            setC(0x00);
            setD(0xFF); //DE: 0xFF56
            setE(0x56);
            setH(0x00); //HL: 0x000D
            setL(0x0D);
            setStackPointer((ushort)0xFFFE);

            Random random1 = new Random();
            for (ushort i = 0xC000; i <= 0xDFFF; i++)
            {
                byte randNum = (byte)random1.Next(0xFF);
                writeMemory(i, randNum);
            }

            //Initialize High Ram (0xFFFF is not a part of high ram)
            for (ushort i = 0xFF80; i < 0xFFFF; i++)
            {
                byte randNum = (byte)random1.Next(0xFF);
                writeMemory(i, randNum);
            }

            ramMap[(ushort)0xFF00] = ((byte)0xCF); //Joypad
            ramMap[(ushort)0xFF04] = ((byte)0xAB);
            ramMap[(ushort)0xFF05] = ((byte)0x00); //TIMA
            ramMap[(ushort)0xFF06] = ((byte)0x00); //TMA
            ramMap[(ushort)0xFF07] = ((byte)0x00); //TAC
            ramMap[(ushort)0xFF0F] = ((byte)0xE1); //IF
            ramMap[(ushort)0xFF10] = ((byte)0x80); //NR10
            ramMap[(ushort)0xFF11] = ((byte)0xBF); //NR11
            ramMap[(ushort)0xFF12] = ((byte)0xF3); //NR12
            ramMap[(ushort)0xFF14] = ((byte)0xBF); //NR14
            ramMap[(ushort)0xFF16] = ((byte)0x3F); //NR21
            ramMap[(ushort)0xFF17] = ((byte)0x00); //NR22
            ramMap[(ushort)0xFF19] = ((byte)0xBF); //NR24
            ramMap[(ushort)0xFF1A] = ((byte)0x7F); //NR30
            ramMap[(ushort)0xFF1B] = ((byte)0xFF); //NR31
            ramMap[(ushort)0xFF1C] = ((byte)0x9F); //NR32
            ramMap[(ushort)0xFF1E] = ((byte)0xBF); //NR33
            ramMap[(ushort)0xFF20] = ((byte)0xFF); //NR41
            ramMap[(ushort)0xFF21] = ((byte)0x00); //NR42
            ramMap[(ushort)0xFF22] = ((byte)0x00); //NR43
            ramMap[(ushort)0xFF23] = ((byte)0xBF); //NR30
            ramMap[(ushort)0xFF24] = ((byte)0x77); //NR50
            ramMap[(ushort)0xFF25] = ((byte)0xF3); //NR51
            ramMap[(ushort)0xFF26] = ((byte)0xF1); //NR52 //F1 for GB //F0 for SGB
            ramMap[(ushort)0xFF40] = ((byte)0x91); //LCD Ctrl
            ramMap[(ushort)0xFF41] = ((byte)0x85); //LCD Status
            ramMap[(ushort)0xFF42] = ((byte)0x00); //SCY
            ramMap[(ushort)0xFF43] = ((byte)0x00); //SCX
            ramMap[(ushort)0xFF44] = ((byte)0x00); //LY
            ramMap[(ushort)0xFF45] = ((byte)0x00); //LYC
            ramMap[(ushort)0xFF47] = ((byte)0xFC); //BGP
            ramMap[(ushort)0xFF48] = ((byte)0xFF); //OBP0
            ramMap[(ushort)0xFF49] = ((byte)0xFF); //0BP1
            ramMap[(ushort)0xFF4A] = ((byte)0x00); //WY
            ramMap[(ushort)0xFF4B] = ((byte)0x00); //WX
            ramMap[(ushort)0xFFFF] = ((byte)0x00); //IE


        }

        bool loadSaveFile(string filepath)
        {
            byte[] saveFile = File.ReadAllBytes(filepath);

            if (saveFile != null)
            {
                int fileLength = saveFile.Length;

                if (fileLength >= 0x2000)
                {
                    ushort address = 0xA000;
                    for (ushort i = 0x0; i <= 0x1FFF; i++)
                    {
                        ramMap[address + i] = saveFile[i];
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Error: Save file does not exist.");
                return false;
            }

            return true;
        }

        public byte[] returnSaveDataFromMemory()
        {
            byte[] memory = new byte[0x2000];

            ushort address = 0xA000;
            for(int i = 0; i <= 0x1FFF; i++)
            {
                memory[i] = ramMap[address + i];
            }

            return memory;
        }

        public bool createSaveFile(string fileName, bool overwrite)
        {
            /*
            00 Rom only | 01 MBC1 | 02 MBC1 + Ram | 03 MBC1 + Ram + Battery | 05 MBC2 | 06 MBC2 + Battery | 08 Rom + Ram |
            09 Rom + Ram + Battery | 0B MMM01 | 0C MMM01 + Ram | 0D MMM01 + Ram + Battery | 11 MBC3 | 12 MBC3 + Ram |
            13 MBC3 + Ram + Battery | 19 MBC5 | 1A MBC5 + Ram | 1B MBC5 + Ram + Battery | 1C MBC5 + Rumble | 1D MBC5 + Rumble + Ram |
            1E MBC5 + Rumble + Ram + Battery | 20 MBC6 | 22 MBC7 + Sensor + Rumble + Ram + Battery | FC Pocket Camera |
            FD Bandai Tama5 | FE HuC3 | FF HuC1 + Ram + Battery |
            */

            bool romUsesRam = Core.rom.cartridgeType == 0x02 || Core.rom.cartridgeType == 0x03 || Core.rom.cartridgeType == 0x06 || Core.rom.cartridgeType == 0x08 || Core.rom.cartridgeType == 0x09 || Core.rom.cartridgeType == 0x0C || Core.rom.cartridgeType == 0x0D
                || Core.rom.cartridgeType == 0x12 || Core.rom.cartridgeType == 0x13 || Core.rom.cartridgeType == 0x1A || Core.rom.cartridgeType == 0x1B || Core.rom.cartridgeType == 0x1D || Core.rom.cartridgeType == 0x1E || Core.rom.cartridgeType == 0x22 || Core.rom.cartridgeType == 0xFF;

            if (romUsesRam)
            {
                byte[] saveData = returnSaveDataFromMemory();

                string savePath = Core.rom.romFilePath.Substring(0, Core.rom.romFilePath.LastIndexOf('.')) + ".sav";
                bool fileExists = File.Exists(savePath);

                if (!fileExists || overwrite)
                {
                    File.WriteAllBytes(savePath, saveData);
                    return true;
                }
            }

            return false;
        }
   
        void saveState()
        {
            
            string path = AppDomain.CurrentDomain.BaseDirectory;

            StreamWriter file = new StreamWriter(Path.Combine(path, "save1.egg"));

            file.WriteLine("[Title:]" + Core.rom.title);
            file.WriteLine("[MBC:]" + Core.rom.mapperSetting.ToString("X"));
            file.WriteLine("[Rom Bank:]" + Core.rom.romBankNumber.ToString("X"));
            file.WriteLine("[Ram Bank:]" + Core.rom.ramBankNumber.ToString("X"));
            file.WriteLine("[AF:]" + (regAF).ToString("X"));
            file.WriteLine("[BC:]" + (regBC).ToString("X"));
            file.WriteLine("[DE:]" + (regDE).ToString("X"));
            file.WriteLine("[HL:]" + (regHL).ToString("X"));
            file.WriteLine("[PC:]" + (memoryPointer).ToString("X"));
            file.WriteLine("[SP:]" + (stackPointer).ToString("X"));
            file.WriteLine("[Halt:]" + Convert.ToInt32(Core.beakCPU.returnHalt()).ToString("X"));
            file.WriteLine("[Interrupt:]" + Convert.ToInt32(Core.beakCPU.returnInterrupt()).ToString("X"));
            file.WriteLine("[PendingIMESet:]" + Convert.ToInt32(Core.enableInterruptsNextCycle).ToString("X"));
            file.WriteLine("[IME:]" + Convert.ToInt32(Core.beakCPU.returnIME()).ToString("X"));
            file.WriteLine("[Repeat:]" + Convert.ToInt32(Core.beakCPU.returnRepeat()).ToString("X"));
            file.WriteLine("[Clocks:]" + (Core.clocks).ToString("X"));
            file.WriteLine("[GPUMode:]" + (Core.beakWindow.gpuMode).ToString("X"));
            file.Write("[Memory:]");

            for (int i = 0x8000; i <= 0xFFFF; i++)
            {
                byte ram = ramMap[i];

                file.Write(ramMap[i].ToString("X") + ';');
            }

            file.Close();

        }
        
        void loadSaveState()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "save1.egg");



            if(File.Exists(path))
            {
                StreamReader eggStreamReader = new StreamReader(path);

                string line;
                List<byte> colorValues = new List<byte>();

                bool quit = false;
                bool setRomBank = false;
                bool setRamBank = false;

                while (!eggStreamReader.EndOfStream && !quit)
                {
                    line = eggStreamReader.ReadLine();

                    if (line.Contains("[Title:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;

                        line = line.Substring(last, line.Length - last);

                        if (Core.rom.title != line)
                        {
                            quit = true;
                        }
                    }
                    else if (line.Contains("[MBC:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last - 2);


                        uint mbc = Convert.ToUInt32(line, 16);

                        switch (mbc)
                        {
                            case 1:
                            case 2:
                            case 3:
                                {
                                    //MBC1
                                    setRomBank = true;
                                    setRamBank = true;
                                    break;
                                }
                            case 5:
                            case 6:
                                {
                                    //MBC2
                                    setRomBank = true;
                                    break;
                                }
                            //case 0x0B:
                            //case 0x0C:
                            //case 0x0D:
                            case 0x11:
                            case 0x12:
                            case 0x13:
                                {
                                    //MBC3
                                    setRomBank = true;
                                    setRamBank = true;
                                    break;
                                }
                            case 0x19:
                            case 0x1A:
                            case 0x1B:
                            case 0x1C:
                            case 0x1D:
                            case 0x1E:
                                {
                                    //MBC5
                                    setRomBank = true;
                                    setRamBank = true;
                                    break;
                                }
                                //case 0x20:
                                //case 0x22:
                                //case 0xFD:
                                //case 0xFE:
                                //case 0xFF:


                        }


                    }
                    else if (line.Contains("[Rom Bank:]"))
                    {
                        if (setRomBank == true)
                        {
                            int last = line.LastIndexOf(']') + 1;
                            line = line.Substring(last, line.Length - last - 2);

                            uint romBank = Convert.ToUInt32(line, 16);

                            //Change Rom Bank based on which memory controller it is
                            switch (Core.rom.mapperSetting)
                            {
                                case 1:
                                case 2:
                                case 3:
                                    {
                                        //MBC1
                                        Mappers.MBC1.changeMBC1RomBanks((ushort)romBank);
                                        break;
                                    }
                                case 5:
                                case 6:
                                    {
                                        //MBC2
                                        Mappers.MBC2.changeMBC2RomBanks((ushort)romBank);
                                        break;
                                    }
                                //case 0x0B:
                                //case 0x0C:
                                //case 0x0D:
                                case 0x11:
                                case 0x12:
                                case 0x13:
                                    {
                                        //MBC3
                                        Mappers.MBC3.changeMBC3RomBanks((ushort)romBank);
                                        break;
                                    }
                                case 0x19:
                                case 0x1A:
                                case 0x1B:
                                case 0x1C:
                                case 0x1D:
                                case 0x1E:
                                    {
                                        //MBC5
                                        Mappers.MBC5.changeMBC5RomBanks((ushort)romBank);
                                        break;
                                    }
                            }
                        }
                    }
                    else if (line.Contains("[Ram Bank:]"))
                    {
                        if (setRamBank == true)
                        {
                            int last = line.LastIndexOf(']') + 1;
                            line = line.Substring(last, line.Length - last);

                            uint ramBank = Convert.ToUInt32(line, 16);


                            Mappers.Mapper.changeRamBanks((ushort)ramBank);
                        }
                    }
                    else if (line.Contains("[AF:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        uint af = Convert.ToUInt32(line, 16);

                        setAF((short)af);
                    }
                    else if (line.Contains("[BC:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        uint bc = Convert.ToUInt32(line, 16);

                        setBC((short)bc);
                    }
                    else if (line.Contains("[DE:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        uint de = Convert.ToUInt32(line, 16);

                        setDE((short)de);
                    }
                    else if (line.Contains("[HL:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        uint hl = Convert.ToUInt32(line, 16);

                        setHL((short)hl);
                    }
                    else if (line.Contains("[PC:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        uint pc = Convert.ToUInt32(line, 16);

                        memoryPointer = (short)pc;
                    }
                    else if (line.Contains("[SP:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        uint sp = Convert.ToUInt32(line, 16);

                        stackPointer = (short)sp;
                    }
                    else if (line.Contains("[HALT:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        uint halt = Convert.ToUInt32(line, 16);

                        Core.beakCPU.setHalt(halt > 0);
                    }
                    else if (line.Contains("[Interrupt:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        uint interruptVal = Convert.ToUInt32(line, 16);

                        Core.beakCPU.setInterrupt(interruptVal > 0);
                    }
                    else if (line.Contains("[PendingIMESet:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        uint imeSet = Convert.ToUInt32(line, 16);

                        Core.enableInterruptsNextCycle = (imeSet > 0);
                    }
                    else if (line.Contains("[IME:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        uint ime = Convert.ToUInt32(line, 16);

                        Core.beakCPU.setIME(ime > 0);
                    }
                    else if (line.Contains("[Repeat:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        uint repeat = Convert.ToUInt32(line, 16);

                        Core.beakCPU.setRepeat(repeat > 0);
                    }
                    else if (line.Contains("[Clocks:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        uint clocksVal = Convert.ToUInt32(line, 16);

                        Core.clocks = (int)clocksVal;
                    }
                    else if (line.Contains("[GPUMode:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        uint gpuMode = Convert.ToUInt32(line, 16);

                        Core.beakWindow.gpuMode = (int)gpuMode;
                    }
                    else if (line.Contains("[Memory:]"))
                    {
                        int last = line.LastIndexOf(']') + 1;
                        line = line.Substring(last, line.Length - last);

                        for (int i = 0x8000; i <= 0xFFFF; i++)
                        {
                            int nextDelimiter = line.IndexOf(';');
                            Core.beakMemory.ramMap[i] = Convert.ToByte(line.Substring(0, nextDelimiter), 16);
                            line = line.Substring(nextDelimiter + 1, line.Length - (nextDelimiter + 1));
                        }
                    }
                }
            }
            //paused = true;
        }

    }
}
