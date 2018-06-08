using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBeak.Classes
{
    class MBC5 : Mapper
    {
        public static void writeMBC5Value(ushort address, byte value)
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
            else if (address >= 0x2000 && address <= 0x2FFF)
            {
                //Set Low 8 bits of Rom Bank Number
                byte newBankNumber = (byte)((Core.rom.romBankNumber & 0x100) | (value)); //Keeps the 9th bit of current rom bank number, joins entire value.

                if (Core.rom.romBankNumber != newBankNumber)
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

                byte newBankNumber = (byte)((Core.rom.romBankNumber & 0xFF) | (value << 8));

                if (Core.rom.romBankNumber != newBankNumber)
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

                    if (Core.rom.ramBankNumber != newBankNumber)
                    {
                        changeRamBanks(newBankNumber);
                    }
                }

            }
        }

        public static void changeMBC5RomBanks(ushort bankNumber)
        {
            if ((bankNumber >= 0) && (bankNumber <= 0x1FF))
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
