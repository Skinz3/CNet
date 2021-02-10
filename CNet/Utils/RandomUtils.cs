using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.Utils
{
    public class RandomUtils
    {
        private static AsyncRandom _random;

        static RandomUtils()
        {
            _random = new AsyncRandom();
        }
        public static float UniformRandom(float min = 0, float max = 1)
        {
            return (float)_random.NextDouble(min, max);
        }
        public static float NormalRandom(float mean = 0.5f, float stdDev = 0.15f)
        {
            double u1 = 1.0f - _random.NextDouble();
            double u2 = 1.0f - _random.NextDouble();

            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double randNormal = mean + stdDev * randStdNormal;

            return (float)randNormal;
        }
    }
}
