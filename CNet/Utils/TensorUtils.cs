using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.Utils
{
    static class TensorUtils
    {
        public static string GetString(this Tensor tensor)
        {
            int rowLength = tensor.Shape.Width;
            int colLength = tensor.Shape.Heigth;

            StringBuilder builder = new StringBuilder();

            builder.Append("[");

            for (int i = 0; i < rowLength; i++)
            {
                if (i > 0)
                {
                    builder.Append(" ");
                }
                builder.Append("[");
                for (int j = 0; j < colLength; j++)
                {
                    string value = tensor[j, i].ToString().Replace(",", ".");

                    if (j < colLength - 1)
                    {
                        value += " ";
                    }

                    string str = value;

                    builder.Append(str);
                }


                builder.Append("]");

                if (i < rowLength - 1)
                {
                    builder.AppendLine();
                }
            }

            builder.Append("]");
            return builder.ToString();
        }
    }
}
