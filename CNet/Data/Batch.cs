using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.Data
{
    public class Batch
    {
        public Tensor[] Inputs { get; }

        public Batch(Tensor[] inputs)
        {
            this.Inputs = inputs;

            foreach (var tensor in inputs)
            {
                if (tensor.Shape.Heigth != 1)
                {
                    throw new ArgumentException("Inputs must be vectors.");
                }
            }
        }
    }
}
