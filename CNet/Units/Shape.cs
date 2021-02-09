using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.Units
{
    public class Shape
    {
        public int Width
        {
            get;
            set;
        }
        public int Heigth
        {
            get;
            set;
        }
        public Shape(int heigth, int width)
        {
            this.Width = width;
            this.Heigth = heigth;
        }
        public override string ToString()
        {
            return "(" + Heigth + "," + Width + ")";
        }

        public static bool operator !=(Shape a, Shape b)
        {
            return !(a == b);
        }
        public static bool operator ==(Shape a, Shape b)
        {
            return a.Heigth == b.Heigth && a.Width == b.Width;
        }

        public override bool Equals(object obj)
        {
            Shape other = obj as Shape;

            if (other != null)
            {
                return other.Width == this.Width && other.Heigth == this.Heigth;
            }
            else
            {
                return false;
            }
        }
    }
}
