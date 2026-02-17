using System.Runtime.CompilerServices;

namespace Spnch.Csharp.Pipe;

public static partial class PipeExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TR _<T, TR>(this T val, Func<T, TR> f) => f(val);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T _<T>(this T val, Action<T> a)
    {
        a(val);
        return val;
    }
}