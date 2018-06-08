using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBeak.Classes.Mappers
{
    public class MBC1 : Mapper
    {
        public static void writeMBC1Value(ushort address, byte value)
        {
            if (address >= 0x0000 && address <= 0x1FFF)
            {
                //Ram Enable/Disable
                if ((value & 0x0F) == 0x0A)
                {
                    //Enable Ram
                    Core.beakMemory.ramEnabled = true;
                }
                else
                {
                    //Disable Ram
                    Core.beakMemory.ramEnabled = false;
                }
            }
            else if (address >= 0x2000 && address <= 0x3FFF)
            {
                //Set Rom Bank Number 5 bits
                byte newBankNumber = (byte)((Core.rom.romBankNumber & 0xE0) | (value & 0x1F));

                if (Core.rom.romBankNumber != newBankNumber)
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
                    byte newBankNumber = (byte)((Core.rom.romBankNumber & 0x1F) | ((value & 0x03) << 5));
                    if (Core.rom.romBankNumber != newBankNumber)
                    {
                        changeMBC1RomBanks(newBankNumber);
                    }
                }
                else
                {
                    //Change Ram Bank
                    byte newBankNumber = (byte)(value & 0x03);

                    if (Core.rom.ramBankNumber != newBankNumber)
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

        public static void changeMBC1RomBanks(ushort bankNumber)
        {
            if (bankNumber == 0)
            {
                bankNumber++;
            }

            if ((bankNumber >= 0) && (bankNumber <= 0x1F))
            {

                uint bankAddress = (uint)(0x4000 * bankNumber);

                uint fixedBankAddress = 0x4000;
                for (uint i = 0; i < 0x4000; i++)
                {
                    Core.beakMemory.directMemoryWrite((ushort)(fixedBankAddress + i), Core.rom.readByte(bankAddress + i));
                }

                Core.rom.romBankNumber = bankNumber;
            }
        }
    }
}
