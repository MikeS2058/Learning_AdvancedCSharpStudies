namespace Learning_AdvancedCSharpStudies.Helpers;

public static class ArrayMakers
{
    public static T[] CreateArray<T>(int length) where T : new()
    {
        T[] array = new T[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = new T();
        }

        return array;
    }

    public static T[] CreateArrayWithDefaultValues<T>(int length, T defaultValue)
    {
        T[] array = new T[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = defaultValue;
        }

        return array;
    }

    /// <summary>
    /// Creates an array of random values for any supported value type.
    /// </summary>
    /// <typeparam name="T">A value type (struct).</typeparam>
    /// <param name="length">The length of the array.</param>
    /// <param name="min">The minimum value (inclusive).</param>
    /// <param name="max">The maximum value (exclusive).</param>
    /// <returns>An array of random values of type <typeparamref name="T"/>.</returns>
    /// <exception cref="NotSupportedException">Thrown if <typeparamref name="T"/> is not a supported value type.</exception>
    public static T[] CreateArrayWithRandomValues<T>(int length, int min, int max) where T : struct
    {
        T[] array = new T[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = typeof(T) switch
            {
                var t when t == typeof(int) => (T)(object)Random.Shared.Next(min, max),
                var t when t == typeof(double) => (T)(object)(Random.Shared.NextDouble() * (max - min) + min),
                var t when t == typeof(float) => (T)(object)((float)(Random.Shared.NextDouble() * (max - min) + min)),
                var t when t == typeof(bool) => (T)(object)(Random.Shared.Next(0, 2) == 1),
                var t when t == typeof(byte) => (T)(object)(byte)Random.Shared.Next(min < 0 ? 0 : min,
                    max > byte.MaxValue ? byte.MaxValue : max),
                var t when t == typeof(sbyte) => (T)(object)(sbyte)Random.Shared.Next(
                    min < sbyte.MinValue ? sbyte.MinValue : min, max > sbyte.MaxValue ? sbyte.MaxValue : max),
                var t when t == typeof(short) => (T)(object)(short)Random.Shared.Next(
                    min < short.MinValue ? short.MinValue : min, max > short.MaxValue ? short.MaxValue : max),
                var t when t == typeof(ushort) => (T)(object)(ushort)Random.Shared.Next(
                    min < ushort.MinValue ? ushort.MinValue : min, max > ushort.MaxValue ? ushort.MaxValue : max),
                var t when t == typeof(long) => (T)(object)(long)(Random.Shared.NextDouble() * (max - min) + min),
                var t when t == typeof(ulong) => (T)(object)(ulong)(Random.Shared.NextDouble() * (max - min) + min),
                var t when t == typeof(char) => (T)(object)(char)Random.Shared.Next(
                    min < char.MinValue ? char.MinValue : min, max > char.MaxValue ? char.MaxValue : max),
                var t when t == typeof(decimal) => (T)(object)(decimal)(Random.Shared.NextDouble() * (max - min) + min),
                var t when t == typeof(DateTime) => (T)(object)DateTime.MinValue.AddDays(
                    Random.Shared.Next(0, max - min) + min),
                var t when t == typeof(IntPtr) => (T)(object)new IntPtr(Random.Shared.Next(min, max)),
                var t when t == typeof(UIntPtr) => (T)(object)new UIntPtr(
                    (uint)Random.Shared.Next(min < 0 ? 0 : min, max)),
                var t when t == typeof(Guid) => (T)(object)Guid.NewGuid(),
                var t when t == typeof(ValueTuple<int, int>) => (T)(object)(Random.Shared.Next(min, max),
                    Random.Shared.Next(min, max)),
                _ => throw new NotSupportedException($"Random generation for type '{typeof(T)}' is not supported.")
            };
        }

        return array;
    }

    /// <summary>
    /// Asynchronously creates an array of random values for any supported value type.
    /// </summary>
    /// <typeparam name="T">A value type (struct).</typeparam>
    /// <param name="length">The length of the array.</param>
    /// <param name="min">The minimum value (inclusive).</param>
    /// <param name="max">The maximum value (exclusive).</param>
    /// <returns>A task that represents the asynchronous operation. The value of the TResult parameter contains an array of random values of type <typeparamref name="T"/>.</returns>
    /// <exception cref="NotSupportedException">Thrown if <typeparamref name="T"/> is not a supported value type.</exception>
    public static async Task<T[]> CreateArrayWithRandomValuesAsync<T>(int length, int min, int max) where T : struct
    {
        // Simulate asynchronous operation (e.g., for future extensibility or I/O-bound random sources)
        await Task.Yield();
        T[] array = new T[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = typeof(T) switch
            {
                var t when t == typeof(int) => (T)(object)Random.Shared.Next(min, max),
                var t when t == typeof(double) => (T)(object)(Random.Shared.NextDouble() * (max - min) + min),
                var t when t == typeof(float) => (T)(object)((float)(Random.Shared.NextDouble() * (max - min) + min)),
                var t when t == typeof(bool) => (T)(object)(Random.Shared.Next(0, 2) == 1),
                var t when t == typeof(byte) => (T)(object)(byte)Random.Shared.Next(min < 0 ? 0 : min,
                    max > byte.MaxValue ? byte.MaxValue : max),
                var t when t == typeof(sbyte) => (T)(object)(sbyte)Random.Shared.Next(
                    min < sbyte.MinValue ? sbyte.MinValue : min, max > sbyte.MaxValue ? sbyte.MaxValue : max),
                var t when t == typeof(short) => (T)(object)(short)Random.Shared.Next(
                    min < short.MinValue ? short.MinValue : min, max > short.MaxValue ? short.MaxValue : max),
                var t when t == typeof(ushort) => (T)(object)(ushort)Random.Shared.Next(
                    min < ushort.MinValue ? ushort.MinValue : min, max > ushort.MaxValue ? ushort.MaxValue : max),
                var t when t == typeof(long) => (T)(object)(long)(Random.Shared.NextDouble() * (max - min) + min),
                var t when t == typeof(ulong) => (T)(object)(ulong)(Random.Shared.NextDouble() * (max - min) + min),
                var t when t == typeof(char) => (T)(object)(char)Random.Shared.Next(
                    min < char.MinValue ? char.MinValue : min, max > char.MaxValue ? char.MaxValue : max),
                var t when t == typeof(decimal) => (T)(object)(decimal)(Random.Shared.NextDouble() * (max - min) + min),
                var t when t == typeof(DateTime) => (T)(object)DateTime.MinValue.AddDays(
                    Random.Shared.Next(0, max - min) + min),
                var t when t == typeof(IntPtr) => (T)(object)new IntPtr(Random.Shared.Next(min, max)),
                var t when t == typeof(UIntPtr) => (T)(object)new UIntPtr(
                    (uint)Random.Shared.Next(min < 0 ? 0 : min, max)),
                var t when t == typeof(Guid) => (T)(object)Guid.NewGuid(),
                var t when t == typeof(ValueTuple<int, int>) => (T)(object)(Random.Shared.Next(min, max),
                    Random.Shared.Next(min, max)),
                _ => throw new NotSupportedException($"Random generation for type '{typeof(T)}' is not supported.")
            };
        }

        return array;
    }
}