using CNet.Data;
using CNet.NN;
using CNet.NN.Layers;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Batch batch = new Batch(new Tensor[]
            {
                 new Tensor(new float[][]
                 {
                     new float[] {1,2,3,4 },
                      new float[] {1,2,3,4 }
                 }),
            });

            Neuron n1 = new Neuron(new Tensor(0.2f, 0.8f, -0.5f, 1.0f), 2);
            Neuron n2 = new Neuron(new Tensor(0.5f, -0.91f, 0.26f, -0.5f), 3);
            Neuron n3 = new Neuron(new Tensor(-0.26f, -0.27f, 0.17f, 0.87f), 0.5f);

            Layer layer1 = new StandardLayer(n1, n2, n3);

            Tensor results = layer1.Forward(batch);

            Console.WriteLine(results);

            Console.ReadLine();
        }
    }
}
