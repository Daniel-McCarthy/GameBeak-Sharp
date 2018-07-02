using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBeak.Classes
{
    class ColorExtensions
    {
        private static byte maxValue(byte a, byte b, byte c)
        {
            return Math.Max(a, Math.Max(b, c));
        }
        private static float maxValue(float a, float b, float c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        private static byte minValue(byte a, byte b, byte c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
        private static float minValue(float a, float b, float c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

    }
}
