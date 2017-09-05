using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBeak_Frontend.Classes
{
    class Image
    {
        private struct Size
        {
            public int x;
            public int y;
        };


        private Size sizeValues;
        private List<Color> pixels = new List<Color>();

        public Image()
        {
            sizeValues.x = 1;
            sizeValues.y = 1;
            pixels.Add(Color.White);
        }

        public Image(int width, int height)
        {
            Color defaultColor = Color.White; //It's possible this should have 0 alpha

            sizeValues.x = width;
            sizeValues.y = height;

            int finalSize = width * height;

            for (int i = 0; i < finalSize; i++)
            {
                pixels.Add(defaultColor);
            }
        }

        public Image(int width, int height, Color defaultColor)
        {
            sizeValues.x = width;
            sizeValues.y = height;

            int finalSize = width * height;

            for (int i = 0; i < finalSize; i++)
            {
                pixels.Add(defaultColor);
            }
        }

        public Color getPixel(int x, int y)
        {
            return pixels[x + (x * y)];
        }

        public bool setPixel(int x, int y, Color pixel)
        {
            if ((x < 0) || (x > sizeValues.x) || (y < 0) || (y > sizeValues.y))
            {
                return false;
            }
            else
            {
                pixels[x + (sizeValues.x * y)] = pixel;
                return true;
            }
        }

        public Tuple<int,int> getSize()
        {
            return new Tuple<int,int>(sizeValues.x, sizeValues.y);
        }

        public uint[] getIntArray()
        {
            int numberOfPixels = sizeValues.x * sizeValues.y;

            uint[] pixelInts = new uint[numberOfPixels];

            for (int i = 0; i < numberOfPixels; i++)
            {
                pixelInts[i] = pixels[i].getInt();
            }

            return pixelInts;
        }


    }
}
