using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.NN.Layers
{
    public class StandardLayer : Layer
    {
        public StandardLayer(params Neuron[] neurons)
        {
            this._neurons = neurons.ToList();
        }
    }
}
