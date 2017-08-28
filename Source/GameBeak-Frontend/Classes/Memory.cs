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

        private short regAF = 0;
        private short regBC = 0;
        private short regDE = 0;
        private short regHL = 0;

        private ushort stackPointer = 0;
        private ushort memoryPointer = 0;





    }
}
