﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.NN
{
    public class Neuron
    {
        public Tensor Weigth
        {
            get;
            set;
        }
        public float Bias
        {
            get;
            set;
        }

        public Neuron(Tensor weigth, float bias)
        {
            this.Weigth = weigth;
            this.Bias = bias;
        }

        public float Compute(Tensor input)
        {
            return Weigth.Dot(input) + Bias;
        }
    }
}