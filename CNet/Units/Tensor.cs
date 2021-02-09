using CNet.Exceptions;
using CNet.Units;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CNet.Utils;

namespace CNet
{
    public class Tensor
    {
        private const float DummyValue = 0;

        public Shape Shape
        {
            get;
        }

        private float[][] _matrix;

        public Tensor(int heigth, int width)
        {
            _matrix = new float[heigth][];

            for (int i = 0; i < heigth; i++)
            {
                _matrix[i] = new float[width];

                for (int j = 0; j < width; j++)
                {
                    _matrix[i][j] = DummyValue;
                }
            }

            this.Shape = new Shape(heigth, width);
        }
        public Tensor(params float[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Invalid matrix, null or empty.", "array");
            }

            this._matrix = new float[1][];
            this._matrix[0] = array;
            this.Shape = new Shape(1, array.Length);
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

            this.Shape = new Shape(array.Length, length);
        }
        /// <summary> 
        /// Apply a dot product. (CF numpy)
        /// </summary>
        public float Dot(Tensor other)
        {
            if (this.Shape.Heigth != 1)
            {
                throw new ArgumentException("The first tensor must be unidimensional.");
            }
            if (this.Shape.Width != other.Shape.Width)
            {
                throw new ArgumentException("Both tensor must have same width.");
            }

            float result = 0;

            for (int i = 0; i < this.Shape.Width; i++)
            {
                for (int j = 0; j < other.Shape.Heigth; j++)
                {
                    result += this[0, i] * other[j, i];
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
           return TensorUtils.GetString(this);
        }
    }
}
