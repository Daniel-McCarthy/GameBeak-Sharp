using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace GameBeak_Frontend.Classes
{
    class Memory
    {
        private byte[] ramMap = new byte[0x10000];
        private byte[] externalRam = new byte[0x1E000];
        private byte[] rom = new byte[0x500000];
        private string title = "";
        private bool ramEnabled = false;
        private ushort romBankNumber = 0;
        private ushort ramBankNumber = 0; //originally byte
        private bool bankingMode = false; //0: Rom 1: Ram
        private int memoryControllerMode = 0;

        private short regAF = 0;
        private short regBC = 0;
        private short regDE = 0;
        private short regHL = 0;

        public ushort stackPointer = 0;
        public ushort memoryPointer = 0;


        public void readRomHeader()
        {

            for (int i = 0; i < 16; i++)
            {
                title += (char)rom[0x134 + i];
            }

            //0x147 Catridge type
            /*
            00 Rom only | 01 MBC1 | 02 MBC1 + Ram | 03 MBC1 + Ram + Battery | 05 MBC2 | 06 MBC2 + Battery | 08 Rom + Ram |
            09 Rom + Ram + Battery | 0B MMM01 | 0C MMM01 + Ram | 0D MMM01 + Ram + Battery | 11 MBC3 | 12 MBC3 + Ram |
            13 MBC3 + Ram + Battery | 19 MBC5 | 1A MBC5 + Ram | 1B MBC5 + Ram + Battery | 1C MBC5 + Rumble | 1D MBC5 + Rumble + Ram |
            1E MBC5 + Rumble + Ram + Battery | 20 MBC6 | 22 MBC7 + Sensor + Rumble + Ram + Battery | FC Pocket Camera |
            FD Bandai Tama5 | FE HuC3 | FF HuC1 + Ram + Battery |
            */

            byte cartridgeType = rom[0x147];
            byte romSize = rom[0x148];
            memoryControllerMode = cartridgeType;
            if (memoryControllerMode == 0)
            {
                //None
                writeFullRomToRam();
            }
            else if (memoryControllerMode <= 3)
            {
                //MBC1
                writeRom0ToRam();

                changeMBC1RomBanks(1);
            }
            else if (memoryControllerMode <= 6)
            {
                //MBC2
                writeRom0ToRam();

                changeMBC2RomBanks(1);
            }
            else if (memoryControllerMode <= 9)
            {
                //8: Rom+Ram
                //9: Rom+Ram+Battery

                writeFullRomToRam();
            }
            else if (memoryControllerMode <= 0x0D)
            {
                //0B: MMM01
                //0C: MMM01+Ram
                //0D: MMM01+Ram+Battery

                writeRom0ToRam();
            }
            else if (memoryControllerMode <= 0x10)
            {
                //0F: MBC3+Timer+Battery
                //10: MBC3+Timer+Ram+Battery
                //11: MBC3
                //12: MBC3+Ram
                //13: MBC3+Ram+Battery

                writeRom0ToRam();

                changeMBC3RomBanks(1);
            }
            else if (memoryControllerMode <= 0x1E)
            {

                writeRom0ToRam();

                changeMBC5RomBanks(1);
            }
            else
            {

                writeFullRomToRam();
                //writeRom0ToRam();
            }

        }


        public bool loadRom(string path)
        {
            if (File.Exists(path))
            {
                byte[] romFile = File.ReadAllBytes(path);

                if (romFile != null && romFile.Length > 0)
                {
                    if (romFile.Length <= 0x500000)
                    {
                        for (int i = 0; i < romFile.Length; i++)
                        {
                            rom[i] = rom[i];
                        }
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
                    for (int i = 0; i < romFile.Length; i++)
                    {
                        rom[i] = romFile[i];
                    }
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






        public void writeRom0ToRam()
        {
            for (int i = 0; i < 0x3FFF; i++)
            {
                ramMap[i] = rom[i];
            }
        }

        public void writeFullRomToRam()
        {
            for (int i = 0; i < 0x7FFF; i++)
            {
                ramMap[i] = rom[i];
            }
        }

        public void changeMBC1RomBanks(ushort bankNumber)
        {
            if (bankNumber == 0)
            {
                bankNumber++;
            }

            if ((bankNumber >= 0) && (bankNumber <= 0x1F))
            {

                int bankAddress = 0x4000 * bankNumber;

                int fixedBankAddress = 0x4000;
                for (int i = 0; i < 0x4000; i++)
                {
                    ramMap[fixedBankAddress + i] = rom[bankAddress + i];
                }

                romBankNumber = bankNumber;
            }
        }

        public void changeMBC2RomBanks(ushort bankNumber)
        {
            if (bankNumber == 0)
            {
                bankNumber++;
            }

            if ((bankNumber >= 0) && (bankNumber <= 0x0F))
            {

                int bankAddress = 0x4000 * bankNumber;

                int fixedBankAddress = 0x4000;
                for (int i = 0; i < 0x4000; i++)
                {
                    ramMap[fixedBankAddress + i] = rom[bankAddress + i];
                }

                romBankNumber = bankNumber;
            }
        }

        public void changeMBC3RomBanks(ushort bankNumber)
        {
            if (bankNumber == 0)
            {
                bankNumber++;
            }

            if ((bankNumber >= 0) && (bankNumber <= 0x7F))
            {

                int bankAddress = 0x4000 * bankNumber;

                int fixedBankAddress = 0x4000;
                for (int i = 0; i < 0x4000; i++)
                {
                    ramMap[fixedBankAddress + i] = rom[bankAddress + i];
                }

                romBankNumber = bankNumber;
            }
        }

        public void changeMBC5RomBanks(ushort bankNumber)
        {
            if ((bankNumber >= 0) && (bankNumber <= 0x1FF))
            {

                int bankAddress = 0x4000 * bankNumber;

                int fixedBankAddress = 0x4000;
                for (int i = 0; i < 0x4000; i++)
                {
                    ramMap[fixedBankAddress + i] = rom[bankAddress + i];
                }

                romBankNumber = bankNumber;
            }
        }

        public void changeRamBanks(ushort bankNumber)
        {
            ushort externalAddress = (ushort)(ramBankNumber * (short)0x2000);

            //Save Old Beak Ram Data to External Ram Array
            for (int i = 0; i < 0x2000; i++)
            {
                externalRam[externalAddress + i] = ramMap[0xA000 + i];
            }

            ramBankNumber = bankNumber;
            externalAddress = (ushort)(ramBankNumber * 0x2000);

            //Load New External Ram data to Beak Ram
            for (int i = 0; i < 0x2000; i++)
            {
                ramMap[0xA000 + i] = externalRam[externalAddress + i];
            }

        }

        public void writeMBC1Value(ushort address, byte value)
        {
            if (address >= 0x0000 && address <= 0x1FFF)
            {
                //Ram Enable/Disable
                if ((value & 0x0F) == 0x0A)
                {
                    //Enable Ram
                    ramEnabled = true;
                }
                else
                {
                    //Disable Ram
                    ramEnabled = false;
                }
            }
            else if (address >= 0x2000 && address <= 0x3FFF)
            {
                //Set Rom Bank Number 5 bits
                byte newBankNumber = (byte)((romBankNumber & 0xE0) | (value & 0x1F));

                if (romBankNumber != newBankNumber)
                {
                    changeMBC1RomBanks(newBankNumber);
                }

            }
            else if (address >= 0x4000 && address <= 0x5FFF)
            {
                //Set Ram Bank Number /OR/ Set Rom Bank Number 2 bits
                if (!bankingMode)
                {
                    //Change Rom Bank
                    byte newBankNumber = (byte)((romBankNumber & 0x1F) | ((value & 0x03) << 5));
                    if (romBankNumber != newBankNumber)
                    {
                        changeMBC1RomBanks(newBankNumber);
                    }
                }
                else
                {
                    //Change Ram Bank
                    byte newBankNumber = (byte)(value & 0x03);

                    if (ramBankNumber != newBankNumber)
                    {
                        changeRamBanks(newBankNumber);
                    }
                }

            }
            else if (address >= 0x6000 && address <= 0x7FFF)
            {
                //Rom Banking / Ram Banking Mode
                if ((value & 0x01) > 0)
                {
                    bankingMode = true;
                }
                else
                {
                    bankingMode = false;
                }
            }

        }

        public void writeMBC2Value(ushort address, byte value)
        {
            if (address >= 0x0000 && address <= 0x1FFF)
            {
                //Ram Enable/Disable
                if ((value & 0x0F) == 0x0A)
                {
                    //Enable Ram
                    ramEnabled = true;
                }
                else
                {
                    //Disable Ram
                    ramEnabled = false;
                }
            }
            else if (address >= 0x2000 && address <= 0x3FFF)
            {
                //Set Rom Bank Number 5 bits
                byte newBankNumber = (byte)(value & 0x0F);

                if (romBankNumber != newBankNumber)
                {
                    changeMBC2RomBanks(newBankNumber);
                }

            }
        }

        public void writeMBC3Value(ushort address, byte value)
        {
            if (address >= 0x0000 && address <= 0x1FFF)
            {
                //Ram/RTC Register  Enable/Disable
                if ((value & 0x0F) == 0x0A)
                {
                    //Enable Ram
                    ramEnabled = true;
                }
                else
                {
                    //Disable Ram
                    ramEnabled = false;
                }
            }
            else if (address >= 0x2000 && address <= 0x3FFF)
            {
                //Set Rom Bank Number 7 bits
                byte newBankNumber = (byte)(value & 0x7F);

                if (romBankNumber != newBankNumber)
                {
                    changeMBC3RomBanks(newBankNumber);
                }

            }
            else if (address >= 0x4000 && address <= 0x5FFF)
            {
                //Set Ram Bank Number /OR/ RTC Register Select

                if ((value >= 0) && (value <= 3))
                {
                    //Change Ram Bank
                    byte newBankNumber = (byte)(value & 0x03);

                    if (ramBankNumber != newBankNumber)
                    {
                        changeRamBanks(newBankNumber);
                    }
                }

                if ((value >= 8) && (value <= 0x0C))
                {
                    //RTC Register Select

                    //Todo: Implement this
                }

            }
            else if (address >= 0x6000 && address <= 0x7FFF)
            {
                //Latch Clock Write
                //if ((previousRTCWrite == 0) && (value == 1))
                if (value == 1)
                {
                    //Update RTC registers

                    //LPSYSTEMTIME time;
                    //GetSystemTime(time);


                    /*
                    08h  RTC S   Seconds   0-59 (0-3Bh)
                    09h  RTC M	Minutes   0-59 (0-3Bh)
                    0Ah  RTC H	Hours     0-23 (0-17h)
                    0Bh  RTC DL	Lower 8 bits of Day Counter (0-FFh)
                    0Ch  RTC DH	Upper 1 bit of Day Counter, Carry Bit, Halt Flag
                    Bit 0	Most significant bit of Day Counter (Bit 8)
                    Bit 6	Halt (0=Active, 1=Stop Timer)
                    Bit 7	Day Counter Carry Bit (1=Counter Overflow)

                    The Halt Flag is supposed to be set before <writing> to the RTC Registers.
                    */

                }
                //Todo: Implement this
            }

        }

        public void writeMBC5Value(ushort address, byte value)
        {
            if (address >= 0x0000 && address <= 0x1FFF)
            {
                //Ram Enable/Disable
                if ((value & 0x0F) == 0x0A)
                {
                    //Enable Ram
                    ramEnabled = true;
                }
                else
                {
                    //Disable Ram
                    ramEnabled = false;
                }
            }
            else if (address >= 0x2000 && address <= 0x2FFF)
            {
                //Set Low 8 bits of Rom Bank Number
                byte newBankNumber = (byte)((romBankNumber & 0x100) | (value)); //Keeps the 9th bit of current rom bank number, joins entire value.

                if (romBankNumber != newBankNumber)
                {
                    changeMBC5RomBanks(newBankNumber);
                }

            }
            else if (address >= 0x3000 && address <= 0x3FFF)
            {
                //Set the 9th bit of Rom Bank Number
                if (value > 0) //Ensure we are only setting 1 bit to newBankNumber
                {
                    value = 1;
                }

                byte newBankNumber = (byte)((romBankNumber & 0xFF) | (value << 8));

                if (romBankNumber != newBankNumber)
                {
                    changeMBC5RomBanks(newBankNumber);
                }

            }
            else if (address >= 0x4000 && address <= 0x5FFF)
            {
                //Set Ram Bank Number
                if (bankingMode)
                {
                    //Change Ram Bank
                    byte newBankNumber = (byte)(value & 0x0F);

                    if (ramBankNumber != newBankNumber)
                    {
                        changeRamBanks(newBankNumber);
                    }
                }

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

        public bool writeMemory(ushort address, byte value)
        {
            if (memoryControllerMode > 0 && address <= 0x7FFF)
            {
                if (memoryControllerMode <= 3)
                {
                    writeMBC1Value(address, value);
                }
                else if (memoryControllerMode <= 6)
                {
                    writeMBC2Value(address, value);
                }
                else if (memoryControllerMode <= 9)
                {
                    //8: Rom+Ram
                    //9: Rom+Ram+Battery
                }
                else if (memoryControllerMode <= 0x0D)
                {
                    //0B: MMM01
                    //0C: MMM01+Ram
                    //0D: MMM01+Ram+Battery
                }
                else if (memoryControllerMode <= 0x10)
                {
                    //0F: MBC3+Timer+Battery
                    //10: MBC3+Timer+Ram+Battery
                    //11: MBC3
                    //12: MBC3+Ram
                    //13: MBC3+Ram+Battery

                    //Add this later: MBC3 is not currently ready (RTC)
                    writeMBC3Value(address, value);
                }
                else if (memoryControllerMode <= 0x1E)
                {
                    writeMBC5Value(address, value);
                }
                //TODO: Add more MBC controllers

                return true;
            }
            else
            {
                if (address >= 0x8000 && address <= 0xFFFF)
                {
                    if (address == (ushort)0xFF46)
				    {
                        //Initiate DMA Transfer Register
                        transferDMA(value);
                        return true;
                    }
				    else if (address == (ushort)0xFF41)
				    {
                        //Set LCDC Status
                        ramMap[address] = (byte)((ramMap[address] & 0x87) | (value & 0x78) | 0x80); //Bit 7 is always 1, Bit 0, 1, and 2 are read Only
                        return true;                                                                 //&0x87 clears bits 3, 4, 5, 6 from Stat. &0xF8 clears all but bit bit 0, 1, 2, and 7 from value being written.
                    }
				    else if (address == (ushort)0xFF68)
				    {
                        //Set GBC Background Palette Index
                        ramMap[address] = (byte)(0x40 | (value));
                        //Bit 7: Increment on Write //Bit 6: Unused //Bit 5-0 Index (0-35)
                        return true;
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

                        if (ramMap[address] == value)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
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
            for (ushort i = 0xC000; i < 0xDFFF; i ++)
            {
                byte randNum = (byte)random1.Next(0xFF);

                for (int j = 0; j < 2; j++)
                {
                    if (i < 0xDFFF)
                    {
                        writeMemory(i, randNum);
                        randNum >>= 8;
                    }
                }
            }

            for (ushort i = 0xFF80; i < 0xFFFE; i += 2)
            {
                byte randNum = (byte)random1.Next(0xFF);

                for (int j = 0; j < 2; j++)
                {
                    if (i < 0xFFFE)
                    {
                        writeMemory(i, randNum);
                        randNum >>= 8;
                    }
                }
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

    }
}
