using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.Data
{
    public class TensorConverter
    {
        public static Tensor InputsFromImage(string path)
        {
            int size = 28 * 28;

            var files = Directory.GetFiles(path);

            Tensor result = new Tensor(files.Length, size);

            int i = 0;

            foreach (var file in files)
            {
                Bitmap bitmap = (Bitmap)Image.FromFile(file);

                result.SetRow(i, FromBitmap(bitmap));

                bitmap.Dispose();

                i++;
            }

            return result;

        }
        
        public static float[] FromBitmap(Bitmap bitmap)
        {
            float[] result = new float[bitmap.Width * bitmap.Height];

            int k = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    var pixel = bitmap.GetPixel(i, j);

                    float r = (float)pixel.R / byte.MaxValue;
                    float g = (float)pixel.G / byte.MaxValue;
                    float b = (float)pixel.B / byte.MaxValue;

                    result[k] = (r + g + b / 3f);
                    k++;
                }
            }

            return result;
        }
    }
}
