namespace Learning_AdvancedCSharpStudies.Helpers;

public static class ArrayExtensions
{
    /// <param name="intArray">The integer array to extend.</param>
    extension(int[] intArray)
    {
        /// <summary>
        /// Creates a large array of random integers within the specified range.
        /// </summary>
        /// <param name="size">The size of the array to create. Must be greater than zero.</param>
        /// <param name="minValue">The inclusive minimum value for random integers.</param>
        /// <param name="maxValue">The exclusive maximum value for random integers.</param>
        /// <returns>A new integer array of the specified size filled with random values.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when size is less than or equal to zero, or when maxValue is not greater than minValue.</exception>
        public int[] MakeBigRandomIntArray(int size, int minValue, int maxValue)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(size, 0);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(minValue, maxValue);

            int[] bigIntArray = new int[size];
            for (int i = 0; i < bigIntArray.Length; i++)
            {
                bigIntArray[i] = Random.Shared.Next(minValue, maxValue);
            }
            return bigIntArray;
        }
    }

}