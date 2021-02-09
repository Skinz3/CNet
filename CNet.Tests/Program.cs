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
            Tensor inputs = new Tensor(1f, 2f, 3, 2.5f);

            Tensor weigth = new Tensor(0.2f, 0.8f, -0.5f, 1.0f);

            Neuron neuron = new Neuron(weigth, 2f);


            float value = neuron.Compute(inputs);
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
}
