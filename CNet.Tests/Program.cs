using CNet.NN;
using CNet.NN.Layers;
using CNet.Utils;
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

            Tensor inputs = new Tensor(new float[][]
            {
                   new float[] { 1, 2 , 3 , 2.5f },
                   new float[] { 2.0f, 5.0f , -1.0f , 2.0f },
                   new float[] { -1.5f, 2.7f , 3.3f , -0.8f },
            });


            Layer layer1 = new DenseLayer(4, 5);
            Layer layer2 = new DenseLayer(5, 2);

            Tensor rl1 = layer1.Forward(inputs);
            Tensor rl2 = layer2.Forward(rl1);

            Console.WriteLine(rl2); 

          Console.ReadLine();
        }
    }
}
