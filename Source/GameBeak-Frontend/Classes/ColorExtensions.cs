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

        public static void rgbToHSL(byte rVal, byte gVal, byte bVal, out float h, out float s, out float l)
        {
            float[] hsl = rgbToHSL(rVal, gVal, bVal);
            h = hsl[0];
            s = hsl[1];
            l = hsl[2];
        }

        public static byte[] hslToRGB(float hVal, float sVal, float lVal)
        {
            hVal /= 60f;
            float chroma = (1 - Math.Abs((lVal * 2) - 1)) * sVal;
            float x = chroma * (1 - Math.Abs((hVal % 2) - 1));

            float point1 = 0;
            float point2 = 0;
            float point3 = 0;

            if (hVal > 0f && hVal <= 1f)
            {
                point1 = chroma;
                point2 = x;
            }
            else if (hVal <= 2f)
            {
                point1 = x;
                point2 = chroma;
            }
            else if (hVal <= 3f)
            {
                point2 = chroma;
                point3 = x;
            }
            else if (hVal <= 4f)
            {
                point2 = x;
                point3 = chroma;
            }
            else if (hVal <= 5f)
            {
                point1 = x;
                point3 = chroma;
            }
            else if (hVal <= 6f)
            {
                point1 = chroma;
                point3 = x;
            }

            // Calculate RGB.
            float min = lVal - (chroma * .5f);
            byte r = (byte)((point1 + min) * 255f);
            byte g = (byte)((point2 + min) * 255f);
            byte b = (byte)((point3 + min) * 255f);

            return new byte[] { r, g, b };
        }

        public static void hslToRGB(float hVal, float sVal, float lVal, out byte rVal, out byte gVal, out byte bVal)
        {
            byte[] rgbValues = hslToRGB(hVal, sVal, lVal);
            rVal = rgbValues[0];
            gVal = rgbValues[1];
            bVal = rgbValues[2];
        }

    }
}
