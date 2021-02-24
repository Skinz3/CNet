using System;
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

        private ActivationType _activation;

        public Layer(int inputLength, int neuronsCount, ActivationType activationType)
        {
            this._neurons = new Neuron[neuronsCount];
            this._inputLength = inputLength;
            this._activation = activationType;

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

        public void Backward()
        {

        }
        public Tensor Forward(Tensor inputs)
        {
            Tensor weights = BuildWeightTensor();

            Tensor biases = BuildBiases();

            Tensor transposed = weights.Transpose();

            Tensor result = inputs.Dot(transposed).VecSum(biases);

            switch (_activation)
            {
                case ActivationType.ReLU:
                    Activations.ReLU(result);
                    break;
                case ActivationType.Softmax:
                    Activations.Softmax(result);
                    break;

            }

            return result;
        }


    }
}
