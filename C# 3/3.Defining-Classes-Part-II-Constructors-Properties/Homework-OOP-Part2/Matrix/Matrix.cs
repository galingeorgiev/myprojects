/*Define a class Matrix<T> to hold a matrix
*of numbers (e.g. integers, floats, decimals).*/

using System;

namespace Matrix
{
    class Matrix<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IFormattable, IEquatable<T>
    {
        private T[,] matrix;

        //Define constructor
        public Matrix(int row, int col)
        {
            matrix = new T[row, col];
        }

        //Define indexer
        public T this[int row, int col]
        {
            get
            {
                if (row < this.matrix.GetLength(0) & col < this.matrix.GetLength(1))
                {
                    return matrix[row, col];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (row < this.matrix.GetLength(0) & col < this.matrix.GetLength(1))
                {
                    matrix[row, col] = value;
                    if (typeof(T) == typeof(DateTime))
                    {
                        throw new ApplicationException("Matrix cannot contain object of type DateTime");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        private bool Equal(Matrix<T> other)
        {
            if (this.matrix.GetLength(0) == other.matrix.GetLength(1) & this.matrix.GetLength(1) == other.matrix.GetLength(0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int DimensionRow()
        {
            return this.matrix.GetLength(0);
        }

        private int DimensionCol()
        {
            return this.matrix.GetLength(1);
        }

        //Override operators

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Equal(secondMatrix))
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.DimensionRow(), firstMatrix.DimensionCol());
                for (int row = 0; row < firstMatrix.DimensionRow(); row++)
                {
                    for (int col = 0; col < firstMatrix.DimensionCol(); col++)
                    {
                        resultMatrix[row, col] = (dynamic)firstMatrix[row, col] + secondMatrix[row, col];
                    }
                }
                return resultMatrix;
            }
            else
            {
                throw new ApplicationException("Matrixs does not equals.");
            }
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Equal(secondMatrix))
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.DimensionRow(), firstMatrix.DimensionCol());
                for (int row = 0; row < firstMatrix.DimensionRow(); row++)
                {
                    for (int col = 0; col < firstMatrix.DimensionCol(); col++)
                    {
                        resultMatrix[row, col] = (dynamic)firstMatrix[row, col] - secondMatrix[row, col];
                    }
                }
                return resultMatrix;
            }
            else
            {
                throw new ApplicationException("Matrixs does not equals.");
            }
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.DimensionCol() == secondMatrix.DimensionRow())
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.DimensionRow(), firstMatrix.DimensionCol());
                for (int newMatrixRow = 0; newMatrixRow < firstMatrix.DimensionRow(); newMatrixRow++)
                {
                    for (int newMatrixCol = 0; newMatrixCol < firstMatrix.DimensionCol(); newMatrixCol++)
                    {
                        dynamic sum = 0;
                        for (int col = 0; col < firstMatrix.DimensionCol(); col++)
                        {
                            sum = (dynamic)firstMatrix[newMatrixRow, col] * secondMatrix[col, newMatrixCol];
                        }
                        resultMatrix[newMatrixRow, newMatrixCol] = sum;
                    }
                }
                return resultMatrix;
            }
            else
            {
                throw new ApplicationException("Matrixs does not equals.");
            }
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int matrixRow = 0; matrixRow < matrix.DimensionRow(); matrixRow++)
            {
                for (int matrixCol = 0; matrixCol < matrix.DimensionCol(); matrixCol++)
                {
                    if (matrix[matrixRow, matrixCol].CompareTo((T)Convert.ChangeType(0, typeof(T))) == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int matrixRow = 0; matrixRow < matrix.DimensionRow(); matrixRow++)
            {
                for (int matrixCol = 0; matrixCol < matrix.DimensionCol(); matrixCol++)
                {
                    if (matrix[matrixRow, matrixCol].CompareTo((T)Convert.ChangeType(0, typeof(T))) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}