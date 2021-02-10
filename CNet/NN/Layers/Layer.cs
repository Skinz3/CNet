﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.NN.Layers
{
    public abstract class Layer
    {
        public const float DefaultBias = 0;

        private Neuron[] _neurons;

        private int _inputLength;

        public Layer(int inputLength, int neuronsCount)
        {
            this._neurons = new Neuron[neuronsCount];
            this._inputLength = inputLength;

            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < _neurons.Length; i++)
            {
                _neurons[i] = new Neuron(_inputLength, DefaultBias);
                _neurons[i].Initialize();
            }
        }

        private Tensor BuildWeightTensor()
        {
            int width = _inputLength;

            Tensor weights = new Tensor(_neurons.Length, width);

            for (int i = 0; i < _neurons.Length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    weights[i, j] = _neurons[i].Weigths[j];
                }
            }

            return weights;
        }
        private Tensor BuildBiases()
        {
            return new Tensor(_neurons.Select(x => x.Bias).ToArray());
        }

        public Tensor Forward(Tensor inputs)
        {
            Tensor weights = BuildWeightTensor();

            Tensor biases = BuildBiases();

            Tensor transposed = weights.Transpose();

            return inputs.Dot(transposed).VecSum(biases);
        }


    }
}
