using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace HashCode;

static class StringUtil
{
    public const int HashOfEmptyString = 19;

    /// <summary>
    /// Platform independent hash code, can be used to persist records. <see cref="String.ToString()"/>
    /// is different for x86 and x64, so it can't be used for serialization.
    /// </summary>
    /// <param name="s">source string</param>
    /// <returns>hashcode</returns>
    [Pure]
    public static int GetPlatformIndependentHashCode(this string? s)
    {
        return GetPlatformIndependentHashCode(s, seed: HashOfEmptyString);
    }

    [Pure]
    [SuppressMessage("ReSharper", "ForCanBeConvertedToForeach")]
    [SuppressMessage("ReSharper", "LoopCanBeConvertedToQuery")]
    public static int GetPlatformIndependentHashCode(this string? s, int seed)
    {
        if (s == null) return seed;

        var hash = seed;
        unchecked
        {
            for (var index = 0; index < s.Length; index++)
            {
                hash = hash * 31 + s[index];
            }
        }

        return hash;
    }

    /// <remarks>
    /// The difference between this function and the previous one (without the suffix 'Fast')
    /// is that here the for-loop is unrolled manually and 8 bytes are processed per the iteration
    /// instead of 2 bytes per the iteration in the "naive" implementation.
    /// The function is "forked" instead of optimizing existing 'GetPlatformIndependentHashCode'
    /// because of the backward-compatibility, see
    /// https://jetbrains.slack.com/archives/C0B1M5ADS/p1757287553911939?thread_ts=1757139775.426599&cid=C0B1M5ADS
    /// </remarks>
    [Pure]
    public static unsafe int GetPlatformIndependentHashCodeFast(this string s)
    {
        var hash = HashOfEmptyString;
        unchecked
        {
            fixed (char* chPtr = s)
            {
                var n = s.Length;
                var intPtr = (int*)chPtr;
                for (; n > 2; n -= 4, intPtr += 2)
                {
                    hash = 31 * 31 * hash
                         + 31 * intPtr[0]
                         + intPtr[1];
                }

                if (n > 0)
                    hash = hash * 31 + *intPtr;

            }
        }

        return hash;
    }

    /// <summary>
    /// Platform independent case-insensitive hash code, can be used to persist records. <see cref="String.ToString()"/>
    /// is different for x86 and x64, so it can't be used for serialization.
    /// </summary>
    /// <param name="s">source string</param>
    /// <returns>hashcode</returns>
    [Pure]
    [SuppressMessage("ReSharper", "ForCanBeConvertedToForeach")]
    [SuppressMessage("ReSharper", "LoopCanBeConvertedToQuery")]
    public static int GetPlatformIndependentCaseInsensitiveHashCode(this string? s)
    {
        if (s == null) return HashOfEmptyString;

        var hash = HashOfEmptyString;
        unchecked
        {
            for (var index = 0; index < s.Length; index++)
            {
                hash = hash * 31 + s[index].ToLowerFast();
            }
        }

        return hash;
    }

    [Pure]
    public static unsafe int GetPlatformIndependentCaseInsensitiveHashCodeFast(this string s)
    {
        var hash = HashOfEmptyString;
        unchecked
        {
            fixed (char* chPtr = s)
            {
                var n = s.Length;
                var ptr = chPtr;
                for (; n > 2; n -= 4, ptr += 4)
                {
                    var c0 = ptr[0].ToLowerFast();
                    var c1 = ptr[1].ToLowerFast();
                    var c2 = ptr[2].ToLowerFast();
                    var c3 = ptr[3].ToLowerFast();
                    hash = 31 * 31 * hash
                         + 31 * Combine(c0, c1)
                         +  Combine(c2, c3);
                }

                if (n > 0)
                {
                    var c0 = ptr[0].ToLowerFast();
                    var c1 = ptr[1].ToLowerFast();
                    hash = hash * 31 + Combine(c0, c1);
                }
            }
        }

        return hash;
    }

    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int Combine(char c1, char c2)
    {
        unchecked
        {
            return (int)((uint)c1 << 16 | (uint)c2);
        }
    }

    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToLowerFast(this char c)
    {
        if (c <= '\x007f')
            return (uint)(c - 'A') <= 'Z' - 'A' ? (char)(c + 'a' - 'A') : c;

        return char.ToLowerInvariant(c);
    }
}

public class StringHashCode
{
    [Params(10, 11, 12, 13, 100, 101, 102, 103, 1000, 1001, 1002, 1003)]
    public int N;

    private string str;

    [GlobalSetup]
    public void GlobalSetup()
    {
        const string alphabet =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789\" !#$%&'()*+,-./:;<=>?@[]^_`{|}";
        var random = new Random(42);
        var chars = new char[N];
        for (int i = 0; i < N; i++)
            chars[i] = alphabet[random.Next(alphabet.Length)];
        str = new string(chars);
    }

    [Benchmark(Baseline = true)] public int HashCodeFast()
        => str.GetPlatformIndependentHashCodeFast();

    [Benchmark]  public int HashCode()
        => str.GetPlatformIndependentHashCode();

    [Benchmark] public int HashCodeCaseInsensitiveFast()
        => str.GetPlatformIndependentCaseInsensitiveHashCodeFast();

    [Benchmark] public int HashCodeCaseInsensitive()
        => str.GetPlatformIndependentCaseInsensitiveHashCode();
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<StringHashCode>();
    }
}
