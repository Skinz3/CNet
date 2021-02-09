using CNet.Exceptions;
using CNet.Units;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CNet
{
    public class Tensor
    {
        private const float DefaultValue = 0;

        private Shape shape;

        private float[][] _matrix;

        public Tensor(int width, int heigth)
        {
            _matrix = new float[width][];

            for (int i = 0; i < width; i++)
            {
                _matrix[i] = new float[heigth];

                for (int j = 0; j < heigth; j++)
                {
                    _matrix[i][j] = DefaultValue;
                }
            }

            this.shape = new Shape(width, heigth);
        }
        public Tensor(params float[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Invalid matrix, null or empty.", "array");
            }

            this._matrix = new float[1][];
            this._matrix[0] = array;
            this.shape = new Shape(1, array.Length);
        }
       
        public Tensor(float[][] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Invalid matrix, null or empty.", "array");
            }

            this._matrix = array;

            int length = _matrix[0].Length;

            if (!_matrix.All(x => x.Length == length))
            {
                throw new InvalidTensorShapeException("Invalid matrix dimensions.");
            }

            this.shape = new Shape(array.Length, length);
        }
        /// <summary>
        /// Apply a dot product. (CF numpy)
        /// </summary>
        public float Dot(Tensor other)
        {
            if (shape != other.shape)
            {
                throw new ArgumentException("todo");
            }

            float result = 0;

            for (int i = 0; i < shape.Width; i++)
            {
                for (int j = 0; j < shape.Heigth; j++)
                {
                    result += this[i, j] * other[i, j];
                }
            }

            return result;
        }

        public float this[int i, int j]
        {
            get
            {
                return _matrix[i][j];
            }
            set
            {
                _matrix[i][j] = value;
            }
        }
        public override string ToString()
        {
            return "Tensor " + shape.ToString();
        }
    }
}
