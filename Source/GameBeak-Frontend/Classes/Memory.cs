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
        private string title;
        private bool ramEnabled = false;
        private ushort romBankNumber = 0;
        private ushort ramBankNumber = 0; //originally byte
        private bool bankingMode = false; //0: Rom 1: Ram
        private int memoryControllerMode = 0;

        private short regAF = 0;
        private short regBC = 0;
        private short regDE = 0;
        private short regHL = 0;

        private ushort stackPointer = 0;
        private ushort memoryPointer = 0;


        void readRomHeader()
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


        bool loadRom(string path)
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




        void writeRom0ToRam()
        {
            for (int i = 0; i < 0x3FFF; i++)
            {
                ramMap[i] = rom[i];
            }
        }

        void writeFullRomToRam()
        {
            for (int i = 0; i < 0x7FFF; i++)
            {
                ramMap[i] = rom[i];
            }
        }

        void changeMBC1RomBanks(ushort bankNumber)
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

        void changeMBC2RomBanks(ushort bankNumber)
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

        void changeMBC3RomBanks(ushort bankNumber)
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

        void changeMBC5RomBanks(ushort bankNumber)
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

        void changeRamBanks(ushort bankNumber)
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

        void writeMBC1Value(ushort address, byte value)
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

        void writeMBC2Value(ushort address, byte value)
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

    }
}
