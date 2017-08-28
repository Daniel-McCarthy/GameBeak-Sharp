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



    }
}
