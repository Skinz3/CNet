using CNet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.NN.Layers
{
    public abstract class Layer
    {
        protected List<Neuron> _neurons
        {
            get;
            set;
        }

        public Layer()
        {
            this._neurons = new List<Neuron>();
        }

        public Tensor Forward(Batch batch)
        {
            Tensor result = new Tensor(_neurons.Count, batch.Inputs.Length);

            for (int i = 0; i < _neurons.Count; i++)
            {
                for (int j = 0; j < batch.Inputs.Length; j++)
                {
                    result[i, j] = _neurons[i].Compute(batch.Inputs[j]);
                }
            }

            return result;
        }
    }
}
