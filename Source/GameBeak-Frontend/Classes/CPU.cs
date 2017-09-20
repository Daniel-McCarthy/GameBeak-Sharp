using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBeak_Frontend.Classes
{
    class CPU
    {
        public bool interrupt = false;
        public bool halt = false;
        public bool stop = false; //Button input should set this back to false
        private bool repeat = false;

        public bool interruptsEnabled = true;
        public int tClock = 0;
        public int mClock = 0;

        public void selectOpcode(byte opcode)
        {
            if (repeat)
            {
                //Sets memory pointer back one.
                //If opcode is one byte it should repeat.
                //If opcode requires operands, the opcode itself will be the first operand
                Core.beakMemory.memoryPointer--;
                repeat = false;
            }

            if (Core.enableInterruptsNextCycle)
            {
                Core.enableInterruptsNextCycle = false;
                interruptsEnabled = true;
            }

            switch (opcode & 0xF0)
            {
                case 0x00:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    //Nop
                                    opcode00();
                                    break;
                                }
                            case 1:
                                {
                                    opcode01((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 2:
                                {
                                    opcode02();
                                    break;
                                }
                            case 3:
                                {
                                    opcode03();
                                    break;
                                }
                            case 4:
                                {
                                    opcode04();
                                    break;
                                }
                            case 5:
                                {
                                    opcode05();
                                    break;
                                }
                            case 6:
                                {
                                    opcode06(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 7:
                                {
                                    opcode07();
                                    break;
                                }
                            case 8:
                                {
                                    opcode08((ushort)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 9:
                                {
                                    opcode09();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcode0A();
                                    break;
                                }
                            case 0xB:
                                {
                                    opcode0B();
                                    break;
                                }
                            case 0xC:
                                {
                                    opcode0C();
                                    break;
                                }
                            case 0xD:
                                {
                                    opcode0D();
                                    break;
                                }
                            case 0xE:
                                {
                                    opcode0E(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 0xF:
                                {
                                    opcode0F();
                                    break;
                                }
                        }
                        break;
                    }
                case 0x10:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    //10 not implemented
                                    break;
                                }
                            case 1:
                                {
                                    opcode11((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 2:
                                {
                                    opcode12();
                                    break;
                                }
                            case 3:
                                {
                                    opcode13();
                                    break;
                                }
                            case 4:
                                {
                                    opcode14();
                                    break;
                                }
                            case 5:
                                {
                                    opcode15();
                                    break;
                                }
                            case 6:
                                {
                                    opcode16(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 7:
                                {
                                    opcode17();
                                    break;
                                }
                            case 8:
                                {
                                    opcode18((sbyte)Core.beakMemory.readMemory((ushort)Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 9:
                                {
                                    opcode19();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcode1A();
                                    break;
                                }
                            case 0xB:
                                {
                                    opcode1B();
                                    break;
                                }
                            case 0xC:
                                {
                                    opcode1C();
                                    break;
                                }
                            case 0xD:
                                {
                                    opcode1D();
                                    break;
                                }
                            case 0xE:
                                {
                                    opcode1E(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 0xF:
                                {
                                    opcode1F();
                                    break;
                                }
                        }
                        break;
                    }
                case 0x20:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    opcode20(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 1:
                                {
                                    opcode21((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 2:
                                {
                                    opcode22();
                                    break;
                                }
                            case 3:
                                {
                                    opcode23();
                                    break;
                                }
                            case 4:
                                {
                                    opcode24();
                                    break;
                                }
                            case 5:
                                {
                                    opcode25();
                                    break;
                                }
                            case 6:
                                {
                                    opcode26(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 7:
                                {
                                    opcode27();
                                    break;
                                }
                            case 8:
                                {
                                    opcode28(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 9:
                                {
                                    opcode29();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcode2A();
                                    break;
                                }
                            case 0xB:
                                {
                                    opcode2B();
                                    break;
                                }
                            case 0xC:
                                {
                                    opcode2C();
                                    break;
                                }
                            case 0xD:
                                {
                                    opcode2D();
                                    break;
                                }
                            case 0xE:
                                {
                                    opcode2E(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 0xF:
                                {
                                    opcode2F();
                                    break;
                                }
                        }
                        break;
                    }
                case 0x30:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    opcode30(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 1:
                                {
                                    opcode31((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 2:
                                {
                                    opcode32();
                                    break;
                                }
                            case 3:
                                {
                                    opcode33();
                                    break;
                                }
                            case 4:
                                {
                                    opcode34();
                                    break;
                                }
                            case 5:
                                {
                                    opcode35();
                                    break;
                                }
                            case 6:
                                {
                                    opcode36(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 7:
                                {
                                    opcode37();
                                    break;
                                }
                            case 8:
                                {
                                    opcode38(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 9:
                                {
                                    opcode39();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcode3A();
                                    break;
                                }
                            case 0xB:
                                {
                                    opcode3B();
                                    break;
                                }
                            case 0xC:
                                {
                                    opcode3C();
                                    break;
                                }
                            case 0xD:
                                {
                                    opcode3D();
                                    break;
                                }
                            case 0xE:
                                {
                                    opcode3E(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 0xF:
                                {
                                    opcode3F();
                                    break;
                                }
                        }
                        break;
                    }
                case 0x40:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    opcode40();
                                    break;
                                }
                            case 1:
                                {
                                    opcode41();
                                    break;
                                }
                            case 2:
                                {
                                    opcode42();
                                    break;
                                }
                            case 3:
                                {
                                    opcode43();
                                    break;
                                }
                            case 4:
                                {
                                    opcode44();
                                    break;
                                }
                            case 5:
                                {
                                    opcode45();
                                    break;
                                }
                            case 6:
                                {
                                    opcode46();
                                    break;
                                }
                            case 7:
                                {
                                    opcode47();
                                    break;
                                }
                            case 8:
                                {
                                    opcode48();
                                    break;
                                }
                            case 9:
                                {
                                    opcode49();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcode4A();
                                    break;
                                }
                            case 0xB:
                                {
                                    opcode4B();
                                    break;
                                }
                            case 0xC:
                                {
                                    opcode4C();
                                    break;
                                }
                            case 0xD:
                                {
                                    opcode4D();
                                    break;
                                }
                            case 0xE:
                                {
                                    opcode4E();
                                    break;
                                }
                            case 0xF:
                                {
                                    opcode4F();
                                    break;
                                }
                        }
                        break;
                    }
                case 0x50:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    opcode50();
                                    break;
                                }
                            case 1:
                                {
                                    opcode51();
                                    break;
                                }
                            case 2:
                                {
                                    opcode52();
                                    break;
                                }
                            case 3:
                                {
                                    opcode53();
                                    break;
                                }
                            case 4:
                                {
                                    opcode54();
                                    break;
                                }
                            case 5:
                                {
                                    opcode55();
                                    break;
                                }
                            case 6:
                                {
                                    opcode56();
                                    break;
                                }
                            case 7:
                                {
                                    opcode57();
                                    break;
                                }
                            case 8:
                                {
                                    opcode58();
                                    break;
                                }
                            case 9:
                                {
                                    opcode59();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcode5A();
                                    break;
                                }
                            case 0xB:
                                {
                                    opcode5B();
                                    break;
                                }
                            case 0xC:
                                {
                                    opcode5C();
                                    break;
                                }
                            case 0xD:
                                {
                                    opcode5D();
                                    break;
                                }
                            case 0xE:
                                {
                                    opcode5E();
                                    break;
                                }
                            case 0xF:
                                {
                                    opcode5F();
                                    break;
                                }
                        }
                        break;
                    }
                case 0x60:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    opcode60();
                                    break;
                                }
                            case 1:
                                {
                                    opcode61();
                                    break;
                                }
                            case 2:
                                {
                                    opcode62();
                                    break;
                                }
                            case 3:
                                {
                                    opcode63();
                                    break;
                                }
                            case 4:
                                {
                                    opcode64();
                                    break;
                                }
                            case 5:
                                {
                                    opcode65();
                                    break;
                                }
                            case 6:
                                {
                                    opcode66();
                                    break;
                                }
                            case 7:
                                {
                                    opcode67();
                                    break;
                                }
                            case 8:
                                {
                                    opcode68();
                                    break;
                                }
                            case 9:
                                {
                                    opcode69();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcode6A();
                                    break;
                                }
                            case 0xB:
                                {
                                    opcode6B();
                                    break;
                                }
                            case 0xC:
                                {
                                    opcode6C();
                                    break;
                                }
                            case 0xD:
                                {
                                    opcode6D();
                                    break;
                                }
                            case 0xE:
                                {
                                    opcode6E();
                                    break;
                                }
                            case 0xF:
                                {
                                    opcode6F();
                                    break;
                                }
                        }
                        break;
                    }
                case 0x70:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    opcode70();
                                    break;
                                }
                            case 1:
                                {
                                    opcode71();
                                    break;
                                }
                            case 2:
                                {
                                    opcode72();
                                    break;
                                }
                            case 3:
                                {
                                    opcode73();
                                    break;
                                }
                            case 4:
                                {
                                    opcode74();
                                    break;
                                }
                            case 5:
                                {
                                    opcode75();
                                    break;
                                }
                            case 6:
                                {
                                    //Halt
                                    opcode76();
                                    break;
                                }
                            case 7:
                                {
                                    opcode77();
                                    break;
                                }
                            case 8:
                                {
                                    opcode78();
                                    break;
                                }
                            case 9:
                                {
                                    opcode79();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcode7A();
                                    break;
                                }
                            case 0xB:
                                {
                                    opcode7B();
                                    break;
                                }
                            case 0xC:
                                {
                                    opcode7C();
                                    break;
                                }
                            case 0xD:
                                {
                                    opcode7D();
                                    break;
                                }
                            case 0xE:
                                {
                                    opcode7E();
                                    break;
                                }
                            case 0xF:
                                {
                                    opcode7F();
                                    break;
                                }
                        }
                        break;
                    }
                case 0x80:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    opcode80();
                                    break;
                                }
                            case 1:
                                {
                                    opcode81();
                                    break;
                                }
                            case 2:
                                {
                                    opcode82();
                                    break;
                                }
                            case 3:
                                {
                                    opcode83();
                                    break;
                                }
                            case 4:
                                {
                                    opcode84();
                                    break;
                                }
                            case 5:
                                {
                                    opcode85();
                                    break;
                                }
                            case 6:
                                {
                                    opcode86();
                                    break;
                                }
                            case 7:
                                {
                                    opcode87();
                                    break;
                                }
                            case 8:
                                {
                                    opcode88();
                                    break;
                                }
                            case 9:
                                {
                                    opcode89();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcode8A();
                                    break;
                                }
                            case 0xB:
                                {
                                    opcode8B();
                                    break;
                                }
                            case 0xC:
                                {
                                    opcode8C();
                                    break;
                                }
                            case 0xD:
                                {
                                    opcode8D();
                                    break;
                                }
                            case 0xE:
                                {
                                    opcode8E();
                                    break;
                                }
                            case 0xF:
                                {
                                    opcode8F();
                                    break;
                                }
                        }
                        break;
                    }
                case 0x90:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    opcode90();
                                    break;
                                }
                            case 1:
                                {
                                    opcode91();
                                    break;
                                }
                            case 2:
                                {
                                    opcode92();
                                    break;
                                }
                            case 3:
                                {
                                    opcode93();
                                    break;
                                }
                            case 4:
                                {
                                    opcode94();
                                    break;
                                }
                            case 5:
                                {
                                    opcode95();
                                    break;
                                }
                            case 6:
                                {
                                    opcode96();
                                    break;
                                }
                            case 7:
                                {
                                    opcode97();
                                    break;
                                }
                            case 8:
                                {
                                    opcode98();
                                    break;
                                }
                            case 9:
                                {
                                    opcode99();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcode9A();
                                    break;
                                }
                            case 0xB:
                                {
                                    opcode9B();
                                    break;
                                }
                            case 0xC:
                                {
                                    opcode9C();
                                    break;
                                }
                            case 0xD:
                                {
                                    opcode9D();
                                    break;
                                }
                            case 0xE:
                                {
                                    opcode9E();
                                    break;
                                }
                            case 0xF:
                                {
                                    opcode9F();
                                    break;
                                }
                        }
                        break;
                    }
                case 0xA0:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    opcodeA0();
                                    break;
                                }
                            case 1:
                                {
                                    opcodeA1();
                                    break;
                                }
                            case 2:
                                {
                                    opcodeA2();
                                    break;
                                }
                            case 3:
                                {
                                    opcodeA3();
                                    break;
                                }
                            case 4:
                                {
                                    opcodeA4();
                                    break;
                                }
                            case 5:
                                {
                                    opcodeA5();
                                    break;
                                }
                            case 6:
                                {
                                    opcodeA6();
                                    break;
                                }
                            case 7:
                                {
                                    opcodeA7();
                                    break;
                                }
                            case 8:
                                {
                                    opcodeA8();
                                    break;
                                }
                            case 9:
                                {
                                    opcodeA9();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcodeAA();
                                    break;
                                }
                            case 0xB:
                                {
                                    opcodeAB();
                                    break;
                                }
                            case 0xC:
                                {
                                    opcodeAC();
                                    break;
                                }
                            case 0xD:
                                {
                                    opcodeAD();
                                    break;
                                }
                            case 0xE:
                                {
                                    opcodeAE();
                                    break;
                                }
                            case 0xF:
                                {
                                    opcodeAF();
                                    break;
                                }
                        }
                        break;
                    }
                case 0xB0:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    opcodeB0();
                                    break;
                                }
                            case 1:
                                {
                                    opcodeB1();
                                    break;
                                }
                            case 2:
                                {
                                    opcodeB2();
                                    break;
                                }
                            case 3:
                                {
                                    opcodeB3();
                                    break;
                                }
                            case 4:
                                {
                                    opcodeB4();
                                    break;
                                }
                            case 5:
                                {
                                    opcodeB5();
                                    break;
                                }
                            case 6:
                                {
                                    opcodeB6();
                                    break;
                                }
                            case 7:
                                {
                                    opcodeB7();
                                    break;
                                }
                            case 8:
                                {
                                    opcodeB8();
                                    break;
                                }
                            case 9:
                                {
                                    opcodeB9();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcodeBA();
                                    break;
                                }
                            case 0xB:
                                {
                                    opcodeBB();
                                    break;
                                }
                            case 0xC:
                                {
                                    opcodeBC();
                                    break;
                                }
                            case 0xD:
                                {
                                    opcodeBD();
                                    break;
                                }
                            case 0xE:
                                {
                                    opcodeBE();
                                    break;
                                }
                            case 0xF:
                                {
                                    opcodeBF();
                                    break;
                                }
                        }
                        break;
                    }
                case 0xC0:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0x00:
                                {
                                    opcodeC0();
                                    break;
                                }
                            case 0x01:
                                {
                                    opcodeC1();
                                    break;
                                }
                            case 0x02:
                                {
                                    opcodeC2((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 0x03:
                                {
                                    opcodeC3((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 0x04:
                                {
                                    opcodeC4((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 0x05:
                                {
                                    opcodeC5();
                                    break;
                                }
                            case 0x06:
                                {
                                    opcodeC6(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 0x07:
                                {
                                    opcodeC7();
                                    break;
                                }
                            case 0x08:
                                {
                                    opcodeC8();
                                    break;
                                }
                            case 0x09:
                                {
                                    opcodeC9();
                                    break;
                                }
                            case 0x0A:
                                {
                                    opcodeCA((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 0x0B:
                                {
                                    switch (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++))
                                    {

                                        case 0x00: { opcodeCB00(); break; }
                                        case 0x01: { opcodeCB01(); break; }
                                        case 0x02: { opcodeCB02(); break; }
                                        case 0x03: { opcodeCB03(); break; }
                                        case 0x04: { opcodeCB04(); break; }
                                        case 0x05: { opcodeCB05(); break; }
                                        case 0x06: { opcodeCB06(); break; }
                                        case 0x07: { opcodeCB07(); break; }
                                        case 0x08: { opcodeCB08(); break; }
                                        case 0x09: { opcodeCB09(); break; }
                                        case 0x0A: { opcodeCB0A(); break; }
                                        case 0x0B: { opcodeCB0B(); break; }
                                        case 0x0C: { opcodeCB0C(); break; }
                                        case 0x0D: { opcodeCB0D(); break; }
                                        case 0x0E: { opcodeCB0E(); break; }
                                        case 0x0F: { opcodeCB0F(); break; }
                                        case 0x10: { opcodeCB10(); break; }
                                        case 0x11: { opcodeCB11(); break; }
                                        case 0x12: { opcodeCB12(); break; }
                                        case 0x13: { opcodeCB13(); break; }
                                        case 0x14: { opcodeCB14(); break; }
                                        case 0x15: { opcodeCB15(); break; }
                                        case 0x16: { opcodeCB16(); break; }
                                        case 0x17: { opcodeCB17(); break; }
                                        case 0x18: { opcodeCB18(); break; }
                                        case 0x19: { opcodeCB19(); break; }
                                        case 0x1A: { opcodeCB1A(); break; }
                                        case 0x1B: { opcodeCB1B(); break; }
                                        case 0x1C: { opcodeCB1C(); break; }
                                        case 0x1D: { opcodeCB1D(); break; }
                                        case 0x1E: { opcodeCB1E(); break; }
                                        case 0x1F: { opcodeCB1F(); break; }
                                        case 0x20: { opcodeCB20(); break; }
                                        case 0x21: { opcodeCB21(); break; }
                                        case 0x22: { opcodeCB22(); break; }
                                        case 0x23: { opcodeCB23(); break; }
                                        case 0x24: { opcodeCB24(); break; }
                                        case 0x25: { opcodeCB25(); break; }
                                        case 0x26: { opcodeCB26(); break; }
                                        case 0x27: { opcodeCB27(); break; }
                                        case 0x28: { opcodeCB28(); break; }
                                        case 0x29: { opcodeCB29(); break; }
                                        case 0x2A: { opcodeCB2A(); break; }
                                        case 0x2B: { opcodeCB2B(); break; }
                                        case 0x2C: { opcodeCB2C(); break; }
                                        case 0x2D: { opcodeCB2D(); break; }
                                        case 0x2E: { opcodeCB2E(); break; }
                                        case 0x2F: { opcodeCB2F(); break; }
                                        case 0x30: { opcodeCB30(); break; }
                                        case 0x31: { opcodeCB31(); break; }
                                        case 0x32: { opcodeCB32(); break; }
                                        case 0x33: { opcodeCB33(); break; }
                                        case 0x34: { opcodeCB34(); break; }
                                        case 0x35: { opcodeCB35(); break; }
                                        case 0x36: { opcodeCB36(); break; }
                                        case 0x37: { opcodeCB37(); break; }
                                        case 0x38: { opcodeCB38(); break; }
                                        case 0x39: { opcodeCB39(); break; }
                                        case 0x3A: { opcodeCB3A(); break; }
                                        case 0x3B: { opcodeCB3B(); break; }
                                        case 0x3C: { opcodeCB3C(); break; }
                                        case 0x3D: { opcodeCB3D(); break; }
                                        case 0x3E: { opcodeCB3E(); break; }
                                        case 0x3F: { opcodeCB3F(); break; }
                                        case 0x40: { opcodeCB40(); break; }
                                        case 0x41: { opcodeCB41(); break; }
                                        case 0x42: { opcodeCB42(); break; }
                                        case 0x43: { opcodeCB43(); break; }
                                        case 0x44: { opcodeCB44(); break; }
                                        case 0x45: { opcodeCB45(); break; }
                                        case 0x46: { opcodeCB46(); break; }
                                        case 0x47: { opcodeCB47(); break; }
                                        case 0x48: { opcodeCB48(); break; }
                                        case 0x49: { opcodeCB49(); break; }
                                        case 0x4A: { opcodeCB4A(); break; }
                                        case 0x4B: { opcodeCB4B(); break; }
                                        case 0x4C: { opcodeCB4C(); break; }
                                        case 0x4D: { opcodeCB4D(); break; }
                                        case 0x4E: { opcodeCB4E(); break; }
                                        case 0x4F: { opcodeCB4F(); break; }
                                        case 0x50: { opcodeCB50(); break; }
                                        case 0x51: { opcodeCB51(); break; }
                                        case 0x52: { opcodeCB52(); break; }
                                        case 0x53: { opcodeCB53(); break; }
                                        case 0x54: { opcodeCB54(); break; }
                                        case 0x55: { opcodeCB55(); break; }
                                        case 0x56: { opcodeCB56(); break; }
                                        case 0x57: { opcodeCB57(); break; }
                                        case 0x58: { opcodeCB58(); break; }
                                        case 0x59: { opcodeCB59(); break; }
                                        case 0x5A: { opcodeCB5A(); break; }
                                        case 0x5B: { opcodeCB5B(); break; }
                                        case 0x5C: { opcodeCB5C(); break; }
                                        case 0x5D: { opcodeCB5D(); break; }
                                        case 0x5E: { opcodeCB5E(); break; }
                                        case 0x5F: { opcodeCB5F(); break; }
                                        case 0x60: { opcodeCB60(); break; }
                                        case 0x61: { opcodeCB61(); break; }
                                        case 0x62: { opcodeCB62(); break; }
                                        case 0x63: { opcodeCB63(); break; }
                                        case 0x64: { opcodeCB64(); break; }
                                        case 0x65: { opcodeCB65(); break; }
                                        case 0x66: { opcodeCB66(); break; }
                                        case 0x67: { opcodeCB67(); break; }
                                        case 0x68: { opcodeCB68(); break; }
                                        case 0x69: { opcodeCB69(); break; }
                                        case 0x6A: { opcodeCB6A(); break; }
                                        case 0x6B: { opcodeCB6B(); break; }
                                        case 0x6C: { opcodeCB6C(); break; }
                                        case 0x6D: { opcodeCB6D(); break; }
                                        case 0x6E: { opcodeCB6E(); break; }
                                        case 0x6F: { opcodeCB6F(); break; }
                                        case 0x70: { opcodeCB70(); break; }
                                        case 0x71: { opcodeCB71(); break; }
                                        case 0x72: { opcodeCB72(); break; }
                                        case 0x73: { opcodeCB73(); break; }
                                        case 0x74: { opcodeCB74(); break; }
                                        case 0x75: { opcodeCB75(); break; }
                                        case 0x76: { opcodeCB76(); break; }
                                        case 0x77: { opcodeCB77(); break; }
                                        case 0x78: { opcodeCB78(); break; }
                                        case 0x79: { opcodeCB79(); break; }
                                        case 0x7A: { opcodeCB7A(); break; }
                                        case 0x7B: { opcodeCB7B(); break; }
                                        case 0x7C: { opcodeCB7C(); break; }
                                        case 0x7D: { opcodeCB7D(); break; }
                                        case 0x7E: { opcodeCB7E(); break; }
                                        case 0x7F: { opcodeCB7F(); break; }
                                        case 0x80: { opcodeCB80(); break; }
                                        case 0x81: { opcodeCB81(); break; }
                                        case 0x82: { opcodeCB82(); break; }
                                        case 0x83: { opcodeCB83(); break; }
                                        case 0x84: { opcodeCB84(); break; }
                                        case 0x85: { opcodeCB85(); break; }
                                        case 0x86: { opcodeCB86(); break; }
                                        case 0x87: { opcodeCB87(); break; }
                                        case 0x88: { opcodeCB88(); break; }
                                        case 0x89: { opcodeCB89(); break; }
                                        case 0x8A: { opcodeCB8A(); break; }
                                        case 0x8B: { opcodeCB8B(); break; }
                                        case 0x8C: { opcodeCB8C(); break; }
                                        case 0x8D: { opcodeCB8D(); break; }
                                        case 0x8E: { opcodeCB8E(); break; }
                                        case 0x8F: { opcodeCB8F(); break; }
                                        case 0x90: { opcodeCB90(); break; }
                                        case 0x91: { opcodeCB91(); break; }
                                        case 0x92: { opcodeCB92(); break; }
                                        case 0x93: { opcodeCB93(); break; }
                                        case 0x94: { opcodeCB94(); break; }
                                        case 0x95: { opcodeCB95(); break; }
                                        case 0x96: { opcodeCB96(); break; }
                                        case 0x97: { opcodeCB97(); break; }
                                        case 0x98: { opcodeCB98(); break; }
                                        case 0x99: { opcodeCB99(); break; }
                                        case 0x9A: { opcodeCB9A(); break; }
                                        case 0x9B: { opcodeCB9B(); break; }
                                        case 0x9C: { opcodeCB9C(); break; }
                                        case 0x9D: { opcodeCB9D(); break; }
                                        case 0x9E: { opcodeCB9E(); break; }
                                        case 0x9F: { opcodeCB9F(); break; }
                                        case 0xA0: { opcodeCBA0(); break; }
                                        case 0xA1: { opcodeCBA1(); break; }
                                        case 0xA2: { opcodeCBA2(); break; }
                                        case 0xA3: { opcodeCBA3(); break; }
                                        case 0xA4: { opcodeCBA4(); break; }
                                        case 0xA5: { opcodeCBA5(); break; }
                                        case 0xA6: { opcodeCBA6(); break; }
                                        case 0xA7: { opcodeCBA7(); break; }
                                        case 0xA8: { opcodeCBA8(); break; }
                                        case 0xA9: { opcodeCBA9(); break; }
                                        case 0xAA: { opcodeCBAA(); break; }
                                        case 0xAB: { opcodeCBAB(); break; }
                                        case 0xAC: { opcodeCBAC(); break; }
                                        case 0xAD: { opcodeCBAD(); break; }
                                        case 0xAE: { opcodeCBAE(); break; }
                                        case 0xAF: { opcodeCBAF(); break; }
                                        case 0xB0: { opcodeCBB0(); break; }
                                        case 0xB1: { opcodeCBB1(); break; }
                                        case 0xB2: { opcodeCBB2(); break; }
                                        case 0xB3: { opcodeCBB3(); break; }
                                        case 0xB4: { opcodeCBB4(); break; }
                                        case 0xB5: { opcodeCBB5(); break; }
                                        case 0xB6: { opcodeCBB6(); break; }
                                        case 0xB7: { opcodeCBB7(); break; }
                                        case 0xB8: { opcodeCBB8(); break; }
                                        case 0xB9: { opcodeCBB9(); break; }
                                        case 0xBA: { opcodeCBBA(); break; }
                                        case 0xBB: { opcodeCBBB(); break; }
                                        case 0xBC: { opcodeCBBC(); break; }
                                        case 0xBD: { opcodeCBBD(); break; }
                                        case 0xBE: { opcodeCBBE(); break; }
                                        case 0xBF: { opcodeCBBF(); break; }
                                        case 0xC0: { opcodeCBC0(); break; }
                                        case 0xC1: { opcodeCBC1(); break; }
                                        case 0xC2: { opcodeCBC2(); break; }
                                        case 0xC3: { opcodeCBC3(); break; }
                                        case 0xC4: { opcodeCBC4(); break; }
                                        case 0xC5: { opcodeCBC5(); break; }
                                        case 0xC6: { opcodeCBC6(); break; }
                                        case 0xC7: { opcodeCBC7(); break; }
                                        case 0xC8: { opcodeCBC8(); break; }
                                        case 0xC9: { opcodeCBC9(); break; }
                                        case 0xCA: { opcodeCBCA(); break; }
                                        case 0xCB: { opcodeCBCB(); break; }
                                        case 0xCC: { opcodeCBCC(); break; }
                                        case 0xCD: { opcodeCBCD(); break; }
                                        case 0xCE: { opcodeCBCE(); break; }
                                        case 0xCF: { opcodeCBCF(); break; }
                                        case 0xD0: { opcodeCBD0(); break; }
                                        case 0xD1: { opcodeCBD1(); break; }
                                        case 0xD2: { opcodeCBD2(); break; }
                                        case 0xD3: { opcodeCBD3(); break; }
                                        case 0xD4: { opcodeCBD4(); break; }
                                        case 0xD5: { opcodeCBD5(); break; }
                                        case 0xD6: { opcodeCBD6(); break; }
                                        case 0xD7: { opcodeCBD7(); break; }
                                        case 0xD8: { opcodeCBD8(); break; }
                                        case 0xD9: { opcodeCBD9(); break; }
                                        case 0xDA: { opcodeCBDA(); break; }
                                        case 0xDB: { opcodeCBDB(); break; }
                                        case 0xDC: { opcodeCBDC(); break; }
                                        case 0xDD: { opcodeCBDD(); break; }
                                        case 0xDE: { opcodeCBDE(); break; }
                                        case 0xDF: { opcodeCBDF(); break; }
                                        case 0xE0: { opcodeCBE0(); break; }
                                        case 0xE1: { opcodeCBE1(); break; }
                                        case 0xE2: { opcodeCBE2(); break; }
                                        case 0xE3: { opcodeCBE3(); break; }
                                        case 0xE4: { opcodeCBE4(); break; }
                                        case 0xE5: { opcodeCBE5(); break; }
                                        case 0xE6: { opcodeCBE6(); break; }
                                        case 0xE7: { opcodeCBE7(); break; }
                                        case 0xE8: { opcodeCBE8(); break; }
                                        case 0xE9: { opcodeCBE9(); break; }
                                        case 0xEA: { opcodeCBEA(); break; }
                                        case 0xEB: { opcodeCBEB(); break; }
                                        case 0xEC: { opcodeCBEC(); break; }
                                        case 0xED: { opcodeCBED(); break; }
                                        case 0xEE: { opcodeCBEE(); break; }
                                        case 0xEF: { opcodeCBEF(); break; }
                                        case 0xF0: { opcodeCBF0(); break; }
                                        case 0xF1: { opcodeCBF1(); break; }
                                        case 0xF2: { opcodeCBF2(); break; }
                                        case 0xF3: { opcodeCBF3(); break; }
                                        case 0xF4: { opcodeCBF4(); break; }
                                        case 0xF5: { opcodeCBF5(); break; }
                                        case 0xF6: { opcodeCBF6(); break; }
                                        case 0xF7: { opcodeCBF7(); break; }
                                        case 0xF8: { opcodeCBF8(); break; }
                                        case 0xF9: { opcodeCBF9(); break; }
                                        case 0xFA: { opcodeCBFA(); break; }
                                        case 0xFB: { opcodeCBFB(); break; }
                                        case 0xFC: { opcodeCBFC(); break; }
                                        case 0xFD: { opcodeCBFD(); break; }
                                        case 0xFE: { opcodeCBFE(); break; }
                                        case 0xFF: { opcodeCBFF(); break; }

                                    }
                                    break;
                                }
                            case 0x0C:
                                {
                                    opcodeCC((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 0x0D:
                                {
                                    opcodeCD((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 0x0E:
                                {
                                    opcodeCE(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 0x0F:
                                {
                                    opcodeCF();
                                    break;
                                }
                        }
                        break;

                    }
                case 0xD0:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    opcodeD0();
                                    break;
                                }
                            case 1:
                                {
                                    opcodeD1();
                                    break;
                                }
                            case 2:
                                {
                                    opcodeD2((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 3:
                                {
                                    //D3 does not exist
                                    break;
                                }
                            case 4:
                                {
                                    opcodeD4((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 5:
                                {
                                    opcodeD5();
                                    break;
                                }
                            case 6:
                                {
                                    opcodeD6(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 7:
                                {
                                    opcodeD7();
                                    break;
                                }
                            case 8:
                                {
                                    opcodeD8();
                                    break;
                                }
                            case 9:
                                {
                                    opcodeD9();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcodeDA((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 0xB:
                                {
                                    //Does not exist
                                    break;
                                }
                            case 0xC:
                                {
                                    opcodeDC((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 0xD:
                                {
                                    //DD not exist
                                    break;
                                }
                            case 0xE:
                                {
                                    opcodeDE(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;

                                }
                            case 0xF:
                                {
                                    opcodeDF();
                                    break;
                                }
                        }
                        break;
                    }
                case 0xE0:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    opcodeE0(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 1:
                                {
                                    opcodeE1();
                                    break;
                                }
                            case 2:
                                {
                                    opcodeE2();
                                    break;
                                }
                            case 3:
                                {
                                    //E3 does not exist
                                    break;
                                }
                            case 4:
                                {
                                    //E4 does not exist
                                    break;
                                }
                            case 5:
                                {
                                    opcodeE5();
                                    break;
                                }
                            case 6:
                                {
                                    opcodeE6(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 7:
                                {
                                    opcodeE7();
                                    break;
                                }
                            case 8:
                                {
                                    opcodeE8((sbyte)Core.beakMemory.readMemory((ushort)Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 9:
                                {
                                    opcodeE9();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcodeEA((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 0xB:
                                {
                                    //EB not exist
                                    break;
                                }
                            case 0xC:
                                {
                                    //EC not exist
                                    break;
                                }
                            case 0xD:
                                {
                                    //ED not exist
                                    break;
                                }
                            case 0xE:
                                {
                                    opcodeEE(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 0xF:
                                {
                                    opcodeEF();
                                    break;
                                }
                        }
                        break;
                    }
                case 0xF0:
                    {
                        switch (opcode & 0x0F)
                        {
                            case 0:
                                {
                                    opcodeF0(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 1:
                                {
                                    opcodeF1();
                                    break;
                                }
                            case 2:
                                {
                                    opcodeF2();
                                    break;
                                }
                            case 3:
                                {
                                    //Disable Interrupts
                                    opcodeF3();
                                    break;
                                }
                            case 4:
                                {
                                    //F4 not exist
                                    break;
                                }
                            case 5:
                                {
                                    opcodeF5();
                                    break;
                                }
                            case 6:
                                {
                                    opcodeF6(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 7:
                                {
                                    opcodeF7();
                                    break;
                                }
                            case 8:
                                {
                                    opcodeF8(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 9:
                                {
                                    opcodeF9();
                                    break;
                                }
                            case 0xA:
                                {
                                    opcodeFA((short)((Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++)) | (Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++) << 8)));
                                    break;
                                }
                            case 0xB:
                                {
                                    //Enable Interrupts
                                    opcodeFB();
                                    break;
                                }
                            case 0xC:
                                {
                                    //FC not exist
                                    break;
                                }
                            case 0xD:
                                {
                                    //FD not exist
                                    break;
                                }
                            case 0xE:
                                {
                                    opcodeFE(Core.beakMemory.readMemory(Core.beakMemory.memoryPointer++));
                                    break;
                                }
                            case 0xF:
                                {
                                    opcodeFF();
                                    break;
                                }
                        }

                        break;
                    }
            }
        }

        public void opcode00()
        {
            //NOP
            mClock += 1;
            tClock += 4;
        }

        public void opcode01(short nn)
        {
            //Load short into BC
            Core.beakMemory.setBC(nn);
            mClock += 3;
            tClock += 12;
        }

        public void opcode02()
        {
            //Load A into data at BC
            Core.beakMemory.writeMemory((ushort)(Core.beakMemory.getBC()), Core.beakMemory.getA());
            mClock += 2;
            tClock += 8;
        }

        public void opcode03()
        {
            //Inc BC

            Core.beakMemory.setBC((short)(Core.beakMemory.getBC() + 1));

            mClock += 2;
            tClock += 8;
        }

        public void opcode04()
        {
            //Inc B

            Core.beakMemory.setB((byte)(Core.beakMemory.getB() + 1));

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getB() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag((((Core.beakMemory.getB()) & 0x0F) == 0) ? true : false);
        }

        public void opcode05()
        {
            //Dec B

            Core.beakMemory.setB((byte)(Core.beakMemory.getB() - 1));

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getB() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag((((Core.beakMemory.getB()) & 0x0F) == 0xF) ? true : false);
        }

        public void opcode06(byte n)
        {
            //Load byte into B
            Core.beakMemory.setB(n);
            mClock += 2;
            tClock += 8;
        }

        public void opcode07()
        {
            /*
            //Rotate A Left - Set C flag to old bit 7
            beakMemory.setCFlag(((beakMemory.getA() & 0x01) == 1) ? true : false);
            beakMemory.setA(rotateLeft(beakMemory.getA()));
            mClock += 2;
            tClock += 8;
            */

            //Rotate A Left, put previous bit 7 into Carry flag
            if (Core.beakMemory.getA() != 0)
            {
                Core.beakMemory.setCFlag((Core.beakMemory.getA() & 0x01) > 0);
            }
            else
            {
                Core.beakMemory.setZFlag(false);
                Core.beakMemory.setCFlag(false);
            }

            //beakMemory.setA(beakMemory.getA() << 1);
            Core.beakMemory.setA(Binary.rotateLeft(Core.beakMemory.getA()));

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);

        }

        public void opcode08(ushort nn)
        {
            //Load SP into data at NN
            Core.beakMemory.writeMemory(nn, (short)Core.beakMemory.stackPointer);
            mClock += 5;
            tClock += 20;
        }

        public void opcode09()
        {
            //Add BC to HL

            ushort hl = (ushort)Core.beakMemory.getHL();
            ushort bc = (ushort)Core.beakMemory.getBC();
            uint totalSum = (uint)(hl + bc);
            uint halfCarrySum = (uint)((hl & 0x0FFF) + (bc & 0x0FFF));

            if (totalSum > 0xFFFF)
            {
                int overflow = (int)(totalSum - 65536);//0xFFFF;
                Core.beakMemory.setHL((short)(0 + overflow));
                Core.beakMemory.setCFlag(true);
                Core.beakMemory.setHFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(halfCarrySum > 0x0FFF);
                Core.beakMemory.setHL((short)(Core.beakMemory.getHL() + Core.beakMemory.getBC()));
                //TODO: Find out of H can be set by half overflow? Haven't found a circumstance in which it does yet
                Core.beakMemory.setCFlag(false);
            }
            mClock += 2;
            tClock += 8;

            //beakMemory.setZFlag(beakMemory.getHL() == 0); //From testing, this opcode leaves Z as it was
            Core.beakMemory.setNFlag(false);
        }


        public void opcode0A()
        {
            //Load data at BC into A
            Core.beakMemory.setA(Core.beakMemory.readMemory((ushort)Core.beakMemory.getBC()));
            mClock += 2;
            tClock += 8;
        }

        public void opcode0B()
        {
            //Dec BC

            Core.beakMemory.setBC((short)(Core.beakMemory.getBC() - 1));

            mClock += 2;
            tClock += 8;
        }

        public void opcode0C()
        {
            //Inc C

            Core.beakMemory.setC((byte)(Core.beakMemory.getC() + 1));

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getC() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag((((Core.beakMemory.getC()) & 0x0F) == 0) ? true : false);
        }

        public void opcode0D()
        {
            //Dec C

            Core.beakMemory.setC((byte)(Core.beakMemory.getC() - 1));

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getC() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag((((Core.beakMemory.getC()) & 0x0F) == 0xF) ? true : false);
        }

        public void opcode0E(byte n)
        {
            //Load byte into C
            Core.beakMemory.setC(n);
            mClock += 2;
            tClock += 8;
        }

        public void opcode0F()
        {
            //Rotate A Right, put previous bit 0 into Carry flag

            Core.beakMemory.setCFlag((Core.beakMemory.getA() & 0x01) > 0);
            Core.beakMemory.setA(Binary.rotateRight(Core.beakMemory.getA()));

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag(false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);

        }

        //Need to implement 10 STOP 

        public void opcode11(short nn)
        {
            //Load short into DE
            Core.beakMemory.setDE(nn);
            mClock += 3;
            tClock += 12;
        }

        public void opcode12()
        {
            //Load A into data at DE
            Core.beakMemory.writeMemory((ushort)(Core.beakMemory.getDE()), Core.beakMemory.getA());
            mClock += 2;
            tClock += 8;
        }

        public void opcode13()
        {
            //Inc DE

            Core.beakMemory.setDE((short)(Core.beakMemory.getDE() + 1));

            mClock += 2;
            tClock += 8;
        }

        public void opcode14()
        {
            //Inc D

            Core.beakMemory.setD((byte)(Core.beakMemory.getD() + 1));

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getD() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag((((Core.beakMemory.getD()) & 0x0F) == 0) ? true : false);
        }

        public void opcode15()
        {
            //Dec D

            Core.beakMemory.setD((byte)(Core.beakMemory.getD() - 1));

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getD() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag((((Core.beakMemory.getD()) & 0x0F) == 0xF) ? true : false);
        }

        public void opcode16(byte n)
        {
            //Load byte into D
            Core.beakMemory.setD(n);
            mClock += 2;
            tClock += 8;
        }

        public void opcode17()
        {
            //RLCA Rotate A Left - Set right most bit to current carry flag
            byte cFlag = (Core.beakMemory.getCFlag() == true) ? (byte)0x01 : (byte)0x00;
            Core.beakMemory.setCFlag(((Core.beakMemory.getA() & 0x80) >> 7) > 0);
            Core.beakMemory.setA((byte)((Core.beakMemory.getA() << 1) | cFlag));

            Core.beakMemory.setZFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setNFlag(false);
            mClock += 1;
            tClock += 4;

        }

        public void opcode18(sbyte n) //signed byte
        {
            //Jump Relative to n
            Core.beakMemory.memoryPointer += (sbyte)n;
            mClock += 3;
            tClock += 12;
        }

        public void opcode19()
        {
            //Add DE to HL

            ushort hl = (ushort)Core.beakMemory.getHL();
            ushort de = (ushort)Core.beakMemory.getDE();
            uint totalSum = (uint)(hl + de);
            uint halfCarrySum = (uint)((hl & 0x0FFF) + (de & 0x0FFF));

            if (totalSum > 0xFFFF)
            {
                short overflow = (short)(totalSum - 65536);//0xFFFF;
                Core.beakMemory.setHL((short)(0 + overflow));
                Core.beakMemory.setCFlag(true);
                Core.beakMemory.setHFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(halfCarrySum > 0x0FFF);
                Core.beakMemory.setHL((short)(Core.beakMemory.getHL() + Core.beakMemory.getDE()));
                //TODO: Find out if half carry happens?
                Core.beakMemory.setCFlag(false);
            }
            mClock += 2;
            tClock += 8;

            //beakMemory.setZFlag(beakMemory.getHL() == 0);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode1A()
        {
            //Load data at DE into A
            Core.beakMemory.setA((byte)(Core.beakMemory.readMemory((ushort)Core.beakMemory.getDE())));
            mClock += 2;
            tClock += 8;
        }

        public void opcode1B()
        {
            //Dec DE

            Core.beakMemory.setDE((short)(Core.beakMemory.getDE() - 1));

            mClock += 2;
            tClock += 8;
        }

        public void opcode1C()
        {
            //Inc E

            Core.beakMemory.setE((byte)(Core.beakMemory.getE() + 1));

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getE() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag((((Core.beakMemory.getE()) & 0x0F) == 0) ? true : false);
        }

        public void opcode1D()
        {
            //Dec E

            Core.beakMemory.setE((byte)(Core.beakMemory.getE() - 1));

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getE() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag((((Core.beakMemory.getE()) & 0x0F) == 0xF) ? true : false);
        }

        public void opcode1E(byte n)
        {
            //Load byte into E
            Core.beakMemory.setE(n);
            mClock += 2;
            tClock += 8;
        }

        public void opcode1F()
        {
            //RRA - Rotate A Right - Store old bit 0 in Carry Flag - Current Carry flag becomes new bit 7
            //Rotate A Right - Set left most bit to current carry flag
            byte cFlag = (Core.beakMemory.getCFlag() == true) ? (byte)0x80 : (byte)0x00;
            Core.beakMemory.setCFlag((((Core.beakMemory.getA() & 0x80) >> 7) == 1) ? true : false);
            Core.beakMemory.setA((byte)((Core.beakMemory.getA() >> 1) | cFlag));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode20(byte n)
        {
            //Jump Relative to n if Not Zero
            if (!Core.beakMemory.getZFlag())
            {
                Core.beakMemory.memoryPointer += (sbyte)n;
                mClock += 3;
                tClock += 12;

            }
            else
            {
                mClock += 2;
                tClock += 8;
            }
        }

        public void opcode21(short nn)
        {
            //Load short into HL
            Core.beakMemory.setHL(nn);
            mClock += 3;
            tClock += 12;
        }

        public void opcode22()
        {
            //Load A into data at HL and increment HL
            Core.beakMemory.writeMemory((ushort)(Core.beakMemory.getHL()), Core.beakMemory.getA());
            Core.beakMemory.setHL((short)(Core.beakMemory.getHL() + 1));
            mClock += 2;
            tClock += 8;
        }

        public void opcode23()
        {
            //Inc HL

            Core.beakMemory.setHL((short)(Core.beakMemory.getHL() + 1));

            mClock += 2;
            tClock += 8;
        }

        public void opcode24()
        {
            //Inc H

            Core.beakMemory.setH((byte)(Core.beakMemory.getH() + 1));

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getH() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag((((Core.beakMemory.getH()) & 0x0F) == 0) ? true : false);
        }

        public void opcode25()
        {
            //Dec H

            Core.beakMemory.setH((byte)(Core.beakMemory.getH() - 1));

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getH() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag((((Core.beakMemory.getH()) & 0x0F) == 0xF) ? true : false);
        }

        public void opcode26(byte n)
        {
            //Load byte into H
            Core.beakMemory.setH(n);
            mClock += 2;
            tClock += 8;
        }

        public void opcode27()
        {
            //DAA Load decimal representation of A into A

            byte aValue = Core.beakMemory.getA();

            if (Core.beakMemory.getNFlag())
            {
                if (Core.beakMemory.getCFlag())
                {
                    Core.beakMemory.setCFlag(true);

                    if (Core.beakMemory.getHFlag())
                    {
                        aValue += 0x9A;
                    }
                    else
                    {
                        aValue += 0xA0;
                    }

                }
                else if (Core.beakMemory.getHFlag())
                {
                    aValue += 0xFA;
                    Core.beakMemory.setCFlag(false);
                }
            }
            else
            {
                if (Core.beakMemory.getHFlag() || ((aValue & 0x0F) > 9))
                {
                    aValue += 0x6;
                    Core.beakMemory.setCFlag(false);
                }

                if (Core.beakMemory.getCFlag() || (aValue > 0x99))
                {
                    aValue += 0x60;
                    Core.beakMemory.setCFlag(true);
                }
            }

            //beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setZFlag(aValue == 0);
            Core.beakMemory.setA((byte)(aValue & 0xFF));

            mClock += 1;
            tClock += 4;
        }

        public void opcode28(byte n)
        {
            //Jump to memoryPointer + n if Zero
            if (Core.beakMemory.getZFlag())
            {
                //memoryPointer += (signed char)n;
                Core.beakMemory.memoryPointer += (sbyte)n;
                mClock += 3;
                tClock += 12;
            }
            else
            {
                mClock += 2;
                tClock += 8;
            }
        }

        public void opcode29()
        {
            //Add HL to HL

            ushort hl = (ushort)Core.beakMemory.getHL();
            uint totalSum = (uint)(hl + hl);
            uint halfCarrySum = (uint)(hl & 0x0FFF) * 2;

            if (totalSum > 0xFFFF)
            {
                short overflow = (short)(totalSum - 65536);//0xFFFF;
                Core.beakMemory.setHL((short)(0 + overflow));
                Core.beakMemory.setCFlag(true);
                Core.beakMemory.setHFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(halfCarrySum > 0x0FFF);
                Core.beakMemory.setHL((short)(Core.beakMemory.getHL() + Core.beakMemory.getHL()));
                //Todo: Find out if half carry occurs
                Core.beakMemory.setCFlag(false);
            }
            mClock += 2;
            tClock += 8;

            //beakMemory.setZFlag(beakMemory.getHL() == 0);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode2A()
        {
            //Load data at HL to A and inc HL
            Core.beakMemory.setA(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()));
            Core.beakMemory.setHL((short)(Core.beakMemory.getHL() + 1));
            mClock += 2;
            tClock += 8;

        }

        public void opcode2B()
        {
            //Dec HL
            Core.beakMemory.setHL((short)(Core.beakMemory.getHL() - 1));
            mClock += 2;
            tClock += 8;
        }

        public void opcode2C()
        {
            //Inc L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() + 1));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getL() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag((((Core.beakMemory.getL()) & 0x0F) == 0) ? true : false);
        }

        public void opcode2D()
        {
            //Dec L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() - 1));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getL() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag((((Core.beakMemory.getL()) & 0x0F) == 0xF) ? true : false);
        }

        public void opcode2E(byte n)
        {
            //Load a byte into L
            Core.beakMemory.setL(n);
            mClock += 2;
            tClock += 8;
        }

        public void opcode2F()
        {
            //CPL - Flip all bits in A
            Core.beakMemory.setA((byte)~Core.beakMemory.getA());
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag(true);
        }

        public void opcode30(byte n)
        {
            //Jump Relative to n if Not Carry
            if (!Core.beakMemory.getCFlag())
            {
                Core.beakMemory.memoryPointer += (sbyte)n;
                mClock += 3;
                tClock += 12;
            }
            else
            {
                mClock += 2;
                tClock += 8;
            }
        }

        public void opcode31(short nn)
        {
            //Load short into SP
            Core.beakMemory.stackPointer = (ushort)nn;
            mClock += 3;
            tClock += 12;
        }

        public void opcode32()
        {
            //Load A into data at HL and dec HL
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), Core.beakMemory.getA());
            Core.beakMemory.setHL((short)(Core.beakMemory.getHL() - 1));
            mClock += 2;
            tClock += 8;
        }

        public void opcode33()
        {
            //Inc SP
            Core.beakMemory.stackPointer++;
            mClock += 2;
            tClock += 8;
        }

        public void opcode34()
        {
            //Inc data at HL
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), (byte)(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) + 1));
            mClock += 3;
            tClock += 12;

            Core.beakMemory.setZFlag((Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag((((Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL())) & 0x0F) == 0) ? true : false);
        }

        public void opcode35()
        {
            //Dec data at HL
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), (byte)(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) - 1));
            mClock += 3;
            tClock += 12;

            Core.beakMemory.setZFlag((Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag((((Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL())) & 0x0F) == 0xF) ? true : false);
        }

        public void opcode36(byte n)
        {
            //Load byte into data at HL
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), n);
            mClock += 3;
            tClock += 12;
        }

        public void opcode37()
        {
            //SCF Set Carry Flag
            Core.beakMemory.setCFlag(true);
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcode38(byte n)
        {
            //Jump Relative to n if Carry
            if (Core.beakMemory.getCFlag())
            {
                Core.beakMemory.memoryPointer += (sbyte)n;
                mClock += 3;
                tClock += 12;
            }
            else
            {
                mClock += 2;
                tClock += 8;
            }
        }

        public void opcode39()
        {
            //Add SP to HL
            if ((Core.beakMemory.getHL() + Core.beakMemory.stackPointer) > 0xFFFF)
            {
                Core.beakMemory.setHL((short)((Core.beakMemory.getHL() + Core.beakMemory.stackPointer) - 65536));//0xFFFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHL((short)(Core.beakMemory.getHL() + Core.beakMemory.stackPointer));
                //Todo: Check if half carry can occur?
            }
            mClock += 2;
            tClock += 8;

            //No Z flag from what I've found
            Core.beakMemory.setNFlag(false);
        }

        public void opcode3A()
        {
            //Load data in HL into A and decrement HL
            Core.beakMemory.setA(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()));
            Core.beakMemory.setHL((short)(Core.beakMemory.getHL() - 1));
            mClock += 2;
            tClock += 8;
        }

        public void opcode3B()
        {
            //Dec SP
            Core.beakMemory.stackPointer--;
            mClock += 2;
            tClock += 8;
        }

        public void opcode3C()
        {
            //Inc A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() + 1));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag((((Core.beakMemory.getA()) & 0x0F) == 0) ? true : false);
        }

        public void opcode3D()
        {
            //Dec A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() - 1));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag((((Core.beakMemory.getA()) & 0x0F) == 0xF) ? true : false);
        }

        public void opcode3E(byte n)
        {
            //Load byte into A
            Core.beakMemory.setA(n);
            mClock += 2;
            tClock += 8;
        }

        public void opcode3F()
        {
            //Complement Carry Flag (Toggle C Flag)
            Core.beakMemory.setCFlag((Core.beakMemory.getCFlag() == true) ? false : true);
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcode40()
        {
            //Load B into B
            Core.beakMemory.setB(Core.beakMemory.getB());
            mClock += 1;
            tClock += 4;
        }

        public void opcode41()
        {
            //Load C into B
            Core.beakMemory.setB(Core.beakMemory.getC());
            mClock += 1;
            tClock += 4;
        }

        public void opcode42()
        {
            //Load D into B
            Core.beakMemory.setB(Core.beakMemory.getD());
            mClock += 1;
            tClock += 4;
        }

        public void opcode43()
        {
            //Load E into B
            Core.beakMemory.setB(Core.beakMemory.getE());
            mClock += 1;
            tClock += 4;
        }

        public void opcode44()
        {
            //Load H into B
            Core.beakMemory.setB(Core.beakMemory.getH());
            mClock += 1;
            tClock += 4;
        }

        public void opcode45()
        {
            //Load L into B
            Core.beakMemory.setB(Core.beakMemory.getL());
            mClock += 1;
            tClock += 4;
        }

        public void opcode46()
        {
            //Load data at HL into B
            Core.beakMemory.setB(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()));
            mClock += 2;
            tClock += 8;
        }

        public void opcode47()
        {
            //Load A into B
            Core.beakMemory.setB(Core.beakMemory.getA());
            mClock += 1;
            tClock += 4;
        }

        public void opcode48()
        {
            //Load B into C
            Core.beakMemory.setC(Core.beakMemory.getB());
            mClock += 1;
            tClock += 4;
        }

        public void opcode49()
        {
            //Load C into C
            Core.beakMemory.setC(Core.beakMemory.getC());
            mClock += 1;
            tClock += 4;
        }

        public void opcode4A()
        {
            //Load D into C
            Core.beakMemory.setC(Core.beakMemory.getD());
            mClock += 1;
            tClock += 4;
        }

        public void opcode4B()
        {
            //Load E into C
            Core.beakMemory.setC(Core.beakMemory.getE());
            mClock += 1;
            tClock += 4;
        }

        public void opcode4C()
        {
            //Load H into C
            Core.beakMemory.setC(Core.beakMemory.getH());
            mClock += 1;
            tClock += 4;
        }

        public void opcode4D()
        {
            //Load L into C
            Core.beakMemory.setC(Core.beakMemory.getL());
            mClock += 1;
            tClock += 4;
        }

        public void opcode4E()
        {
            //Load data at HL into C
            Core.beakMemory.setC(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()));
            mClock += 2;
            tClock += 8;
        }

        public void opcode4F()
        {
            //Load A into C
            Core.beakMemory.setC(Core.beakMemory.getA());
            mClock += 1;
            tClock += 4;
        }

        public void opcode50()
        {
            //Load B into D
            Core.beakMemory.setD(Core.beakMemory.getB());
            mClock += 1;
            tClock += 4;
        }

        public void opcode51()
        {
            //Load C into D
            Core.beakMemory.setD(Core.beakMemory.getC());
            mClock += 1;
            tClock += 4;
        }

        public void opcode52()
        {
            //Load D into D
            Core.beakMemory.setD(Core.beakMemory.getD());
            mClock += 1;
            tClock += 4;
        }

        public void opcode53()
        {
            //Load E into D
            Core.beakMemory.setD(Core.beakMemory.getE());
            mClock += 1;
            tClock += 4;
        }

        public void opcode54()
        {
            //Load H into D
            Core.beakMemory.setD(Core.beakMemory.getH());
            mClock += 1;
            tClock += 4;
        }

        public void opcode55()
        {
            //Load L into D
            Core.beakMemory.setD(Core.beakMemory.getL());
            mClock += 1;
            tClock += 4;
        }

        public void opcode56()
        {
            //Load data at HL into D
            Core.beakMemory.setD(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()));
            mClock += 2;
            tClock += 8;
        }

        public void opcode57()
        {
            //Load A into D
            Core.beakMemory.setD(Core.beakMemory.getA());
            mClock += 1;
            tClock += 4;
        }

        public void opcode58()
        {
            //Load B into E
            Core.beakMemory.setE(Core.beakMemory.getB());
            mClock += 1;
            tClock += 4;
        }

        public void opcode59()
        {
            //Load C into E
            Core.beakMemory.setE(Core.beakMemory.getC());
            mClock += 1;
            tClock += 4;
        }

        public void opcode5A()
        {
            //Load D into E
            Core.beakMemory.setE(Core.beakMemory.getD());
            mClock += 1;
            tClock += 4;
        }

        public void opcode5B()
        {
            //Load E into E
            Core.beakMemory.setE(Core.beakMemory.getE());
            mClock += 1;
            tClock += 4;
        }

        public void opcode5C()
        {
            //Load H into E
            Core.beakMemory.setE(Core.beakMemory.getH());
            mClock += 1;
            tClock += 4;
        }

        public void opcode5D()
        {
            //Load L into D
            Core.beakMemory.setE(Core.beakMemory.getL());
            mClock += 1;
            tClock += 4;
        }

        public void opcode5E()
        {
            //Load data at HL into E
            Core.beakMemory.setE(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()));
            mClock += 2;
            tClock += 8;
        }

        public void opcode5F()
        {
            //Load A into E
            Core.beakMemory.setE(Core.beakMemory.getA());
            mClock += 1;
            tClock += 4;
        }

        public void opcode60()
        {
            //Load B into H
            Core.beakMemory.setH(Core.beakMemory.getB());
            mClock += 1;
            tClock += 4;
        }

        public void opcode61()
        {
            //Load C into H
            Core.beakMemory.setH(Core.beakMemory.getC());
            mClock += 1;
            tClock += 4;
        }

        public void opcode62()
        {
            //Load D into H
            Core.beakMemory.setH(Core.beakMemory.getD());
            mClock += 1;
            tClock += 4;
        }

        public void opcode63()
        {
            //Load E into H
            Core.beakMemory.setH(Core.beakMemory.getE());
            mClock += 1;
            tClock += 4;
        }

        public void opcode64()
        {
            //Load H into H
            Core.beakMemory.setH(Core.beakMemory.getH());
            mClock += 1;
            tClock += 4;
        }

        public void opcode65()
        {
            //Load L into H
            Core.beakMemory.setH(Core.beakMemory.getL());
            mClock += 1;
            tClock += 4;
        }

        public void opcode66()
        {
            //Load data at HL into H
            Core.beakMemory.setH(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()));
            mClock += 2;
            tClock += 8;
        }

        public void opcode67()
        {
            //Load A into H
            Core.beakMemory.setH(Core.beakMemory.getA());
            mClock += 1;
            tClock += 4;
        }

        public void opcode68()
        {
            //Load B into L
            Core.beakMemory.setL(Core.beakMemory.getB());
            mClock += 1;
            tClock += 4;
        }

        public void opcode69()
        {
            //Load C into L
            Core.beakMemory.setL(Core.beakMemory.getC());
            mClock += 1;
            tClock += 4;
        }

        public void opcode6A()
        {
            //Load D into L
            Core.beakMemory.setL(Core.beakMemory.getD());
            mClock += 1;
            tClock += 4;
        }

        public void opcode6B()
        {
            //Load E into L
            Core.beakMemory.setL(Core.beakMemory.getE());
            mClock += 1;
            tClock += 4;
        }

        public void opcode6C()
        {
            //Load H into L
            Core.beakMemory.setL(Core.beakMemory.getH());
            mClock += 1;
            tClock += 4;
        }

        public void opcode6D()
        {
            //Load L into L
            Core.beakMemory.setL(Core.beakMemory.getL());
            mClock += 1;
            tClock += 4;
        }

        public void opcode6E()
        {
            //Load data at HL into L
            Core.beakMemory.setL(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()));
            mClock += 2;
            tClock += 8;
        }

        public void opcode6F()
        {
            //Load A into L
            Core.beakMemory.setL(Core.beakMemory.getA());
            mClock += 1;
            tClock += 4;
        }

        public void opcode70()
        {
            //Load B into data at HL
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), Core.beakMemory.getB());
            mClock += 2;
            tClock += 8;
        }

        public void opcode71()
        {
            //Load C into data at HL
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), Core.beakMemory.getC());
            mClock += 2;
            tClock += 8;
        }

        public void opcode72()
        {
            //Load D into data at HL
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), Core.beakMemory.getD());
            mClock += 2;
            tClock += 8;
        }

        public void opcode73()
        {
            //Load E into data at HL
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), Core.beakMemory.getE());
            mClock += 2;
            tClock += 8;
        }

        public void opcode74()
        {
            //Load H into data at HL
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), Core.beakMemory.getH());
            mClock += 2;
            tClock += 8;
        }

        public void opcode75()
        {
            //Load L into data at HL
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), Core.beakMemory.getL());
            mClock += 2;
            tClock += 8;
        }

        public void opcode76()
        {
            //Halt

            if (checkForInterrupt() && !interruptsEnabled) //If interrupt true while IME is disabled, repeat next opcode.
            {
                repeat = true;
            }
            else
            {
                halt = true; //Halt should only be set if the first case is not true.
            }

            mClock += 1;
            tClock += 4;
        }

        public void opcode77()
        {
            //Load A into data at HL
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), Core.beakMemory.getA());
            mClock += 2;
            tClock += 8;
        }

        public void opcode78()
        {
            //Load B into A
            Core.beakMemory.setA(Core.beakMemory.getB());
            mClock += 1;
            tClock += 4;
        }

        public void opcode79()
        {
            //Load C into A
            Core.beakMemory.setA(Core.beakMemory.getC());
            mClock += 1;
            tClock += 4;
        }

        public void opcode7A()
        {
            //Load D into A
            Core.beakMemory.setA(Core.beakMemory.getD());
            mClock += 1;
            tClock += 4;
        }

        public void opcode7B()
        {
            //Load E into A
            Core.beakMemory.setA(Core.beakMemory.getE());
            mClock += 1;
            tClock += 4;
        }

        public void opcode7C()
        {
            //Load H into A
            Core.beakMemory.setA(Core.beakMemory.getH());
            mClock += 1;
            tClock += 4;
        }

        public void opcode7D()
        {
            //Load L into A
            Core.beakMemory.setA(Core.beakMemory.getL());
            mClock += 1;
            tClock += 4;
        }

        public void opcode7E()
        {
            //Load data at HL into A
            Core.beakMemory.setA(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()));
            mClock += 2;
            tClock += 8;
        }

        public void opcode7F()
        {
            //Load A into A
            Core.beakMemory.setA(Core.beakMemory.getA());
            mClock += 1;
            tClock += 4;
        }

        public void opcode80()
        {
            //Add B to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getB()) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.getB()) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getB() & 0x0F)) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getB() + beakMemory.getA()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getB()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode81()
        {
            //Add C to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getC()) > 0xFF)
            {
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getC() - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getC() & 0x0F)) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getC() + beakMemory.getA()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getC()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode82()
        {
            //Add D to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getD()) > 0xFF)
            {
                Core.beakMemory.setA((byte)(((Core.beakMemory.getA() + Core.beakMemory.getD()) - 256)));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getD() & 0x0F)) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getC() + beakMemory.getA()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getD()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode83()
        {
            //Add E to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getE()) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.getE()) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getE() & 0x0F)) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getE() + beakMemory.getA()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getE()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode84()
        {
            //Add H to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getH()) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.getH()) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getH() & 0x0F)) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getH() + beakMemory.getA()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getH()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode85()
        {
            //Add L to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getL()) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.getL()) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getL() & 0x0F)) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getL() + beakMemory.getA()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getL()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode86()
        {
            //Add data at HL to A
            if ((Core.beakMemory.getA() + Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL())) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL())) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) & 0x0F)) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.readMemory(beakMemory.getHL()) + beakMemory.getA()) > 0x0F));
                //beakMemory.setHFlag(((beakMemory.getA() | beakMemory.readMemory(beakMemory.getHL())) <= 0x0F) && (beakMemory.getA() + (beakMemory.readMemory(beakMemory.getHL())) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL())));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode87()
        {
            //Add A to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getA()) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.getA()) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getA() & 0x0F)) > 0x0F);
                //beakMemory.setHFlag(((beakMemory.getA() | beakMemory.getA()) <= 0x0F) && ((beakMemory.getA() + beakMemory.getA()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getA()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode88()
        {
            //Add B and Carry flag to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getB() + Convert.ToByte(Core.beakMemory.getCFlag())) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.getB() + Convert.ToByte(Core.beakMemory.getCFlag())) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getB() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getB() + beakMemory.getA() + beakMemory.getCFlag()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getB() + Convert.ToByte(Core.beakMemory.getCFlag())));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode89()
        {
            //Add C and Carry flag to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getC() + Convert.ToByte(Core.beakMemory.getCFlag())) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.getC() + Convert.ToByte(Core.beakMemory.getCFlag())) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getC() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getC() + beakMemory.getA() + beakMemory.getCFlag()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getC() + Convert.ToByte(Core.beakMemory.getCFlag())));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode8A()
        {
            //Add D and Carry flag to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getD() + Convert.ToByte(Core.beakMemory.getCFlag())) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.getD() + Convert.ToByte(Core.beakMemory.getCFlag())) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getD() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getD() + beakMemory.getA() + beakMemory.getCFlag()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getD() + Convert.ToByte(Core.beakMemory.getCFlag())));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode8B()
        {
            //Add E and Carry flag to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getE() + Convert.ToByte(Core.beakMemory.getCFlag())) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.getE() + Convert.ToByte(Core.beakMemory.getCFlag())) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getE() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getE() + beakMemory.getA() + beakMemory.getCFlag()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getE() + Convert.ToByte(Core.beakMemory.getCFlag())));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode8C()
        {
            //Add H and Carry flag to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getH() + Convert.ToByte(Core.beakMemory.getCFlag())) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.getH() + Convert.ToByte(Core.beakMemory.getCFlag())) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getH() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getH() + beakMemory.getA() + beakMemory.getCFlag()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getH() + Convert.ToByte(Core.beakMemory.getCFlag())));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode8D()
        {
            //Add L and Carry flag to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getL() + Convert.ToByte(Core.beakMemory.getCFlag())) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.getL() + Convert.ToByte(Core.beakMemory.getCFlag())) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getL() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getL() + beakMemory.getA() + beakMemory.getCFlag()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getL() + Convert.ToByte(Core.beakMemory.getCFlag())));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode8E()
        {
            //Add data at HL and Carry flag to A
            if ((Core.beakMemory.getA() + Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) + Convert.ToByte(Core.beakMemory.getCFlag())) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) + Convert.ToByte(Core.beakMemory.getCFlag())) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.readMemory(beakMemory.getHL()) + beakMemory.getA() + beakMemory.getCFlag()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) + Convert.ToByte(Core.beakMemory.getCFlag())));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode8F()
        {
            //Add A and Carry flag to A
            if ((Core.beakMemory.getA() + Core.beakMemory.getA() + Convert.ToByte(Core.beakMemory.getCFlag())) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + Core.beakMemory.getA() + Convert.ToByte(Core.beakMemory.getCFlag())) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (Core.beakMemory.getA() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getA() + beakMemory.getA() + beakMemory.getCFlag()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + Core.beakMemory.getA() + Convert.ToByte(Core.beakMemory.getCFlag())));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcode90()
        {
            //Sub B from A
            if ((Core.beakMemory.getA() - Core.beakMemory.getB()) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - Core.beakMemory.getB()) + 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setCFlag(Core.beakMemory.getA() < Core.beakMemory.getB());
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.getB() & 0x0F));
                //beakMemory.setHFlag(beakMemory.getA() < beakMemory.getB());
                //beakMemory.setHFlag((beakMemory.getA() > 0x0F) && ((beakMemory.getA() - beakMemory.getB()) <= 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - Core.beakMemory.getB()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                //beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode91()
        {
            //Sub C from A
            if ((Core.beakMemory.getA() - Core.beakMemory.getC()) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - Core.beakMemory.getC()) + 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setCFlag(Core.beakMemory.getA() < Core.beakMemory.getC());
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.getC() & 0x0F));
                //beakMemory.setHFlag(beakMemory.getA() < beakMemory.getC());
                //beakMemory.setHFlag((beakMemory.getA() > 0x0F) && ((beakMemory.getA() - beakMemory.getC()) <= 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - Core.beakMemory.getC()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                //beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode92()
        {
            //Sub D from A
            if ((Core.beakMemory.getA() - Core.beakMemory.getD()) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - Core.beakMemory.getD()) + 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setCFlag(Core.beakMemory.getA() < Core.beakMemory.getD());
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.getD() & 0x0F));
                //beakMemory.setHFlag(beakMemory.getA() < beakMemory.getD());
                //beakMemory.setHFlag((beakMemory.getA() > 0x0F) && ((beakMemory.getA() - beakMemory.getD()) <= 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - Core.beakMemory.getD()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                //beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode93()
        {
            //Sub E from A
            if ((Core.beakMemory.getA() - Core.beakMemory.getE()) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - Core.beakMemory.getE()) + 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setCFlag(Core.beakMemory.getA() < Core.beakMemory.getE());
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.getE() & 0x0F));
                //beakMemory.setHFlag(beakMemory.getA() < beakMemory.getE());
                //beakMemory.setHFlag((beakMemory.getA() > 0x0F) && ((beakMemory.getA() - beakMemory.getE()) <= 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - Core.beakMemory.getE()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                //beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode94()
        {
            //Sub B from H
            if ((Core.beakMemory.getA() - Core.beakMemory.getH()) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - Core.beakMemory.getH()) + 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setCFlag(Core.beakMemory.getA() < Core.beakMemory.getH());
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.getH() & 0x0F));
                //beakMemory.setHFlag(beakMemory.getA() < beakMemory.getH());
                //beakMemory.setHFlag((beakMemory.getA() > 0x0F) && ((beakMemory.getA() - beakMemory.getH()) <= 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - Core.beakMemory.getH()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                //beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode95()
        {
            //Sub L from A
            if ((Core.beakMemory.getA() - Core.beakMemory.getL()) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - Core.beakMemory.getL()) + 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setCFlag(Core.beakMemory.getA() < Core.beakMemory.getL());
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.getL() & 0x0F));
                //beakMemory.setHFlag((beakMemory.getA() > 0x0F) && ((beakMemory.getA() - beakMemory.getL()) <= 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - Core.beakMemory.getL()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                //beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode96()
        {
            //Sub data at HL from A
            if ((Core.beakMemory.getA() - Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL())) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL())) + 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setCFlag(Core.beakMemory.getA() < Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()));
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) & 0x0F));
                //beakMemory.setHFlag(beakMemory.getA() < beakMemory.readMemory(beakMemory.getHL()));
                //beakMemory.setHFlag((beakMemory.getA() > 0x0F) && ((beakMemory.getA() - beakMemory.readMemory(beakMemory.getHL())) <= 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL())));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                //beakMemory.setCFlag(false);
            }

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode97()
        {
            //Sub A from A
            if ((Core.beakMemory.getA() - Core.beakMemory.getA()) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - Core.beakMemory.getA()) + 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setCFlag(false);
                Core.beakMemory.setHFlag(false);
                //beakMemory.setHFlag(beakMemory.getA() < beakMemory.getA());
                //beakMemory.setHFlag((beakMemory.getA() > 0x0F) && ((beakMemory.getA() - beakMemory.getA()) <= 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - Core.beakMemory.getA()));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                //beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode98()
        {
            //Sub B and Carry flag from A
            if ((Core.beakMemory.getA() - (Core.beakMemory.getB() + Convert.ToByte(Core.beakMemory.getCFlag()))) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - (Core.beakMemory.getB() + Convert.ToByte(Core.beakMemory.getCFlag()))) + 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < ((Core.beakMemory.getB() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - (Core.beakMemory.getB() + Convert.ToByte(Core.beakMemory.getCFlag()))));
                Core.beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode99()
        {
            //Sub C and Carry flag from A
            if ((Core.beakMemory.getA() - (Core.beakMemory.getC() + Convert.ToByte(Core.beakMemory.getCFlag()))) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - (Core.beakMemory.getC() + Convert.ToByte(Core.beakMemory.getCFlag()))) + 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < ((Core.beakMemory.getC() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - (Core.beakMemory.getC() + Convert.ToByte(Core.beakMemory.getCFlag()))));
                Core.beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode9A()
        {
            //Sub D and Carry flag from A
            if ((Core.beakMemory.getA() - (Core.beakMemory.getD() + Convert.ToByte(Core.beakMemory.getCFlag()))) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - (Core.beakMemory.getD() + Convert.ToByte(Core.beakMemory.getCFlag()))) + 256));
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < ((Core.beakMemory.getD() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - (Core.beakMemory.getD() + Convert.ToByte(Core.beakMemory.getCFlag()))));
                Core.beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode9B()
        {
            //Sub E and Carry flag from A
            if ((Core.beakMemory.getA() - (Core.beakMemory.getE() + Convert.ToByte(Core.beakMemory.getCFlag()))) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - (Core.beakMemory.getE() + Convert.ToByte(Core.beakMemory.getCFlag()))) + 256));
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < ((Core.beakMemory.getE() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - (Core.beakMemory.getE() + Convert.ToByte(Core.beakMemory.getCFlag()))));
                Core.beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode9C()
        {
            //Sub H and Carry flag from A
            if ((Core.beakMemory.getA() - (Core.beakMemory.getH() + Convert.ToByte(Core.beakMemory.getCFlag()))) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - (Core.beakMemory.getH() + Convert.ToByte(Core.beakMemory.getCFlag()))) + 256));
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < ((Core.beakMemory.getH() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - (Core.beakMemory.getH() + Convert.ToByte(Core.beakMemory.getCFlag()))));
                Core.beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode9D()
        {
            //Sub L and Carry flag from A
            if ((Core.beakMemory.getA() - (Core.beakMemory.getL() + Convert.ToByte(Core.beakMemory.getCFlag()))) < 0x00)
            {
                Core.beakMemory.setA((byte)(((Core.beakMemory.getA() & 0x0F) - ((Core.beakMemory.getL() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag()))) + 256));
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(Core.beakMemory.getA() < (Core.beakMemory.getL() + Convert.ToByte(Core.beakMemory.getCFlag())));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - (Core.beakMemory.getL() + Convert.ToByte(Core.beakMemory.getCFlag()))));
                Core.beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode9E()
        {
            //Sub data at HL and Carry flag from A
            if ((Core.beakMemory.getA() - (Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) + Convert.ToByte(Core.beakMemory.getCFlag()))) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - (Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) + Convert.ToByte(Core.beakMemory.getCFlag()))) + 256));
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < ((Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - (Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) + Convert.ToByte(Core.beakMemory.getCFlag()))));
                Core.beakMemory.setCFlag(false);
            }

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcode9F()
        {
            //Sub A and Carry flag from A
            if ((Core.beakMemory.getA() - (Core.beakMemory.getA() + Convert.ToByte(Core.beakMemory.getCFlag()))) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - (Core.beakMemory.getA() + Convert.ToByte(Core.beakMemory.getCFlag()))) + 256));
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < ((Core.beakMemory.getA() & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - (Core.beakMemory.getA() + Convert.ToByte(Core.beakMemory.getCFlag()))));
                Core.beakMemory.setCFlag(false);
            }

            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcodeA0()
        {
            //And B from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & Core.beakMemory.getB()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeA1()
        {
            //And C from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & Core.beakMemory.getC()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeA2()
        {
            //And D from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & Core.beakMemory.getD()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeA3()
        {
            //And E from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & Core.beakMemory.getE()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeA4()
        {
            //And H from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & Core.beakMemory.getH()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeA5()
        {
            //And L from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & Core.beakMemory.getL()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeA6()
        {
            //And (HL) from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL())));
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeA7()
        {
            //And A from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & Core.beakMemory.getA()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeA8()
        {
            //XOR B from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() ^ Core.beakMemory.getB()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeA9()
        {
            //XOR C from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() ^ Core.beakMemory.getC()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeAA()
        {
            //XOR D from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() ^ Core.beakMemory.getD()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeAB()
        {
            //XOR E from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() ^ Core.beakMemory.getE()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeAC()
        {
            //XOR H from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() ^ Core.beakMemory.getH()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeAD()
        {
            //XOR L from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() ^ Core.beakMemory.getL()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeAE()
        {
            //XOR data at HL from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() ^ Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL())));
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeAF()
        {
            //XOR A from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() ^ Core.beakMemory.getA()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeB0()
        {
            //OR B from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | Core.beakMemory.getB()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeB1()
        {
            //OR C from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | Core.beakMemory.getC()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeB2()
        {
            //OR D from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | Core.beakMemory.getD()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeB3()
        {
            //OR E from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | Core.beakMemory.getE()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeB4()
        {
            //OR H from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | Core.beakMemory.getH()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeB5()
        {
            //OR L from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | Core.beakMemory.getL()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeB6()
        {
            //OR (HL) from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL())));
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeB7()
        {
            //OR A from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | Core.beakMemory.getA()));
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeB8()
        {
            //Compare B with A
            //byte test = beakMemory.getA() - beakMemory.getB();
            mClock += 1;
            tClock += 4;
            /*
            beakMemory.setZFlag((test == 0) ? 1 : 0); //set if A == n?
            beakMemory.setNFlag(true);
            //flagH set if no borrow from bit 4
            beakMemory.setHFlag((test > beakMemory.getA())); //check this
            //flagC set if no borrow (Set if A < n)
            beakMemory.setCFlag((test < 0) ? 1 : 0); //check this
            */

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == Core.beakMemory.getB()) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.getB() & 0x0F)) ? true : false);
            Core.beakMemory.setCFlag((Core.beakMemory.getA() < Core.beakMemory.getB()) ? true : false);
        }

        public void opcodeB9()
        {
            //Compare C with A
            int test = Core.beakMemory.getA() - Core.beakMemory.getC();
            mClock += 1;
            tClock += 4;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == Core.beakMemory.getC()) ? true : false);
            Core.beakMemory.setNFlag(true);
            //beakMemory.setHFlag((beakMemory.getA() > beakMemory.getC()));
            Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.getC() & 0x0F)) ? true : false);
            Core.beakMemory.setCFlag((Core.beakMemory.getA() < Core.beakMemory.getC()) ? true : false);
        }

        public void opcodeBA()
        {
            //Compare D with A
            byte test = (byte)(Core.beakMemory.getA() - Core.beakMemory.getD());
            mClock += 1;
            tClock += 4;

            /*
            beakMemory.setZFlag((test == 0) ? 1 : 0);
            beakMemory.setNFlag(true);
            beakMemory.setHFlag((test > beakMemory.getA()));
            beakMemory.setCFlag((test < 0) ? 1 : 0);
            */

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == Core.beakMemory.getD()) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.getD() & 0x0F)) ? true : false);
            Core.beakMemory.setCFlag((Core.beakMemory.getA() < Core.beakMemory.getD()) ? true : false);
        }

        public void opcodeBB()
        {
            //Compare E with A
            byte test = (byte)(Core.beakMemory.getA() - Core.beakMemory.getE());
            mClock += 1;
            tClock += 4;
            /*
            beakMemory.setZFlag((test == 0) ? 1 : 0);
            beakMemory.setNFlag(true);
            beakMemory.setHFlag((test > beakMemory.getA()));
            beakMemory.setCFlag((test < 0) ? 1 : 0);
            */
            Core.beakMemory.setZFlag((Core.beakMemory.getA() == Core.beakMemory.getE()) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.getE() & 0x0F)) ? true : false);
            Core.beakMemory.setCFlag((Core.beakMemory.getA() < Core.beakMemory.getE()) ? true : false);
        }

        public void opcodeBC()
        {
            //Compare H with A
            byte test = (byte)(Core.beakMemory.getA() - Core.beakMemory.getH());
            mClock += 1;
            tClock += 4;
            /*
            beakMemory.setZFlag((test == 0) ? 1 : 0);
            beakMemory.setNFlag(true);
            beakMemory.setHFlag((test > beakMemory.getA()));
            beakMemory.setCFlag((test < 0) ? 1 : 0);
            */
            Core.beakMemory.setZFlag((Core.beakMemory.getA() == Core.beakMemory.getH()) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.getH() & 0x0F)) ? true : false);
            Core.beakMemory.setCFlag((Core.beakMemory.getA() < Core.beakMemory.getH()) ? true : false);
        }

        public void opcodeBD()
        {
            //Compare L with A
            byte test = (byte)(Core.beakMemory.getA() - Core.beakMemory.getL());
            mClock += 1;
            tClock += 4;

            //beakMemory.setZFlag((test == 0) ? 1 : 0);
            //beakMemory.setNFlag(true);
            //beakMemory.setHFlag((test > beakMemory.getA()));
            //beakMemory.setCFlag((test < 0) ? 1 : 0);

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == Core.beakMemory.getL()) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.getL() & 0x0F)) ? true : false);
            Core.beakMemory.setCFlag((Core.beakMemory.getA() < Core.beakMemory.getL()) ? true : false);
        }

        public void opcodeBE()
        {
            //Compare data at HL with A
            //short test = beakMemory.getA() - beakMemory.getHL();
            byte n = Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL());
            mClock += 2;
            tClock += 8;

            //beakMemory.setZFlag((test == 0) ? 1 : 0);
            //beakMemory.setNFlag(true);
            //beakMemory.setHFlag((test > beakMemory.getA()));
            //beakMemory.setCFlag((test < 0) ? 1 : 0);

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == n) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) < (n & 0x0F)) ? true : false);
            Core.beakMemory.setCFlag((Core.beakMemory.getA() < n) ? true : false);
        }

        public void opcodeBF()
        {
            //Compare A with A
            //byte test = beakMemory.getA() - beakMemory.getA();
            mClock += 1;
            tClock += 4;

            //beakMemory.setZFlag((test == 0) ? 1 : 0);
            //beakMemory.setNFlag(true);
            //beakMemory.setHFlag((test > beakMemory.getA()));
            //beakMemory.setCFlag((test < 0) ? 1 : 0);

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == Core.beakMemory.getA()) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) < (Core.beakMemory.getA() & 0x0F)) ? true : false);
            Core.beakMemory.setCFlag((Core.beakMemory.getA() < Core.beakMemory.getA()) ? true : false);
        }

        public void opcodeC0()
        {
            //RET if Not Zero
            if (!Core.beakMemory.getZFlag())
            {
                Core.beakMemory.memoryPointer = (ushort)((Core.beakMemory.readMemory((ushort)(Core.beakMemory.stackPointer + 1)) << 8) | (Core.beakMemory.readMemory(Core.beakMemory.stackPointer)));
                Core.beakMemory.stackPointer += 2;
                mClock += 5;
                tClock += 20;
            }
            else
            {
                mClock += 2;
                tClock += 8;
            }
        }

        public void opcodeC1()
        {
            //POP into BC
            Core.beakMemory.setBC((short)((Core.beakMemory.readMemory((ushort)(Core.beakMemory.stackPointer + 1)) << 8) | (Core.beakMemory.readMemory(Core.beakMemory.stackPointer))));
            Core.beakMemory.stackPointer += 2;
            mClock += 3;
            tClock += 12;
        }

        public void opcodeC2(short nn)
        {
            //Jump if Not Zero
            if (!Core.beakMemory.getZFlag())
            {
                Core.beakMemory.memoryPointer = (ushort)nn;
                mClock += 4;
                tClock += 16;
            }
            else
            {
                mClock += 3;
                tClock += 12;
            }
        }

        public void opcodeC3(short nn)
        {
            //Jump to NNNN
            Core.beakMemory.memoryPointer = (ushort)nn;
            mClock += 4;
            tClock += 16;
        }

        public void opcodeC4(short nn)
        {
            //Call nn if Not Zero
            if (!Core.beakMemory.getZFlag())
            {
                Core.beakMemory.stackPointer -= 2;
                Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);
                Core.beakMemory.memoryPointer = (ushort)nn;
                mClock += 6;
                tClock += 24;
            }
            else
            {
                mClock += 3;
                tClock += 12;
            }
        }

        public void opcodeC5()
        {
            //Push BC
            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, Core.beakMemory.getBC());
            mClock += 4;
            tClock += 16;
        }

        public void opcodeC6(byte n)
        {
            //Add byte to A
            if ((Core.beakMemory.getA() + n) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + n) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (n & 0x0F)) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getA() + n) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + n));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcodeC7()
        {
            //Reset to 00
            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);
            Core.beakMemory.memoryPointer = 0x00;
            mClock += 4;
            tClock += 16;

        }

        public void opcodeC8()
        {
            //Ret if Zero
            if (Core.beakMemory.getZFlag())
            {
                Core.beakMemory.memoryPointer = (ushort)((Core.beakMemory.readMemory((ushort)(Core.beakMemory.stackPointer + 1)) << 8) | (Core.beakMemory.readMemory((ushort)(Core.beakMemory.stackPointer))));
                Core.beakMemory.stackPointer += 2;
                mClock += 5;
                tClock += 20;
            }
            else
            {
                mClock += 2;
                tClock += 8;
            }
        }

        public void opcodeC9()
        {
            //Ret
            Core.beakMemory.memoryPointer = (ushort)((Core.beakMemory.readMemory((ushort)(Core.beakMemory.stackPointer + 1)) << 8) | (Core.beakMemory.readMemory(Core.beakMemory.stackPointer)));
            Core.beakMemory.stackPointer += 2;
            mClock += 4;
            tClock += 16;
        }

        public void opcodeCA(short nn)
        {
            //Jump to nn if Zero
            if (Core.beakMemory.getZFlag())
            {
                Core.beakMemory.memoryPointer = (ushort)nn;
                mClock += 4;
                tClock += 16;
            }
            else
            {
                mClock += 3;
                tClock += 12;
            }
        }

        public void opcodeCC(short nn)
        {
            //Call nn if Zero
            if (Core.beakMemory.getZFlag())
            {
                Core.beakMemory.stackPointer -= 2;
                Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);
                Core.beakMemory.memoryPointer = (ushort)nn;
                mClock += 6;
                tClock += 24;
            }
            else
            {
                mClock += 3;
                tClock += 12;
            }
        }

        public void opcodeCD(short nn)
        {
            //Call nn
            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);
            Core.beakMemory.memoryPointer = (ushort)nn;
            mClock += 6;
            tClock += 24;
        }

        public void opcodeCE(byte n)
        {
            //Add n and Carry flag to A
            //beakMemory.setA(beakMemory.getA() + n + beakMemory.getCFlag());
            if ((Core.beakMemory.getA() + n + Convert.ToByte(Core.beakMemory.getCFlag())) > 0xFF)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() + n + Convert.ToByte(Core.beakMemory.getCFlag())) - 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) + (n & 0x0F) + Convert.ToByte(Core.beakMemory.getCFlag())) > 0x0F);
                //beakMemory.setHFlag((beakMemory.getA() <= 0x0F) && ((beakMemory.getA() + n + beakMemory.getCFlag()) > 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() + n + Convert.ToByte(Core.beakMemory.getCFlag())));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getA() == 0);
            Core.beakMemory.setNFlag(false);
        }

        public void opcodeCF()
        {
            //Reset to 08
            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);
            Core.beakMemory.memoryPointer = 0x08;
            mClock += 4;
            tClock += 16;
        }

        public void opcodeD0()
        {
            //Ret if not Carry
            if (!Core.beakMemory.getCFlag())
            {
                Core.beakMemory.memoryPointer = (ushort)((Core.beakMemory.readMemory((ushort)(Core.beakMemory.stackPointer + 1)) << 8) | (Core.beakMemory.readMemory(Core.beakMemory.stackPointer)));
                Core.beakMemory.stackPointer += 2;
                mClock += 5;
                tClock += 20;
            }
            else
            {
                mClock += 2;
                tClock += 8;
            }
        }

        public void opcodeD1()
        {
            //POP DE
            Core.beakMemory.setDE((short)(((Core.beakMemory.readMemory((ushort)(Core.beakMemory.stackPointer + 1)) << 8) | (Core.beakMemory.readMemory(Core.beakMemory.stackPointer)))));
            Core.beakMemory.stackPointer += 2;
            mClock += 3;
            tClock += 12;
        }

        public void opcodeD2(short nn)
        {
            //Jump to nn if not Carry
            if (!Core.beakMemory.getCFlag())
            {
                Core.beakMemory.memoryPointer = (ushort)nn;
                mClock += 4;
                tClock += 16;
            }
            else
            {
                mClock += 3;
                tClock += 12;
            }
        }

        //Opcode D3 does not exist?

        public void opcodeD4(short nn)
        {
            //Call nn if Not Carry
            if (!Core.beakMemory.getCFlag())
            {
                Core.beakMemory.stackPointer -= 2;
                Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);
                Core.beakMemory.memoryPointer = (ushort)nn;
                mClock += 6;
                tClock += 24;
            }
            else
            {
                mClock += 3;
                tClock += 12;
            }
        }

        public void opcodeD5()
        {
            //Push DE
            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, Core.beakMemory.getDE());
            mClock += 4;
            tClock += 16;
        }

        public void opcodeD6(byte n)
        {
            //Subtract n from A

            if ((Core.beakMemory.getA() - n) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - n) + 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag((Core.beakMemory.getA() & 0x0F) < (n & 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - n));
                Core.beakMemory.setCFlag(false);
            }

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);

        }

        public void opcodeD7()
        {
            //Reset to 10
            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);
            Core.beakMemory.memoryPointer = 0x10;
            mClock += 4;
            tClock += 16;
        }

        public void opcodeD8()
        {
            //Ret if Carry
            if (Core.beakMemory.getCFlag())
            {
                Core.beakMemory.memoryPointer = (ushort)((Core.beakMemory.readMemory((ushort)(Core.beakMemory.stackPointer + 1)) << 8) | (Core.beakMemory.readMemory(Core.beakMemory.stackPointer)));
                Core.beakMemory.stackPointer += 2;
                mClock += 5;
                tClock += 20;
            }
            else
            {
                mClock += 2;
                tClock += 8;
            }
        }

        public void opcodeD9()
        {
            //Return and enable Interrupts
            Core.beakMemory.memoryPointer = (ushort)((Core.beakMemory.readMemory((ushort)(Core.beakMemory.stackPointer + 1)) << 8) | (Core.beakMemory.readMemory((ushort)Core.beakMemory.stackPointer)));
            Core.beakMemory.stackPointer += 2;
            interruptsEnabled = true;
            mClock += 4;
            tClock += 16;
        }

        public void opcodeDA(short nn)
        {
            //Jump to nn if Carry
            if (Core.beakMemory.getCFlag())
            {
                Core.beakMemory.memoryPointer = (ushort)nn;
                mClock += 4;
                tClock += 16;
            }
            else
            {
                mClock += 3;
                tClock += 12;
            }
        }

        //Opcode DB does not exist?

        public void opcodeDC(short nn)
        {
            //Call nn if Carry
            if (Core.beakMemory.getCFlag())
            {
                Core.beakMemory.stackPointer -= 2;
                Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);
                Core.beakMemory.memoryPointer = (ushort)nn;
                mClock += 6;
                tClock += 24;
            }
            else
            {
                mClock += 3;
                tClock += 12;
            }
        }

        //Opcode DD does not exist?

        public void opcodeDE(byte n)
        {
            //Sub n and Carry flag from A
            if ((Core.beakMemory.getA() - (n + Convert.ToByte(Core.beakMemory.getCFlag()))) < 0x00)
            {
                Core.beakMemory.setA((byte)((Core.beakMemory.getA() - (n + Convert.ToByte(Core.beakMemory.getCFlag()))) + 256));//0xFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
            else
            {
                Core.beakMemory.setHFlag((Core.beakMemory.getA() < (n + Convert.ToByte(Core.beakMemory.getCFlag()))));
                //beakMemory.setHFlag((beakMemory.getA() > 0x0F) && (beakMemory.getA() - (n + beakMemory.getCFlag()) <= 0x0F));
                Core.beakMemory.setA((byte)(Core.beakMemory.getA() - (n + Convert.ToByte(Core.beakMemory.getCFlag()))));
                //beakMemory.setHFlag((((beakMemory.getA()) & 0x0F) == 0xF) ? 1 : 0);
                Core.beakMemory.setCFlag(false);
            }

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(true);
        }

        public void opcodeDF()
        {
            //Reset to 18
            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);
            Core.beakMemory.memoryPointer = 0x18;
            mClock += 4;
            tClock += 16;
        }

        public void opcodeE0(byte n)
        {
            //Load A into address at (FF00 + n)
            Core.beakMemory.writeMemory((ushort)(0xFF00 + n), Core.beakMemory.getA());
            mClock += 3;
            tClock += 12;
        }

        public void opcodeE1()
        {
            //Pop HL
            Core.beakMemory.setHL(((short)(Core.beakMemory.readMemory((ushort)((Core.beakMemory.stackPointer + 1) << 8)) | (Core.beakMemory.readMemory(Core.beakMemory.stackPointer)))));
            Core.beakMemory.stackPointer += 2;
            mClock += 3;
            tClock += 12;
        }

        public void opcodeE2()
        {
            //Load A into address at (FF00 + C)
            Core.beakMemory.writeMemory((ushort)(0xFF00 + Core.beakMemory.getC()), Core.beakMemory.getA());
            mClock += 2;
            tClock += 8;
        }

        //Opcode E3 does not exist?

        //Opcode E4 does not exist?

        public void opcodeE5()
        {
            //Push HL
            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, Core.beakMemory.getHL());
            mClock += 4;
            tClock += 16;
        }

        public void opcodeE6(byte n)
        {
            //And n from A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & n));
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeE7()
        {
            //Reset to 20
            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);
            Core.beakMemory.memoryPointer = 0x20;
            mClock += 4;
            tClock += 16;
        }

        public void opcodeE8(sbyte n)
        {
            //Add n to Stack Pointer

            if ((Core.beakMemory.stackPointer + (sbyte)n) > 0xFFFF)
	        {
                Core.beakMemory.setStackPointer(((ushort)(Core.beakMemory.stackPointer + (sbyte)n - 65536)));//0xFFFF);
                Core.beakMemory.setHFlag(true);
                Core.beakMemory.setCFlag(true);
            }
	        else
	        {
                Core.beakMemory.setHFlag(((Core.beakMemory.stackPointer & 0x0F) + ((char)n & 0x0F)) > 0x0F);
                Core.beakMemory.setStackPointer((ushort)(Core.beakMemory.stackPointer + (char)n));
                //beakMemory.setHFlag((stackPointer & 0x00FF) == 0xF0);
                Core.beakMemory.setCFlag(false);
            }
            mClock += 4;
            tClock += 16;

            //beakMemory.setZFlag(stackPointer > 0); //From tests in BGB this is not set
            Core.beakMemory.setZFlag(false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcodeE9()
        {
            //Jump to HL
            Core.beakMemory.memoryPointer = (ushort)Core.beakMemory.getHL();
            mClock += 1;
            tClock += 4;
        }

        public void opcodeEA(short nn)
        {
            //Store A at short
            Core.beakMemory.writeMemory((ushort)nn, Core.beakMemory.getA());
            mClock += 4;
            tClock += 16;
        }

        //Opcode EB doesn't exist?

        //Opcode EC doesn't exist?

        //Opcode ED doesn't exist?

        public void opcodeEE(byte n)
        {
            //XOR byte with A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() ^ n));
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeEF()
        {
            //Reset to 28
            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);
            Core.beakMemory.memoryPointer = 0x28;
            mClock += 4;
            tClock += 16;
        }

        void opcodeF0(byte n)
        {
            //Load data at (FF00 + n) into A
            Core.beakMemory.setA((byte)(Core.beakMemory.readMemory((ushort)(0xFF00 + n))));
            mClock += 3;
            tClock += 12;
        }

        public void opcodeF1()
        {
            //Pop AF
            Core.beakMemory.setAF((Core.beakMemory.readMemory((ushort)(((Core.beakMemory.stackPointer + 1) << 8) | (Core.beakMemory.readMemory(Core.beakMemory.stackPointer))))));
            Core.beakMemory.stackPointer += 2;
            mClock += 3;
            tClock += 12;
        }

        public void opcodeF2()
        {
            //Load data at (FF00 + C) into A
            Core.beakMemory.setA(Core.beakMemory.readMemory((ushort)(0xFF00 + Core.beakMemory.getC())));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeF3()
        {
            //Disable Interrupts
            interruptsEnabled = false;
            mClock += 1;
            tClock += 4;
        }

        //Opcode F4 doesn't exist?

        public void opcodeF5()
        {
            //Push AF
            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, Core.beakMemory.getAF());
            mClock += 4;
            tClock += 16;
        }

        public void opcodeF6(byte n)
        {
            //OR byte with A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | n));
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeF7()
        {
            //Reset to 30
            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);
            Core.beakMemory.memoryPointer = 0x30;
            mClock += 4;
            tClock += 16;
        }

        public void opcodeF8(byte n)
        {
            //Load SP + n into HL

            if ((Core.beakMemory.stackPointer + n) > 0xFF)
            {
                Core.beakMemory.setCFlag(true);
            }

            if (((Core.beakMemory.stackPointer & 0x0F) + (n & 0x0F)) > 0x0F)
            {
                Core.beakMemory.setHFlag(true);
            }

            Core.beakMemory.setHL((short)(Core.beakMemory.stackPointer + n));

            mClock += 3;
            tClock += 12;

            Core.beakMemory.setZFlag(false);
            Core.beakMemory.setNFlag(false);
        }

        public void opcodeF9()
        {
            //Load SP into HL
            Core.beakMemory.stackPointer = (ushort)Core.beakMemory.getHL();
            mClock += 2;
            tClock += 8;
        }

        public void opcodeFA(short nn)
        {
            //Load data at short into A
            Core.beakMemory.setA(Core.beakMemory.readMemory((ushort)nn));
            mClock += 4;
            tClock += 16;
        }

        public void opcodeFB()
        {
            //Enable Interrupts
            Core.enableInterruptsNextCycle = true;
            //interruptsEnabled = true;
            mClock += 1;
            tClock += 4;
        }
        //Opcode FC doesn't exist?

        //Opcode FD doesn't exist?

        public void opcodeFE(byte n)
        {
            //Compare n with A
            //byte test = beakMemory.getA() - n;
            mClock += 2;
            tClock += 8;

            //beakMemory.setZFlag((test == 0) ? 1 : 0);
            //beakMemory.setNFlag(true);
            //beakMemory.setHFlag((test > beakMemory.getA()));
            //beakMemory.setCFlag((test < 0) ? 1 : 0);

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == n) ? true : false);
            Core.beakMemory.setNFlag(true);
            Core.beakMemory.setHFlag(((Core.beakMemory.getA() & 0x0F) < (n & 0x0F)) ? true : false);
            Core.beakMemory.setCFlag((Core.beakMemory.getA() < n) ? true : false);
        }

        public void opcodeFF()
        {
            //Reset to 38
            //beakStack[--stackPointer] = memoryPointer;
            //beakMemory.writeMemory(--stackPointer, memoryPointer);
            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory(Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);
            Core.beakMemory.memoryPointer = 0x38;
            mClock += 4;
            tClock += 16;
        }

        public void opcodeCB00()
        {
            //Rotate B Left, put previous bit 7 into Carry flag

            Core.beakMemory.setB(Binary.rotateLeft(Core.beakMemory.getB()));

            Core.beakMemory.setCFlag((Core.beakMemory.getB() & 0x01) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getB() == 0);


            //beakMemory.setB (beakMemory.getB() << 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB01()
        {
            //Rotate C Left, put previous bit 7 into Carry flag

            Core.beakMemory.setC(Binary.rotateLeft(Core.beakMemory.getC()));

            Core.beakMemory.setCFlag((Core.beakMemory.getC() & 0x01) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getC() == 0);


            //beakMemory.setC(beakMemory.getC() << 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB02()
        {
            //Rotate D Left, put previous bit 7 into Carry flag

            Core.beakMemory.setD(Binary.rotateLeft(Core.beakMemory.getD()));

            Core.beakMemory.setCFlag((Core.beakMemory.getD() & 0x01) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getD() == 0);


            //beakMemory.setD(beakMemory.getD() << 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB03()
        {
            //Rotate E Left, put previous bit 7 into Carry flag

            Core.beakMemory.setE(Binary.rotateLeft(Core.beakMemory.getE()));

            Core.beakMemory.setCFlag((Core.beakMemory.getE() & 0x01) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getE() == 0);


            //beakMemory.setE(beakMemory.getE() << 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB04()
        {
            //Rotate H Left, put previous bit 7 into Carry flag

            Core.beakMemory.setH(Binary.rotateLeft(Core.beakMemory.getH()));

            Core.beakMemory.setCFlag((Core.beakMemory.getH() & 0x01) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getH() == 0);


            //beakMemory.setH(beakMemory.getH() << 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB05()
        {
            //Rotate L Left, put previous bit 7 into Carry flag

            Core.beakMemory.setL(Binary.rotateLeft(Core.beakMemory.getL()));

            Core.beakMemory.setCFlag((Core.beakMemory.getL() & 0x01) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getL() == 0);


            //beakMemory.setL(beakMemory.getL() << 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB06()
        {
            //Rotate data in HL Left, put previous bit 7 into Carry flag

            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), Binary.rotateLeft(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL())));

            Core.beakMemory.setCFlag((Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) & 0x01) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) == 0);


            //beakMemory.writeMemory(beakMemory.getHL(), (byte)(beakMemory.readMemory(beakMemory.getHL()) << 1));

            mClock += 3;
            tClock += 12;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB07()
        {
            //Rotate A Left, put previous bit 7 into Carry flag

            Core.beakMemory.setA(Binary.rotateLeft(Core.beakMemory.getA()));

            Core.beakMemory.setCFlag((Core.beakMemory.getA() & 0x01) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getA() == 0);


            //beakMemory.setA(beakMemory.getA() << 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB08()
        {
            //Rotate B Right, put previous bit 0 into Carry flag

            Core.beakMemory.setB(Binary.rotateRight(Core.beakMemory.getB()));

            Core.beakMemory.setCFlag(((Core.beakMemory.getB() & 0x80) >> 7) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getB() == 0);


            //beakMemory.setB(beakMemory.getB() >> 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB09()
        {
            //Rotate C Right, put previous bit 0 into Carry flag

            Core.beakMemory.setC(Binary.rotateRight(Core.beakMemory.getC()));

            Core.beakMemory.setCFlag(((Core.beakMemory.getC() & 0x80) >> 7) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getC() == 0);


            //beakMemory.setC(beakMemory.getC() >> 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB0A()
        {
            //Rotate D Right, put previous bit 0 into Carry flag

            Core.beakMemory.setD(Binary.rotateRight(Core.beakMemory.getD()));

            Core.beakMemory.setCFlag(((Core.beakMemory.getD() & 0x80) >> 7) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getD() == 0);

            //beakMemory.setD(beakMemory.getD() >> 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB0B()
        {
            //Rotate E Right, put previous bit 0 into Carry flag

            Core.beakMemory.setE(Binary.rotateRight(Core.beakMemory.getE()));

            Core.beakMemory.setCFlag(((Core.beakMemory.getE() & 0x80) >> 7) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getE() == 0);


            //beakMemory.setE(beakMemory.getE() >> 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB0C()
        {
            //Rotate H Right, put previous bit 0 into Carry flag

            Core.beakMemory.setH(Binary.rotateRight(Core.beakMemory.getH()));

            Core.beakMemory.setCFlag(((Core.beakMemory.getH() & 0x80) >> 7) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getH() == 0);

            //beakMemory.setH(beakMemory.getH() >> 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB0D()
        {
            //Rotate L Right, put previous bit 0 into Carry flag

            Core.beakMemory.setL(Binary.rotateRight(Core.beakMemory.getL()));

            Core.beakMemory.setCFlag(((Core.beakMemory.getL() & 0x80) >> 7) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getL() == 0);


            //beakMemory.setL(beakMemory.getL() >> 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB0E()
        {
            //Rotate data at HL Right, put previous bit 0 into Carry flag

            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), (byte)(Binary.rotateRight(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()))));

            Core.beakMemory.setB(Binary.rotateRight(Core.beakMemory.getB()));
            Core.beakMemory.setCFlag(((Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) & 0x80) >> 7) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) == 0);


            //beakMemory.writeMemory(beakMemory.getHL(), (byte)(beakMemory.readMemory(beakMemory.getHL()) >> 1));

            mClock += 3;
            tClock += 12;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB0F()
        {
            //Rotate A Right, put previous bit 0 into Carry flag (Does not Or C flag in)

            Core.beakMemory.setA(Binary.rotateRight(Core.beakMemory.getA()));

            Core.beakMemory.setCFlag(((Core.beakMemory.getA() & 0x80) >> 7) > 0);
            Core.beakMemory.setZFlag(Core.beakMemory.getA() == 0);


            //beakMemory.setA(beakMemory.getA() >> 1);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB10()
        {
            //Rotate B Left
            //beakMemory.setB(rotateLeft(beakMemory.getB()));

            byte oldBit = (byte)((Core.beakMemory.getB() & 0x80) >> 7);
            Core.beakMemory.setB((byte)((Core.beakMemory.getB() << 1) | Convert.ToByte(Core.beakMemory.getCFlag())));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getB() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB11()
        {
            //Rotate C Left
            //beakMemory.setC(rotateLeft(beakMemory.getC()));

            byte oldBit = (byte)((Core.beakMemory.getC() & 0x80) >> 7);
            Core.beakMemory.setC((byte)((Core.beakMemory.getC() << 1) | Convert.ToByte(Core.beakMemory.getCFlag())));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getC() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB12()
        {
            //Rotate D Left

            byte oldBit = Convert.ToByte((Core.beakMemory.getD() & 0x80) >> 7);
            Core.beakMemory.setD((byte)((Core.beakMemory.getD() << 1) | Convert.ToByte(Core.beakMemory.getCFlag())));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getD() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB13()
        {
            //Rotate E Left

            byte oldBit = (byte)((Core.beakMemory.getE() & 0x80) >> 7);
            Core.beakMemory.setE((byte)((Core.beakMemory.getE() << 1) | Convert.ToByte(Core.beakMemory.getCFlag())));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getE() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB14()
        {
            //Rotate H Left

            byte oldBit = (byte)((Core.beakMemory.getH() & 0x80) >> 7);
            Core.beakMemory.setH((byte)((Core.beakMemory.getH() << 1) | Convert.ToByte(Core.beakMemory.getCFlag())));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getH() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB15()
        {
            //Rotate L Left

            byte oldBit = (byte)((Core.beakMemory.getL() & 0x80) >> 7);
            Core.beakMemory.setL((byte)((Core.beakMemory.getL() << 1) | Convert.ToByte(Core.beakMemory.getCFlag())));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getL() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB16()
        {
            //Rotate data at HL Left

            byte oldBit = (byte)((Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) & 0x8000) >> 0xF);
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), (byte)((Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) << 1) | Convert.ToByte(Core.beakMemory.getCFlag())));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 3;
            tClock += 12;

            Core.beakMemory.setZFlag(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB17()
        {
            //Rotate A Left

            byte oldBit = (byte)((Core.beakMemory.getA() & 0x80) >> 7);
            Core.beakMemory.setA((byte)((Core.beakMemory.getA() << 1) | Convert.ToByte(Core.beakMemory.getCFlag())));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getA() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB18()
        {
            //Rotate B Right

            byte oldBit = (byte)(Core.beakMemory.getB() & 0x01);
            Core.beakMemory.setB((byte)((Core.beakMemory.getB() >> 1) | (Convert.ToByte(Core.beakMemory.getCFlag()) << 7)));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getB() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);

        }

        public void opcodeCB19()
        {
            //Rotate C Right

            byte oldBit = (byte)(Core.beakMemory.getC() & 0x01);
            Core.beakMemory.setC((byte)((Core.beakMemory.getC() >> 1) | (Convert.ToByte(Core.beakMemory.getCFlag()) << 7)));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getC() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB1A()
        {
            //Rotate D Right

            byte oldBit = (byte)(Core.beakMemory.getD() & 0x01);
            Core.beakMemory.setD((byte)((Core.beakMemory.getD() >> 1) | (Convert.ToByte(Core.beakMemory.getCFlag()) << 7)));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getD() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB1B()
        {
            //Rotate E Right

            byte oldBit = (byte)(Core.beakMemory.getE() & 0x01);
            Core.beakMemory.setE((byte)((Core.beakMemory.getE() >> 1) | (Convert.ToByte(Core.beakMemory.getCFlag()) << 7)));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getE() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB1C()
        {
            //Rotate H Right

            byte oldBit = (byte)(Core.beakMemory.getH() & 0x01);
            Core.beakMemory.setH((byte)((Core.beakMemory.getH() >> 1) | (Convert.ToByte(Core.beakMemory.getCFlag()) << 7)));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getH() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB1D()
        {
            //Rotate L Right

            byte oldBit = (byte)(Core.beakMemory.getL() & 0x01);
            Core.beakMemory.setL((byte)((Core.beakMemory.getL() >> 1) | (Convert.ToByte(Core.beakMemory.getCFlag()) << 7)));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getL() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB1E()
        {
            //Rotate/Shift HL Right

            byte oldBit = (byte)(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) & 0x01);
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), (byte)((Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) >> 1) | (Convert.ToByte(Core.beakMemory.getCFlag()) << 0xF)));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 3;
            tClock += 12;

            Core.beakMemory.setZFlag(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB1F()
        {
            //Rotate A Right

            byte oldBit = (byte)(Core.beakMemory.getA() & 0x01);
            Core.beakMemory.setA((byte)((Core.beakMemory.getA() >> 1) | (Convert.ToByte(Core.beakMemory.getCFlag()) << 7)));
            Core.beakMemory.setCFlag(oldBit > 0);

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getA() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB20()
        {
            //Shift B Left - Set Carry to old Bit 7

            Core.beakMemory.setCFlag(((Core.beakMemory.getB() & 0x80) >> 7) > 0);
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() << 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getB() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB21()
        {
            //Shift C Left - Set Carry to old Bit 7

            Core.beakMemory.setCFlag(((Core.beakMemory.getC() & 0x80) >> 7) > 0);
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() << 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getC() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB22()
        {
            //Shift D Left - Set Carry to old Bit 7

            Core.beakMemory.setCFlag(((Core.beakMemory.getD() & 0x80) >> 7) > 0);
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() << 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getD() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB23()
        {
            //Shift E Left - Set Carry to old Bit 7

            Core.beakMemory.setCFlag(((Core.beakMemory.getE() & 0x80) >> 7) > 0);
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() << 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getE() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB24()
        {
            //Shift H Left - Set Carry to old Bit 7

            Core.beakMemory.setCFlag(((Core.beakMemory.getH() & 0x80) >> 7) > 0);
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() << 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getH() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB25()
        {
            //Shift L Left - Set Carry to old Bit 7

            Core.beakMemory.setCFlag(((Core.beakMemory.getL() & 0x80) >> 7) > 0);
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() << 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getL() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB26()
        {
            //Shift data at HL Left - Set Carry to old Bit 7

            Core.beakMemory.setCFlag(((Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) & 0x8000) >> 0xF) > 0);
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), (byte)(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) << 1));

            mClock += 3;
            tClock += 12;

            Core.beakMemory.setZFlag(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB27()
        {
            //Shift A Left - Set Carry to old Bit 7

            Core.beakMemory.setCFlag(((Core.beakMemory.getA() & 0x80) >> 7) > 0);
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() << 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getA() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB28()
        {
            //Shift B Right - Set Carry to old Bit 0

            Core.beakMemory.setCFlag((Core.beakMemory.getB() & 0x01) > 0);
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() >> 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getB() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB29()
        {
            //Shift C Right - Set Carry to old Bit 0

            Core.beakMemory.setCFlag((Core.beakMemory.getC() & 0x01) > 0);
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() >> 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getC() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB2A()
        {
            //Shift D Right - Set Carry to old Bit 0

            Core.beakMemory.setCFlag((Core.beakMemory.getD() & 0x01) > 0);
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() >> 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getD() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB2B()
        {
            //Shift E Right - Set Carry to old Bit 0

            Core.beakMemory.setCFlag((Core.beakMemory.getE() & 0x01) > 0);
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() >> 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getE() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB2C()
        {
            //Shift H Right - Set Carry to old Bit 0

            Core.beakMemory.setCFlag((Core.beakMemory.getH() & 0x01) > 0);
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() >> 1));


            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getH() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB2D()
        {
            //Shift L Right - Set Carry to old Bit 0

            Core.beakMemory.setCFlag((Core.beakMemory.getL() & 0x01) > 0);
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() >> 1));


            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getL() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB2E()
        {
            //Shift data at HL Right - Set Carry to old Bit 0

            Core.beakMemory.setCFlag((Core.beakMemory.readMemory((ushort)(Core.beakMemory.getHL())) & 0x01) > 0);
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), (byte)(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) >> 1));

            mClock += 3;
            tClock += 12;

            Core.beakMemory.setZFlag(Core.beakMemory.getHL() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB2F()
        {
            //Shift A Right - Set Carry to old Bit 0

            Core.beakMemory.setCFlag((Core.beakMemory.getA() & 0x01) > 0);
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() >> 1));
            
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getA() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB30()
        {
            //Swap nibbles in B
            byte b = Core.beakMemory.getB();
            b = (byte)(((b & 0x0F) << 4) | ((b & 0xF0) >> 4));
            Core.beakMemory.setB(b);
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getB() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeCB31()
        {
            //Swap nibbles in C
            byte c = Core.beakMemory.getC();
            c = (byte)(((c & 0x0F) << 4) | ((c & 0xF0) >> 4));
            Core.beakMemory.setC(c);
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getC() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeCB32()
        {
            //Swap nibbles in D
            byte d = Core.beakMemory.getD();
            d = (byte)(((d & 0x0F) << 4) | ((d & 0xF0) >> 4));
            Core.beakMemory.setD(d);
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getD() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeCB33()
        {
            //Swap nibbles in E
            byte e = Core.beakMemory.getC();
            e = (byte)(((e & 0x0F) << 4) | ((e & 0xF0) >> 4));
            Core.beakMemory.setE(e);
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getE() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeCB34()
        {
            //Swap nibbles in H
            byte h = Core.beakMemory.getH();
            h = (byte)(((h & 0x0F) << 4) | ((h & 0xF0) >> 4));
            Core.beakMemory.setH(h);
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getH() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeCB35()
        {
            //Swap nibbles in L
            byte l = Core.beakMemory.getL();
            l = (byte)(((l & 0x0F) << 4) | ((l & 0xF0) >> 4));
            Core.beakMemory.setL(l);
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getL() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }


        public void opcodeCB36()
        {
            //Swap nibbles in memory at HL
            short hl = Core.beakMemory.getHL();
            byte hlData = Core.beakMemory.readMemory((ushort)hl);
            hlData = (byte)(((hlData & 0x0F) << 4) | ((hlData & 0xF0) >> 4));
            Core.beakMemory.writeMemory((ushort)hl, hlData);
            mClock += 3;
            tClock += 12;

            Core.beakMemory.setZFlag((Core.beakMemory.readMemory((ushort)hl) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeCB37()
        {
            //Swap nibbles in A
            byte a = Core.beakMemory.getA();
            a = (byte)(((a & 0x0F) << 4) | ((a & 0xF0) >> 4));
            Core.beakMemory.setA(a);
            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag((Core.beakMemory.getA() == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
            Core.beakMemory.setCFlag(false);
        }

        public void opcodeCB38()
        {
            //Shift B Right
            Core.beakMemory.setCFlag((Core.beakMemory.getB() & 0x01) > 0);
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() >> 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getB() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB39()
        {
            //Shift C Right
            Core.beakMemory.setCFlag((Core.beakMemory.getC() & 0x01) > 0);
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() >> 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getC() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB3A()
        {
            //Shift D Right
            Core.beakMemory.setCFlag((Core.beakMemory.getD() & 0x01) > 0);
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() >> 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getD() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB3B()
        {
            //Shift E Right
            Core.beakMemory.setCFlag((Core.beakMemory.getE() & 0x01) > 0);
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() >> 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getE() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB3C()
        {
            //Shift H Right
            Core.beakMemory.setCFlag((Core.beakMemory.getH() & 0x01) > 0);
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() >> 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getH() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB3D()
        {
            //Shift L Right
            Core.beakMemory.setCFlag((Core.beakMemory.getL() & 0x01) > 0);
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() >> 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getL() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB3E()
        {
            //Shift data at HL Right
            Core.beakMemory.setCFlag((Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) & 0x01) > 0);
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), (byte)(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) >> 1));

            mClock += 3;
            tClock += 12;

            Core.beakMemory.setZFlag(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB3F()
        {
            //Shift A Right
            Core.beakMemory.setCFlag((Core.beakMemory.getA() & 0x01) > 0);
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() >> 1));

            mClock += 2;
            tClock += 8;

            Core.beakMemory.setZFlag(Core.beakMemory.getA() == 0);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(false);
        }

        public void opcodeCB40()
        {
            //Test bit 0 in B
            Core.beakMemory.setZFlag(((Core.beakMemory.getB() & 0x01) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB41()
        {
            //Test bit 0 in C
            Core.beakMemory.setZFlag(((Core.beakMemory.getC() & 0x01) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB42()
        {
            //Test bit 0 in D
            Core.beakMemory.setZFlag(((Core.beakMemory.getD() & 0x01) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB43()
        {
            //Test bit 0 in E
            Core.beakMemory.setZFlag(((Core.beakMemory.getE() & 0x01) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB44()
        {
            //Test bit 0 in H
            Core.beakMemory.setZFlag(((Core.beakMemory.getH() & 0x01) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB45()
        {
            //Test bit 0 in L
            Core.beakMemory.setZFlag(((Core.beakMemory.getL() & 0x01) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB46()
        {
            //Test bit 0 in data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.setZFlag(((Core.beakMemory.readMemory((ushort)hl) & 0x01) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 3;
            tClock += 12;
        }

        public void opcodeCB47()
        {
            //Test bit 0 in A
            Core.beakMemory.setZFlag(((Core.beakMemory.getA() & 0x01) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB48()
        {
            //Test bit 1 in B
            Core.beakMemory.setZFlag((((Core.beakMemory.getB() & 0x02) >> 1) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB49()
        {
            //Test bit 1 in C
            Core.beakMemory.setZFlag((((Core.beakMemory.getC() & 0x02) >> 1) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB4A()
        {
            //Test bit 1 in D
            Core.beakMemory.setZFlag((((Core.beakMemory.getD() & 0x02) >> 1) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB4B()
        {
            //Test bit 1 in E
            Core.beakMemory.setZFlag((((Core.beakMemory.getE() & 0x02) >> 1) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB4C()
        {
            //Test bit 1 in H
            Core.beakMemory.setZFlag((((Core.beakMemory.getH() & 0x02) >> 1) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB4D()
        {
            //Test bit 1 in L
            Core.beakMemory.setZFlag((((Core.beakMemory.getL() & 0x02) >> 1) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB4E()
        {
            //Test bit 1 in data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.setZFlag((((Core.beakMemory.readMemory((ushort)hl) & 0x02) >> 1) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 3;
            tClock += 12;
        }

        public void opcodeCB4F()
        {
            //Test bit 1 in A
            Core.beakMemory.setZFlag((((Core.beakMemory.getA() & 0x02) >> 1) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB50()
        {
            //Test bit 2 in B
            Core.beakMemory.setZFlag((((Core.beakMemory.getB() & 0x04) >> 2) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB51()
        {
            //Test bit 2 in C
            Core.beakMemory.setZFlag((((Core.beakMemory.getC() & 0x04) >> 2) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB52()
        {
            //Test bit 2 in D
            Core.beakMemory.setZFlag((((Core.beakMemory.getD() & 0x04) >> 2) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB53()
        {
            //Test bit 2 in E
            Core.beakMemory.setZFlag((((Core.beakMemory.getE() & 0x04) >> 2) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB54()
        {
            //Test bit 2 in H
            Core.beakMemory.setZFlag((((Core.beakMemory.getH() & 0x04) >> 2) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB55()
        {
            //Test bit 2 in L
            Core.beakMemory.setZFlag((((Core.beakMemory.getL() & 0x04) >> 2) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB56()
        {
            //Test bit 2 in data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.setZFlag((((Core.beakMemory.readMemory((ushort)hl) & 0x04) >> 2) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 3;
            tClock += 12;
        }

        public void opcodeCB57()
        {
            //Test bit 2 in A
            Core.beakMemory.setZFlag((((Core.beakMemory.getA() & 0x04) >> 2) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB58()
        {
            //Test bit 3 in B
            Core.beakMemory.setZFlag((((Core.beakMemory.getB() & 0x08) >> 3) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB59()
        {
            //Test bit 3 in C
            Core.beakMemory.setZFlag((((Core.beakMemory.getC() & 0x08) >> 3) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB5A()
        {
            //Test bit 3 in D
            Core.beakMemory.setZFlag((((Core.beakMemory.getD() & 0x08) >> 3) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB5B()
        {
            //Test bit 3 in E
            Core.beakMemory.setZFlag((((Core.beakMemory.getE() & 0x08) >> 3) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB5C()
        {
            //Test bit 3 in H
            Core.beakMemory.setZFlag((((Core.beakMemory.getH() & 0x08) >> 3) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB5D()
        {
            //Test bit 3 in L
            Core.beakMemory.setZFlag((((Core.beakMemory.getL() & 0x08) >> 3) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB5E()
        {
            //Test bit 3 in data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.setZFlag((((Core.beakMemory.readMemory((ushort)hl) & 0x08) >> 3) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 3;
            tClock += 12;
        }

        public void opcodeCB5F()
        {
            //Test bit 3 in A
            Core.beakMemory.setZFlag((((Core.beakMemory.getA() & 0x08) >> 3) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB60()
        {
            //Test bit 4 in B
            Core.beakMemory.setZFlag((((Core.beakMemory.getB() & 0x10) >> 4) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB61()
        {
            //Test bit 4 in C
            Core.beakMemory.setZFlag((((Core.beakMemory.getC() & 0x10) >> 4) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB62()
        {
            //Test bit 4 in D
            Core.beakMemory.setZFlag((((Core.beakMemory.getD() & 0x10) >> 4) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB63()
        {
            //Test bit 4 in E
            Core.beakMemory.setZFlag((((Core.beakMemory.getE() & 0x10) >> 4) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB64()
        {
            //Test bit 4 in H
            Core.beakMemory.setZFlag((((Core.beakMemory.getH() & 0x10) >> 4) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB65()
        {
            //Test bit 4 in L
            Core.beakMemory.setZFlag((((Core.beakMemory.getL() & 0x10) >> 4) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB66()
        {
            //Test bit 4 in data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.setZFlag((((Core.beakMemory.readMemory((ushort)hl) & 0x10) >> 4) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 3;
            tClock += 12;
        }

        public void opcodeCB67()
        {
            //Test bit 4 in A
            Core.beakMemory.setZFlag((((Core.beakMemory.getA() & 0x10) >> 4) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB68()
        {
            //Test bit 5 in B
            Core.beakMemory.setZFlag((((Core.beakMemory.getB() & 0x20) >> 5) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB69()
        {
            //Test bit 5 in C
            Core.beakMemory.setZFlag((((Core.beakMemory.getC() & 0x20) >> 5) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB6A()
        {
            //Test bit 5 in D
            Core.beakMemory.setZFlag((((Core.beakMemory.getD() & 0x20) >> 5) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB6B()
        {
            //Test bit 5 in E
            Core.beakMemory.setZFlag((((Core.beakMemory.getE() & 0x20) >> 5) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB6C()
        {
            //Test bit 5 in H
            Core.beakMemory.setZFlag((((Core.beakMemory.getH() & 0x20) >> 5) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB6D()
        {
            //Test bit 5 in L
            Core.beakMemory.setZFlag((((Core.beakMemory.getL() & 0x20) >> 5) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB6E()
        {
            //Test bit 5 in data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.setZFlag((((Core.beakMemory.readMemory((ushort)hl) & 0x20) >> 5) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 3;
            tClock += 12;
        }

        public void opcodeCB6F()
        {
            //Test bit 5 in A
            Core.beakMemory.setZFlag((((Core.beakMemory.getA() & 0x20) >> 5) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB70()
        {
            //Test bit 6 in B
            Core.beakMemory.setZFlag((((Core.beakMemory.getB() & 0x40) >> 6) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB71()
        {
            //Test bit 6 in C
            Core.beakMemory.setZFlag((((Core.beakMemory.getC() & 0x40) >> 6) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB72()
        {
            //Test bit 6 in D
            Core.beakMemory.setZFlag((((Core.beakMemory.getD() & 0x40) >> 6) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB73()
        {
            //Test bit 6 in E
            Core.beakMemory.setZFlag((((Core.beakMemory.getE() & 0x40) >> 6) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB74()
        {
            //Test bit 6 in H
            Core.beakMemory.setZFlag((((Core.beakMemory.getH() & 0x40) >> 6) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB75()
        {
            //Test bit 6 in L
            Core.beakMemory.setZFlag((((Core.beakMemory.getL() & 0x40) >> 6) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB76()
        {
            //Test bit 6 in data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.setZFlag((((Core.beakMemory.readMemory((ushort)hl) & 0x40) >> 6) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 3;
            tClock += 12;
        }

        public void opcodeCB77()
        {
            //Test bit 6 in A
            Core.beakMemory.setZFlag((((Core.beakMemory.getA() & 0x40) >> 6) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB78()
        {
            //Test bit 7 in B
            Core.beakMemory.setZFlag((((Core.beakMemory.getB() & 0x80) >> 7) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB79()
        {
            //Test bit 7 in C
            Core.beakMemory.setZFlag((((Core.beakMemory.getC() & 0x80) >> 7) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB7A()
        {
            //Test bit 7 in D
            Core.beakMemory.setZFlag((((Core.beakMemory.getD() & 0x80) >> 7) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB7B()
        {
            //Test bit 7 in E
            Core.beakMemory.setZFlag((((Core.beakMemory.getE() & 0x80) >> 7) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB7C()
        {
            //Test bit 7 in H
            Core.beakMemory.setZFlag((((Core.beakMemory.getH() & 0x80) >> 7) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB7D()
        {
            //Test bit 7 in L
            Core.beakMemory.setZFlag((((Core.beakMemory.getL() & 0x80) >> 7) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB7E()
        {
            //Test bit 7 in data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.setZFlag((((Core.beakMemory.readMemory((ushort)hl) & 0x80) >> 7) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 3;
            tClock += 12;
        }

        public void opcodeCB7F()
        {
            //Test bit 7 in A
            Core.beakMemory.setZFlag((((Core.beakMemory.getA() & 0x80) >> 7) == 0) ? true : false);
            Core.beakMemory.setNFlag(false);
            Core.beakMemory.setHFlag(true);

            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB80()
        {
            //Reset bit 0 in B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() & 0xFE)); //Masks off left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB81()
        {
            //Reset bit 0 in C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() & 0xFE)); //Masks off left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB82()
        {
            //Reset bit 0 in D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() & 0xFE)); //Masks off left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB83()
        {
            //Reset bit 0 in E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() & 0xFE)); //Masks off left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB84()
        {
            //Reset bit 0 in H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() & 0xFE)); //Masks off left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB85()
        {
            //Reset bit 0 of data at L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() & 0xFE)); //Masks off left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB86()
        {
            //Reset bit 0 in HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) & 0xFE)); //Masks off left most bit
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCB87()
        {
            //Reset bit 0 of data at A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & 0xFE)); //Masks off left most bit
            mClock += 2;
            tClock += 8;
        }


        public void opcodeCB88()
        {
            //Reset bit 1 in B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() & 0xFD)); //Masks off second to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB89()
        {
            //Reset bit 1 in C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() & 0xFD)); //Masks off second to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB8A()
        {
            //Reset bit 1 in D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() & 0xFD)); //Masks off second to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB8B()
        {
            //Reset bit 1 in E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() & 0xFD)); //Masks off second to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB8C()
        {
            //Reset bit 1 in H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() & 0xFD)); //Masks off second to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB8D()
        {
            //Reset bit 1 in L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() & 0xFD)); //Masks off second to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB8E()
        {
            //Reset bit 1 in HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) & 0xFD)); //Masks off left most bit
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCB8F()
        {
            //Reset bit 1 in A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & 0xFD)); //Masks off second to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB90()
        {
            //Reset bit 2 in B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() & 0xFB)); //Masks off third to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB91()
        {
            //Reset bit 2 in C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() & 0xFB)); //Masks off third to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB92()
        {
            //Reset bit 2 in D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() & 0xFB)); //Masks off third to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB93()
        {
            //Reset bit 2 in E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() & 0xFB)); //Masks off third to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB94()
        {
            //Reset bit 2 in H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() & 0xFB)); //Masks off third to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB95()
        {
            //Reset bit 2 in L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() & 0xFB)); //Masks off third to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB96()
        {
            //Reset bit 2 in HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) & 0xFB)); //Masks off left most bit
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCB97()
        {
            //Reset bit 2 in A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & 0xFB)); //Masks off third to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB98()
        {
            //Reset bit 3 in B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() & 0xF7)); //Masks off fourth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB99()
        {
            //Reset bit 3 in C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() & 0xF7)); //Masks off fourth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB9A()
        {
            //Reset bit 3 in D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() & 0xF7)); //Masks off fourth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB9B()
        {
            //Reset bit 3 in E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() & 0xF7)); //Masks off fourth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB9C()
        {
            //Reset bit 3 in H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() & 0xF7)); //Masks off fourth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB9D()
        {
            //Reset bit 3 in L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() & 0xF7)); //Masks off fourth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCB9E()
        {
            //Reset bit 3 in HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) & 0xF7)); //Masks off left most bit
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCB9F()
        {
            //Reset bit 3 in A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & 0xF7)); //Masks off fourth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBA0()
        {
            //Reset bit 4 in B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() & 0xEF)); //Masks off fifth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBA1()
        {
            //Reset bit 4 in C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() & 0xEF)); //Masks off fifth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBA2()
        {
            //Reset bit 4 in D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() & 0xEF)); //Masks off fifth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBA3()
        {
            //Reset bit 4 in E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() & 0xEF)); //Masks off fifth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBA4()
        {
            //Reset bit 4 in H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() & 0xEF)); //Masks off fifth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBA5()
        {
            //Reset bit 4 in L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() & 0xEF)); //Masks off fifth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBA6()
        {
            //Reset bit 4 in HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) & 0xEF)); //Masks off left most bit
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCBA7()
        {
            //Reset bit 4 in A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & 0xEF)); //Masks off fifth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBA8()
        {
            //Reset bit 5 in B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() & 0xDF)); //Masks off sixth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBA9()
        {
            //Reset bit 5 in C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() & 0xDF)); //Masks off sixth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBAA()
        {
            //Reset bit 5 in D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() & 0xDF)); //Masks off sixth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBAB()
        {
            //Reset bit 5 in E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() & 0xDF)); //Masks off sixth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBAC()
        {
            //Reset bit 5 in H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() & 0xDF)); //Masks off sixth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBAD()
        {
            //Reset bit 5 in L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() & 0xDF)); //Masks off sixth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBAE()
        {
            //Reset bit 5 in HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) & 0xDF)); //Masks off left most bit
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCBAF()
        {
            //Reset bit 5 in A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & 0xDF)); //Masks off sixth to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBB0()
        {
            //Reset bit 6 in B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() & 0xBF)); //Masks off seventh to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBB1()
        {
            //Reset bit 6 in C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() & 0xBF)); //Masks off seventh to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBB2()
        {
            //Reset bit 6 in D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() & 0xBF)); //Masks off seventh to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBB3()
        {
            //Reset bit 6 in E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() & 0xBF)); //Masks off seventh to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBB4()
        {
            //Reset bit 6 in H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() & 0xBF)); //Masks off seventh to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBB5()
        {
            //Reset bit 6 in L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() & 0xBF)); //Masks off seventh to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBB6()
        {
            //Reset bit 6 in HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) & 0xBF)); //Masks off left most bit
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCBB7()
        {
            //Reset bit 6 in A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & 0xBF)); //Masks off seventh to left most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBB8()
        {
            //Reset bit 7 in B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() & 0x7F)); //Masks off right most bit
            mClock += 2;
            tClock += 8;
        }
        public void opcodeCBB9()
        {
            //Reset bit 7 in C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() & 0x7F)); //Masks off right most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBBA()
        {
            //Reset bit 7 in D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() & 0x7F)); //Masks off right most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBBB()
        {
            //Reset bit 7 in E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() & 0x7F)); //Masks off right most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBBC()
        {
            //Reset bit 7 in H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() & 0x7F)); //Masks off right most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBBD()
        {
            //Reset bit 7 in L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() & 0x7F)); //Masks off right most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBBE()
        {
            //Reset bit 7 in HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) & 0x7F)); //Masks off left most bit
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCBBF()
        {
            //Reset bit 7 in A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() & 0x7F)); //Masks off right most bit
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBC0()
        {
            //Set Bit 0 of B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() | 0x01));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBC1()
        {
            //Set Bit 0 of C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() | 0x01));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBC2()
        {
            //Set Bit 0 of D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() | 0x01));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBC3()
        {
            //Set Bit 0 of E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() | 0x01));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBC4()
        {
            //Set Bit 0 of H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() | 0x01));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBC5()
        {
            //Set Bit 0 of L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() | 0x01));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBC6()
        {
            //Set Bit 0 of data at HL
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.getHL(), (byte)(Core.beakMemory.readMemory((ushort)Core.beakMemory.getHL()) | 0x01));
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCBC7()
        {
            //Set Bit 0 of A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | 0x01));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBC8()
        {
            //Set Bit 1 of B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() | 0x02));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBC9()
        {
            //Set Bit 1 of C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() | 0x02));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBCA()
        {
            //Set Bit 1 of D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() | 0x02));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBCB()
        {
            //Set Bit 1 of E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() | 0x02));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBCC()
        {
            //Set Bit 1 of H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() | 0x02));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBCD()
        {
            //Set Bit 1 of L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() | 0x02));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBCE()
        {
            //Set Bit 1 of data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) | 0x02));
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCBCF()
        {
            //Set Bit 1 of A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | 0x02));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBD0()
        {
            //Set Bit 2 of B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() | 0x04));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBD1()
        {
            //Set Bit 2 of C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() | 0x04));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBD2()
        {
            //Set Bit 2 of D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() | 0x04));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBD3()
        {
            //Set Bit 2 of E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() | 0x04));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBD4()
        {
            //Set Bit 2 of H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() | 0x04));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBD5()
        {
            //Set Bit 2 of L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() | 0x04));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBD6()
        {
            //Set Bit 2 of data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) | 0x04));
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCBD7()
        {
            //Set Bit 2 of A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | 0x04));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBD8()
        {
            //Set Bit 3 of B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() | 0x08));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBD9()
        {
            //Set Bit 3 of C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() | 0x08));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBDA()
        {
            //Set Bit 3 of D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() | 0x08));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBDB()
        {
            //Set Bit 3 of E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() | 0x08));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBDC()
        {
            //Set Bit 3 of H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() | 0x08));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBDD()
        {
            //Set Bit 3 of L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() | 0x08));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBDE()
        {
            //Set Bit 3 of data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) | 0x08));
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCBDF()
        {
            //Set Bit 3 of A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | 0x08));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBE0()
        {
            //Set Bit 4 of B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() | 0x10));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBE1()
        {
            //Set Bit 4 of C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() | 0x10));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBE2()
        {
            //Set Bit 4 of D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() | 0x10));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBE3()
        {
            //Set Bit 4 of E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() | 0x10));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBE4()
        {
            //Set Bit 4 of H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() | 0x10));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBE5()
        {
            //Set Bit 4 of L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() | 0x10));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBE6()
        {
            //Set Bit 4 of data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) | 0x10));
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCBE7()
        {
            //Set Bit 4 of A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | 0x10));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBE8()
        {
            //Set Bit 5 of B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() | 0x20));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBE9()
        {
            //Set Bit 5 of C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() | 0x20));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBEA()
        {
            //Set Bit 5 of D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() | 0x20));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBEB()
        {
            //Set Bit 5 of E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() | 0x20));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBEC()
        {
            //Set Bit 5 of H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() | 0x20));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBED()
        {
            //Set Bit 5 of L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() | 0x20));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBEE()
        {
            //Set Bit 5 of data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) | 0x20));
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCBEF()
        {
            //Set Bit 5 of A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | 0x20));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBF0()
        {
            //Set Bit 6 of B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() | 0x40));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBF1()
        {
            //Set Bit 6 of C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() | 0x40));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBF2()
        {
            //Set Bit 6 of D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() | 0x40));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBF3()
        {
            //Set Bit 6 of E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() | 0x40));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBF4()
        {
            //Set Bit 6 of H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() | 0x40));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBF5()
        {
            //Set Bit 6 of L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() | 0x40));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBF6()
        {
            //Set Bit 6 of data at HL
            ushort hl = (ushort)Core.beakMemory.getHL();
            Core.beakMemory.writeMemory(hl, (byte)(Core.beakMemory.readMemory((ushort)((hl) | 0x40))));
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCBF7()
        {
            //Set Bit 6 of A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | 0x40));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBF8()
        {
            //Set Bit 7 of B
            Core.beakMemory.setB((byte)(Core.beakMemory.getB() | 0x80));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBF9()
        {
            //Set Bit 7 of C
            Core.beakMemory.setC((byte)(Core.beakMemory.getC() | 0x80));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBFA()
        {
            //Set Bit 7 of D
            Core.beakMemory.setD((byte)(Core.beakMemory.getD() | 0x80));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBFB()
        {
            //Set Bit 7 of E
            Core.beakMemory.setE((byte)(Core.beakMemory.getE() | 0x80));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBFC()
        {
            //Set Bit 7 of H
            Core.beakMemory.setH((byte)(Core.beakMemory.getH() | 0x80));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBFD()
        {
            //Set Bit 7 of L
            Core.beakMemory.setL((byte)(Core.beakMemory.getL() | 0x80));
            mClock += 2;
            tClock += 8;
        }

        public void opcodeCBFE()
        {
            //Set Bit 7 of data at HL
            short hl = Core.beakMemory.getHL();
            Core.beakMemory.writeMemory((ushort)hl, (byte)(Core.beakMemory.readMemory((ushort)hl) | 0x80));
            mClock += 3;
            tClock += 12;
        }

        public void opcodeCBFF()
        {
            //Set Bit 7 of A
            Core.beakMemory.setA((byte)(Core.beakMemory.getA() | 0x80));
            mClock += 2;
            tClock += 8;
        }

        public void updateTIMA(int curClocks, ref int clocksSinceLastTIMAUpdate, ref int clocksSinceLastDIVUpdate)
        {
            /*
            Purpose: Checks each loop cycle if enough cycles have passed to increment the timers.
            If so, it writes the incremented value to the timer register and requests an interrupt if it overflows.
            */

            bool timerEnabled = ((Core.beakMemory.readMemory(0xFF07) & 0x04) > 0);

            if (timerEnabled)
            {

                byte timerFrequency = (byte)(Core.beakMemory.readMemory(0xFF07) & 0x03);
                int timerNumClocksToUpdate;

                switch (timerFrequency)
                {
                    case 0:
                        {
                            timerNumClocksToUpdate = 1024; //4096 hz
                            break;
                        }
                    case 1:
                        {
                            timerNumClocksToUpdate = 16; //262144 hz
                            break;
                        }
                    case 2:
                        {
                            timerNumClocksToUpdate = 64; //65536 hz
                            break;
                        }
                    case 3:
                        {
                            timerNumClocksToUpdate = 256; //16386 hz
                            break;
                        }
                    default:
                        {
                            timerNumClocksToUpdate = 256;
                            break;
                        }
                }

                if ((curClocks - clocksSinceLastTIMAUpdate) >= timerNumClocksToUpdate)
                {
                    clocksSinceLastTIMAUpdate = curClocks;


                    //Increment TIMA
                    byte tima = Core.beakMemory.readMemory(0xFF05);
                    if (tima == 0xFF)
                    {
                        //Set Timer Overflow Interrupt Flag
                        Core.beakMemory.writeMemory((ushort)0xFF0F, (byte)(Core.beakMemory.readMemory(0xFF0F) | 0x4));

                        //Reset TIMA Value
                        Core.beakMemory.writeMemory((ushort)0xFF05, (byte)0);
                    }
                    else
                    {
                        Core.beakMemory.writeMemory((ushort)0xFF05, (byte)(tima + 1));
                    }
                }
            }

            if ((curClocks - clocksSinceLastDIVUpdate) >= 256) //16386 hz
            {
                Core.beakMemory.writeMemory((ushort)0xFF04, (byte)(Core.beakMemory.readMemory(0xFF04) + 1));
                clocksSinceLastDIVUpdate = curClocks;
            }
        }

        public bool checkForInterrupt()
        {
            /*
            Purpose: Checks if there are any interrupts pending so that they can be serviced later. The intention is to be able to check with
            minimal effort and not having any functionality related to servicing the interrupt itself.
            */

            byte IE = Core.beakMemory.readMemory(0xFFFF);
            byte IF = Core.beakMemory.readMemory(0xFF0F);

            for (int i = 0; i < 8; i++)
            {
                if ((IE & 0x01) == 1 && (IF & 0x01) == 1)
                {
                    return true;
                }
                else
                {
                    IE >>= 1;
                    IF >>= 1;
                }
            }

            return false;
        }

        public void executeInterrupt()
        {
            /*
            Purpose: Services any interrupts active in the IE and IF registers. If both IE and IF contain a matching bit, the current stack pointer
            is stored before jumping to the interrupt vector that corresponds to those enabled bits.
            */

            byte IE = Core.beakMemory.readMemory(0xFFFF);
            byte IF = Core.beakMemory.readMemory(0xFF0F);

            Core.beakMemory.stackPointer -= 2;
            Core.beakMemory.writeMemory((ushort)Core.beakMemory.stackPointer, (short)Core.beakMemory.memoryPointer);

            interruptsEnabled = false;

            //If there are several interrupts, VBLANK takes highest priority and goes down
            if (((IF & 0x01) == 1) && ((IE & 0x01) == 1))
            {
                //VBLANK
                Core.beakMemory.memoryPointer = 0x0040;
                Core.beakMemory.writeMemory(0xFF0F, (byte)(IF & 0xFE)); //Clear bit in IF
            }
            else if (((((IF & 0x02) >> 1) == 1) && ((IE & 0x02) >> 1 == 1)))
            {
                //LCD
                Core.beakMemory.memoryPointer = 0x0048;
                Core.beakMemory.writeMemory(0xFF0F, (byte)(IF & 0xFD)); //Clear bit in IF
            }
            else if (((((IF & 0x04) >> 2) == 1) && ((IE & 0x04) >> 2 == 1)))
            {
                //Timer Overflow
                Core.beakMemory.memoryPointer = 0x0050;
                Core.beakMemory.writeMemory(0xFF0F, (byte)(IF & 0xFB)); //Clear bit in IF
            }
            else if (((((IF & 0x08) >> 3) == 1) && ((IE & 0x08) >> 3 == 1)))
            {
                //Serial
                Core.beakMemory.memoryPointer = 0x0058;
                Core.beakMemory.writeMemory(0xFF0F, (byte)(IF & 0xF7)); //Clear bit in IF
            }
            else if (((((IF & 0x10) >> 4) == 1) && ((IE & 0x10) >> 4 == 1)))
            {
                //Joypad
                Core.beakMemory.memoryPointer = 0x0060;
                Core.beakMemory.writeMemory(0xFF0F, (byte)(IF & 0xEF)); //Clear bit in IF
            }

            mClock += 5;
            tClock += 20;
        }

        public bool checkForHaltOrInterrupt()
        {
            /*
            Purpose: Allows interrupts or halts to be serviced if they are active.
            Otherwise, it will return false and the next assembly instruction will be executed as normal.
            */

            if (interruptsEnabled) //IME
            {
                if (checkForInterrupt())
                {
                    //End halt mode
                    if (halt)
                    {
                        halt = false;
                        mClock += 1;
                        tClock += 4;
                    }

                    executeInterrupt();
                    return true; //Temporary? This allows the opcode it is jumped to to be logged/shown in debugger instead of appearing skipped. Could cause a side effect by skipping a loop?
                }
                else if (halt)
                {
                    return true;
                }
            }
            else
            {

                if (halt)
                {
                    halt = false;
                    mClock += 1;
                    tClock += 4;

                    return true; //BGB and No$GB never escape DI+Halt
                }

            }

            return false;

            //write interrupt function. If flag in IE and IME are both set, push PC into stack, (disable interrupts?)
            //then jump to interrupt starting address per interrupt type
            //0040: Vertical Blankl Interrupt Start Address
            //0048:LCDC Status Interrupt Start Address
            //0050:Timer Overflow Interrupt Start Address
            //0058 Serial Transfer Completion Interrupt
            //0060 High to Low P10-P13 Interrupt Start Address
        }


        public int returnTClock()
        {
            return tClock;
        }

        public int returnMClock()
        {
            return mClock;
        }

        public bool returnHalt()
        {
            return halt;
        }

        public bool returnInterrupt()
        {
            return interrupt;
        }

        public bool returnIME()
        {
            return interruptsEnabled;
        }

        public bool returnRepeat()
        {
            return repeat;
        }

        public void setTClock(int newTClock)
        {
            tClock = newTClock;
        }

        public void setmClock(int newMClock)
        {
            mClock = newMClock;
        }

        public void setHalt(bool newHalt)
        {
            halt = newHalt;
        }

        public void setIME(bool ime)
        {
            interruptsEnabled = ime;
        }

        public void setInterrupt(bool newInterrupt)
        {
            interrupt = newInterrupt;
        }
        public void setRepeat(bool newRepeat)
        {
            repeat = newRepeat;
        }







    }
}
