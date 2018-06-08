using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBeak.Classes.Mappers
{
    public class MBC2 : Mapper
    {
        public static void writeMBC2Value(ushort address, byte value)
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
                byte newBankNumber = (byte)(value & 0x0F);

                if (Core.rom.romBankNumber != newBankNumber)
                {
                    changeMBC2RomBanks(newBankNumber);
                }

            }
        }


        public static void changeMBC2RomBanks(ushort bankNumber)
        {
            if (bankNumber == 0)
            {
                bankNumber++;
            }

            if ((bankNumber >= 0) && (bankNumber <= 0x0F))
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
