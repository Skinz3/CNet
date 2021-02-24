using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.NN
{
    public class Losses
    {
        public static float CrossEntropy(Tensor results, Tensor target)
        {
            float loss = 0;

            for (int i = 0; i < results.Shape.Rows; i++)
            {
                for (int j = 0; j < results.Shape.Colomns; j++)
                {
                    loss += (float)Math.Log(results[i, j]) * target[i, j];
                }
            }

            return -loss;
        }
    }
}
