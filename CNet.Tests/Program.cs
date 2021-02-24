using CNet.Data;
using CNet.NN;
using CNet.NN.Layers;
using CNet.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.Tests
{
    class Program
    {
        static void FromImageBatches()
        {
            List<Tensor> inputs = TensorConverter.InputsFromImage("Test/");

            Layer layer1 = new DenseLayer(28 * 28, 64, ActivationType.Softmax);

            Layer layer2 = new DenseLayer(64, 10, ActivationType.ReLU);

            foreach (var input in inputs)
            {
                Tensor rl1 = layer1.Forward(input);

                Tensor rl2 = layer2.Forward(rl1);

                Console.WriteLine(rl2);
            }


            Console.ReadLine();
        }
        static void Main(string[] args)
        {
         
        }
    }
}
