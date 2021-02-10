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
            StringBuilder builder = new StringBuilder();

            builder.Append("[");

            int width = tensor.Shape.Colomns;
            int heigth = tensor.Shape.Rows;

            for (int i = 0; i < heigth; i++)
            {
                if (i > 0)
                {
                    builder.Append(" ");
                }
                builder.Append("[");
                for (int j = 0; j < width; j++)
                {
                    string value = tensor[i,j].ToString().Replace(",", ".");

                    if (j < width - 1)
                    {
                        value += " ";
                    }

                    string str = value;

                    builder.Append(str);
                }


                builder.Append("]");

                if (i < heigth - 1)
                {
                    builder.AppendLine();
                }
            }

            builder.Append("]");
            return builder.ToString();
        }
    }
}
