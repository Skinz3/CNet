using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.NN
{
    public class Layer
    {
        private List<Neuron> Neurons
        {
            get;
            set;
        }

        public Layer(int neuronsCount)
        {
            this.Neurons = new List<Neuron>(neuronsCount);
        }
    }
}
