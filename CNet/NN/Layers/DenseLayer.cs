using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.NN.Layers
{
    public class DenseLayer : Layer
    {
        public DenseLayer(int inputsLength, int neuronsCount, ActivationType activationType) :
            base(inputsLength, neuronsCount, activationType)
        {

        }
    }
}
