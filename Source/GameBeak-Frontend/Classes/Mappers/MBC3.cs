using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBeak.Classes.Mappers
{
    public class MBC3 : Mapper
    {
        public static void writeMBC3Value(ushort address, byte value)
        {
            if (address >= 0x0000 && address <= 0x1FFF)
            {
                //Ram/RTC Register  Enable/Disable
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
                //Set Rom Bank Number 7 bits
                byte newBankNumber = (byte)(value & 0x7F);

                if (Core.rom.romBankNumber != newBankNumber)
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

                    if (Core.rom.ramBankNumber != newBankNumber)
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

        public static void changeMBC3RomBanks(ushort bankNumber)
        {
            if (bankNumber == 0)
            {
                bankNumber++;
            }

            if ((bankNumber >= 0) && (bankNumber <= 0x7F))
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
