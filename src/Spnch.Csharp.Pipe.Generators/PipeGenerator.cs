using Microsoft.CodeAnalysis;

namespace Spnch.Csharp.Pipe.Generators;

[Generator]
public class PipeGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(ctx =>
            ctx.AddSource("Spnch.Csharp.Pipe.g.cs", """

                                             using System;
                                             using System.Runtime.CompilerServices;
                                             using System.Threading.Tasks;

                                             namespace Spnch.Csharp.Pipe;

                                             public static partial class PipeExtensions
                                             {
                                                 [MethodImpl(MethodImplOptions.AggressiveInlining)]
                                                 public static async ValueTask<TR> _<T, TR>(this ValueTask<T> t, Func<T, TR> f) => f(await t);
                                                 
                                                 [MethodImpl(MethodImplOptions.AggressiveInlining)]
                                                 public static async ValueTask<T> _<T>(this ValueTask<T> t, Action<T> a)
                                                 {
                                                     var val = await t;
                                                     a(val);
                                                     return val;
                                                 }
                                                 
                                                 [MethodImpl(MethodImplOptions.AggressiveInlining)]
                                                 public static async Task<TR> _<T, TR>(this Task<T> t, Func<T, TR> f) => f(await t);
                                                 
                                                 [MethodImpl(MethodImplOptions.AggressiveInlining)]
                                                 public static async Task<T> _<T>(this Task<T> task, Action<T> a)
                                                 {
                                                     var val = await task;
                                                     a(val);
                                                     return val;
                                                 }
                                             }
                                             """));
    }
}
