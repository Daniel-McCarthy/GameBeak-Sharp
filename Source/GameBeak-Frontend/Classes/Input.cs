using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBeak.Classes
{
    class Input
    {

        //Gameboy keys:
        //[Up][Left][Right][Down][A][B][Start][Select]

        //Mapped to standard keyboard keys:
        //[Up][Left][Right][Down][Z][X][Enter][RShift]

	    bool keyUp = false;
        bool keyDown = false;
        bool keyLeft = false;
        bool keyRight = false;
        bool keyStart = false;
        bool keySelect = false;
        bool keyA = false;
        bool keyB = false;

        public bool isAnyKeyPressed()
        {
            return keyUp || keyDown || keyLeft || keyRight || keyStart || keySelect || keyA || keyB;
        }

        byte getKeyInput()
        {
            return Core.beakMemory.readMemory(0xFF00);
        }

        public void readInput()
        {
            Core.beakCPU.stop = false;
            byte keyInput = getKeyInput();
            bool interrupt = false;

            if (((keyInput & 0x10) >> 4) == 1)
            {

                if (keyA)
                { //Z //A
                    keyInput &= 0xFE;
                    interrupt = true;
                    //keyA = false; //Disable repeat
                }
                else
                {
                    keyInput |= 0x01;
                }

                if (keyB)
                { //X //B
                    keyInput &= 0xFD;
                    interrupt = true;
                    //keyB = false; //Disable repeat
                }
                else
                {
                    keyInput |= 0x02;
                }

                if (keySelect)
                { //Control //Select
                    keyInput &= 0xFB;
                    interrupt = true;
                    //keySelect = false; //Disable repeat
                }
                else
                {
                    keyInput |= 0x04;
                }


                if (keyStart)
                { //Enter //Start
                    keyInput &= 0xF7;
                    interrupt = true;
                    //keyStart = false; //Disable repeat
                }
                else
                {

                    keyInput |= 0x08;
                }

            }
            else if (((keyInput & 0x20) >> 5) == 1)//(keyInput == 0x20)
            {

                if (!(keyRight && keyLeft)) //Detect if both inputs are NOT enabled at once
                {
                    if (keyRight)
                    {
                        keyInput &= 0xFE;
                        interrupt = true;
                    }
                    else
                    {
                        keyInput |= 0x01;
                    }

                    if (keyLeft)
                    {
                        keyInput &= 0xFD;
                        interrupt = true;
                    }
                    else
                    {
                        keyInput |= 0x02;
                    }
                }
                else //To solve issue of multiple key input on one axis we will ignore input when both left and right are pressed at the same time.
                {
                    keyInput |= 0x01;
                    keyInput |= 0x02;
                }

                if (!(keyUp && keyDown)) //Detect if both inputs are NOT enabled at once
                {
                    if (keyUp)
                    {
                        keyInput &= 0xFB;
                        interrupt = true;
                    }
                    else
                    {
                        keyInput |= 0x04;
                    }

                    if (keyDown)
                    {
                        keyInput &= 0xF7;
                        interrupt = true;
                    }
                    else
                    {
                        keyInput |= 0x08;
                    }
                }
                else //To solve issue of multiple key input on one axis we will ignore input when both left and right are pressed at the same time.
                {
                    keyInput |= 0x04;
                    keyInput |= 0x08;
                }

            }
            else
            {
                keyInput |= 0x01;
                keyInput |= 0x02;
                keyInput |= 0x04;
                keyInput |= 0x08;
            }


            //Bit 7 and 6 are always 1
            keyInput |= 0x80; //Bit 7
            keyInput |= 0x40; //Bit 6

            if (interrupt)
            {
                Core.beakMemory.writeMemory(0xFF0F, (byte)(Core.beakMemory.readMemory(0xFF0F) | 0x10));
            }

            Core.beakMemory.writeMemory(0xFF00, keyInput);
        }

        public void setKeyInput(int keyCode, bool enabled)
        {
            Core.beakCPU.stop = false;

            switch (keyCode)
            {
                case 0:
                    {
                        keyUp = enabled;
                        break;
                    }
                case 1:
                    {
                        keyDown = enabled;
                        break;
                    }
                case 2:
                    {
                        keyLeft = enabled;
                        break;
                    }
                case 3:
                    {
                        keyRight = enabled;
                        break;
                    }
                case 4:
                    {
                        keyStart = enabled;
                        break;
                    }
                case 5:
                    {
                        keySelect = enabled;
                        break;
                    }
                case 6:
                    {
                        keyA = enabled;
                        break;
                    }
                case 7:
                    {
                        keyB = enabled;
                        break;
                    }
            }
        }


    }
}
