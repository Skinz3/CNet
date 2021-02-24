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
using System.Drawing;

namespace CNet
{
    public class Tensor
    {
        private const float DummyValue = 0;

        public Shape Shape
        {
            get;
        }

        public bool IsLineVector => Shape.Rows == 1;

        public bool IsColomnVector => Shape.Colomns == 1;

        public bool IsVector => IsLineVector || IsColomnVector;



        private float[][] _matrix;

        public Tensor(Shape shape) : this(shape.Rows, shape.Colomns)
        {

        }
        public Tensor(int length)
        {
            this._matrix = new float[1][];
            this._matrix[0] = new float[length];
            this.Shape = new Shape(1, length);
        }
        public Tensor(int rows, int colomns)
        {
            if (rows <= 0 || colomns <= 0)
            {
                throw new ArgumentException("Cannot create a null matrix.");
            }

            _matrix = new float[rows][];

            for (int i = 0; i < rows; i++)
            {
                _matrix[i] = new float[colomns];

                for (int j = 0; j < colomns; j++)
                {
                    _matrix[i][j] = DummyValue;
                }
            }

            this.Shape = new Shape(rows, colomns);
        }
        /*
         * Create a line vector.
         */
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

        public Tensor Transpose()
        {
            Tensor result = new Tensor(Shape.Colomns, Shape.Rows);

            for (int i = 0; i < Shape.Rows; i++)
            {
                for (int j = 0; j < Shape.Colomns; j++)
                {
                    result[j, i] = this[i, j];
                }
            }

            return result;
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
        /// this * other
        /// Apply a dot product. 
        /// This is naive dot implementation.
        /// </summary>
        public Tensor Dot(Tensor other)
        {
            if (this.Shape.Colomns != other.Shape.Rows)
            {
                throw new ArgumentException("Cannot multiply matrix. Invalid shapes.");
            }

            Tensor result = new Tensor(this.Shape.Rows, other.Shape.Colomns);

            for (int i = 0; i < this.Shape.Rows; i++)
            {
                for (int j = 0; j < other.Shape.Colomns; j++)
                {
                    for (int k = 0; k < this.Shape.Colomns; k++)
                    {
                        result[i, j] += this[i, k] * other[k, j];
                    }
                }
            }

            return result;
        }


        /*
         * this (matrix) + vec (vector)
         */
        public Tensor VecSum(Tensor vec)
        {
            if (!vec.IsLineVector)
            {
                throw new ArgumentException("The parameter must be a line vector.");
            }

            Tensor result = new Tensor(this.Shape);

            for (int i = 0; i < this.Shape.Rows; i++)
            {
                for (int j = 0; j < this.Shape.Colomns; j++)
                {
                    result[i, j] = this[i, j] + vec[0, j];
                }
            }
            return result;
        }
        public void SetRow(int i, float[] row)
        {
            _matrix[i] = row;
        }
        public float[] GetRow(int i)
        {
            return _matrix[i];
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
