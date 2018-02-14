using System;

namespace MazeGenerator.ObjectModel.Utils
{
    public static class ArrayUtils
    {
        public static T[][] Create<T>(int rows, int cols, Func<int, int, T> factory)
        {
            T[][] result = new T[rows][];

            for (int i = 0; i < rows; i++)
            {
                result[i] = new T[cols];

                for (int j = 0; j < cols; j++)
                {
                    result[i][j] = factory(i, j);
                }
            }

            return result;
        }
    }
}