using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.NN
{
    public class Activations
    {
        public static void Softmax(Tensor tensor)
        {
            for (int i = 0; i < tensor.Shape.Rows; i++)
            {
                var z_exp = tensor.GetRow(i).Select(x => Math.Exp(x));

                var sum_z_exp = z_exp.Sum();

                var softmax = z_exp.Select(v => (float)(v / sum_z_exp)).ToArray();

                tensor.SetRow(i, softmax);
            }
        }
        public static void ReLU(Tensor tensor)
        {
            for (int i = 0; i < tensor.Shape.Rows; i++)
            {
                for (int j = 0; j < tensor.Shape.Colomns; j++)
                {
                    tensor[i, j] = ReLU(tensor[i, j]);
                }
            }
        }
        public static float Sigmoid(float x)
        {
            return 1f / (1 + (float)Math.Exp(-x));
        }
        public static float ReLU(float x)
        {
            return Math.Max(0, x);
        }
    }
}
