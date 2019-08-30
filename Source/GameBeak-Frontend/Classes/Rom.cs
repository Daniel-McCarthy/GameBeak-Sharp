using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBeak.Classes
{
    public class Rom
    {
        private byte[] romData = new byte[0x500000];
        public bool loadSuccessful = false;

        public byte mapperSetting = 0;
        private bool hasGBCFunctionality = false;
        private bool hasSGBFunctionality = false;
        private byte romSize = 0;
        private byte romByteSize = 0;

        private bool programRamBattery = false;
        private bool usesProgramRam = false;

        public String romFilePath = "";
        public string title = "";
        public byte cartridgeType = 0;
        public ushort romBankNumber = 0;
        public ushort ramBankNumber = 0; //originally byte
        public bool bankingMode = false; //0: Rom 1: Ram


        public Rom(byte[] fileData)
        {
            for(int i = 0; i < fileData.Length; i++)
            {
                romData[i] = fileData[i];
            }
        }

        public Rom()
        {

        }

        public void readRomHeader()
        {

            for (int i = 0; i < 16; i++)
            {
                title += (char)readByte((ushort)(0x134 + i));
            }

            //0x147 Catridge type
            /*
            00 Rom only | 01 MBC1 | 02 MBC1 + Ram | 03 MBC1 + Ram + Battery | 05 MBC2 | 06 MBC2 + Battery | 08 Rom + Ram |
            09 Rom + Ram + Battery | 0B MMM01 | 0C MMM01 + Ram | 0D MMM01 + Ram + Battery | 11 MBC3 | 12 MBC3 + Ram |
            13 MBC3 + Ram + Battery | 19 MBC5 | 1A MBC5 + Ram | 1B MBC5 + Ram + Battery | 1C MBC5 + Rumble | 1D MBC5 + Rumble + Ram |
            1E MBC5 + Rumble + Ram + Battery | 20 MBC6 | 22 MBC7 + Sensor + Rumble + Ram + Battery | FC Pocket Camera |
            FD Bandai Tama5 | FE HuC3 | FF HuC1 + Ram + Battery |
            */

            hasGBCFunctionality = readByte(0x143) != 0;
            hasSGBFunctionality = readByte(0x146) == 3;
            mapperSetting = readByte(0x147);
            romSize = readByte(0x148);
            if (mapperSetting == 0)
            {
                //None
                Core.beakMemory.writeFullRomToRam();
            }
            else if (mapperSetting <= 3)
            {
                //MBC1
                Core.beakMemory.writeRom0ToRam();

                Mappers.MBC1.changeMBC1RomBanks(1);
            }
            else if (mapperSetting <= 6)
            {
                //MBC2
                Core.beakMemory.writeRom0ToRam();

                Mappers.MBC2.changeMBC2RomBanks(1);
            }
            else if (mapperSetting <= 9)
            {
                //8: Rom+Ram
                //9: Rom+Ram+Battery

                Core.beakMemory.writeFullRomToRam();
            }
            else if (mapperSetting <= 0x0D)
            {
                //0B: MMM01
                //0C: MMM01+Ram
                //0D: MMM01+Ram+Battery

                Core.beakMemory.writeRom0ToRam();
            }
            else if (mapperSetting <= 0x10)
            {
                //0F: MBC3+Timer+Battery
                //10: MBC3+Timer+Ram+Battery
                //11: MBC3
                //12: MBC3+Ram
                //13: MBC3+Ram+Battery

                Core.beakMemory.writeRom0ToRam();

                Mappers.MBC3.changeMBC3RomBanks(1);
            }
            else if (mapperSetting <= 0x1E)
            {

                Core.beakMemory.writeRom0ToRam();

                Mappers.MBC5.changeMBC5RomBanks(1);
            }
            else
            {

                Core.beakMemory.writeFullRomToRam();
                //writeRom0ToRam();
            }

        }

        public byte readByte(uint address)
        {
            return romData[address];
        }

        public byte[] readBytes(ushort address, int byteCount)
        {
            if ((address + (byteCount - 1)) < (getExactDataLength()))
            {
                byte[] data = new byte[byteCount];

                for (int i = 0; i < byteCount; i++)
                {
                    data[i] = romData[address + i];
                }

                return data;
            }

            return null;
        }

        public byte[] readBytesFromAddressToEnd(ushort address)
        {
            int dataLength = romData.Length;

            if (address < dataLength)
            {
                int length = romData.Length - address;

                byte[] data = new byte[length];

                for (int i = 0; i < length; i++)
                {
                    data[i] = romData[address + i];
                }

                return data;
            }

            return null;
        }

        public int getExactDataLength()
        {
            return romData.Length;
        }

        public int getMapperSetting()
        {
            return mapperSetting;
        }

        public bool getProgramRamBattery()
        {
            return programRamBattery;
        }

        public bool isGBCRom()
        {
            return hasGBCFunctionality;
        }

        public bool isSGBRom()
        {
            return hasSGBFunctionality;
        }

        public bool getUsesProgramRam()
        {
            return usesProgramRam;
        }

        public void resetRom()
        {
            romData = new byte[0x50000];
            loadSuccessful = false;

            mapperSetting = 0;
            hasGBCFunctionality = false;
            hasSGBFunctionality = false;
            romSize = 0;
            romByteSize = 0;

            programRamBattery = false;
            usesProgramRam = false;

            romFilePath = "";
            title = "";
            cartridgeType = 0;
            romBankNumber = 0;
            ramBankNumber = 0;
            bankingMode = false;
        }
    }
}
