using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBeak.Classes
{
    class Mapper
    {
        static public bool bankingMode = false; //0: Rom 1: Ram

        public static void changeRamBanks(ushort bankNumber)
        {
            ushort externalAddress = (ushort)(Core.rom.ramBankNumber * 0x2000);

            //Save Old Beak Ram Data to External Ram Array
            for (int i = 0; i < 0x2000; i++)
            {
                Core.beakMemory.writeToExternalRam((uint)(externalAddress + i), Core.beakMemory.readMemory((ushort)(0xA000 + i)));
            }

            Core.rom.ramBankNumber = bankNumber;
            externalAddress = (ushort)(Core.rom.ramBankNumber * 0x2000);

            //Load New External Ram data to Beak Ram
            for (int i = 0; i < 0x2000; i++)
            {
                Core.beakMemory.directMemoryWrite((ushort)(0xA000 + i), Core.beakMemory.readFromExternalRam((uint)(externalAddress + i)));
            }

        }
    }
}
