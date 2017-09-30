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
        public static Color Clear = new Color(0, 0, 0, 0);


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

        public Color(byte newR, byte newG, byte newB, byte newA, bool isARGBFormat)
        {
            if (isARGBFormat)
            {
                r = newG;
                g = newB;
                b = newA;
                a = newR;
            }
            else
            {
                r = newR;
                g = newG;
                b = newB;
                a = newA;
            }
        
        }

        public Color(Color newColor)
        {
            r = newColor.r;
            g = newColor.g;
            b = newColor.b;
            a = newColor.a;
        }

        public uint getRGBAInt()
        {
            return (uint)((r << 24) | (g << 16) | (b << 8) | a);
        }

        public uint getARGBInt()
        {
            return (uint)((a << 24) | (r << 16) | (g << 8) | b);
        }


        public static bool operator == (Color color1, Color color2)
        {
            return (color1.r == color2.r) && (color1.g == color2.g) && (color1.b == color2.b) && (color1.a == color2.a);
        }

        public static bool operator != (Color color1, Color color2)
        {
            return (color1.r != color2.r) || (color1.g != color2.g) || (color1.b != color2.b) || (color1.a != color2.a);
        }

    }
}
