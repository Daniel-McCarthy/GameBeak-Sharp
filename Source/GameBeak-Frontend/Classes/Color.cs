using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBeak_Frontend.Classes
{
    class Color
    {

        public static Color Black = new Color(0, 0, 0, 255);
        public static Color White = new Color(255, 255, 255, 255);


        public byte r;
        public byte g;
        public byte b;
        public byte a;

        public Color()
        {
	        r = g = b = a = 0;
        }

        public Color(byte newR, byte newG, byte newB)
        {
	        r = newR;
	        g = newG;
	        b = newB;
	        a = 255;
        }

        public Color(byte newR, byte newG, byte newB, byte newA)
        {
	        r = newR;
	        g = newG;
	        b = newB;
	        a = newA;
        }

        public uint getInt()
        {
            return (uint)((r << 24) | (g << 16) | (b << 8) | a);
        }

    }
}
