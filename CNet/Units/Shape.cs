using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.Units
{
    public class Shape
    {
        public int Colomns
        {
            get;
            set;
        }
        public int Rows
        {
            get;
            set;
        }
        public Shape(int rows, int colomns)
        {
            this.Colomns = colomns;
            this.Rows = rows;
        }
        public override string ToString()
        {
            return "(" + Rows + "," + Colomns + ")";
        }

        public static bool operator !=(Shape a, Shape b)
        {
            return !(a == b);
        }
        public static bool operator ==(Shape a, Shape b)
        {
            return a.Rows == b.Rows && a.Colomns == b.Colomns;
        }

        public override bool Equals(object obj)
        {
            Shape other = obj as Shape;

            if (other != null)
            {
                return other.Colomns == this.Colomns && other.Rows == this.Rows;
            }
            else
            {
                return false;
            }
        }
    }
}
