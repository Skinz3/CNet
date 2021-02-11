using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.NN
{
    public class Activation
    {
        public static float Sigmoid(float x)
        {
            return 1f / (1 + (float)Math.Exp(-x));
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
        public static float ReLU(float x)
        {
            return Math.Max(0, x);
        }
    }
}
