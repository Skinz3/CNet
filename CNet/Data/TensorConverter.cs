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
        public static List<Tensor> InputsFromImage(string path, int batchSize = 10)
        {
            int size = 28 * 28;

            var files = Directory.GetFiles(path);

            List<Tensor> results = new List<Tensor>();


            int i = 0;

            Tensor current = new Tensor(batchSize, size);

            foreach (var file in files)
            {
                if (i % batchSize != 0)
                {
                    Bitmap bitmap = (Bitmap)Image.FromFile(file);

                    current.SetRow(i % batchSize, FromBitmap(bitmap));

                    bitmap.Dispose();


                }
                else
                {
                    results.Add(current);
                    current = new Tensor(batchSize, size);
                }

                i++;
            }

            return results;

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

                    float value = (float)(pixel.R + pixel.G + pixel.B) / 3f;

                    float valueNormalized = value / 255;

                    result[k] = valueNormalized;
                    k++;
                }
            }

            if (result.All(x => x == 0))
            {

            }

            return result;
        }
    }
}
