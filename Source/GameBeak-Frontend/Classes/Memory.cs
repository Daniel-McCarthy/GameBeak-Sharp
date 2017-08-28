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





    }
}
