using System.Runtime.CompilerServices;

namespace Spnch.Csharp.Pipe;

public static partial class PipeExtensions
{
    extension<T>(T val)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TR _<TR>(Func<T, TR> f) => f(val);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T _(Action<T> a)
        {
            a(val);
            return val;
        }
    }
}
