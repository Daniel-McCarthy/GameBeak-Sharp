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

        public static float[] rgbToHSL(byte rVal, byte gVal, byte bVal)
        {
            float r = rVal / 255f;
            float g = gVal / 255f;
            float b = bVal / 255f;
            float max = maxValue(r, g, b);
            float min = minValue(r, g, b);
            float intensity = (r + g + b) * (1f / 3f);

            // Calculate Chroma.
            float chroma = max - min;

            // Calculate Hue.
            float hue = 0;

            if (max == r)
            {
                hue = ((g - b) / chroma) % 6;
            }
            else if (max == g)
            {
                hue = ((b - r) / chroma) + 2;
            }
            else if (max == b)
            {
                hue = ((r - g) / chroma) + 4;
            }

            hue *= 60f;

            // Calculate Saturation.
            float saturation = (intensity == 0) ? 0 : (1 - (min / intensity));

            // Calculate Lightness.
            float lightness = (max + min) * .5f;

            return new float[] { hue, saturation, lightness };
        }

    }
}
