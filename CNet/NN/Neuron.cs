using CNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.NN
{
    public class Neuron
    {
        public float[] Weigths
        {
            get;
            private set;
        }
        public float Bias
        {
            get;
            set;
        }

        public Neuron(int inputLength, float bias)
        {
            this.Weigths = new float[inputLength];
            this.Bias = bias;
        }
        public Neuron(float[] weigths, float bias)
        {
            this.Weigths = weigths;
            this.Bias = bias;
        }
        public void Initialize()
        {
            AsyncRandom random = new AsyncRandom();

            for (int i = 0; i < Weigths.Length; i++)
            {
                Weigths[i] = RandomUtils.NormalRandom(0.3f) * 0.10f;
            }
        }
    }
}
