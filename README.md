# Spnch.Csharp.Pipe
### Semi-long-needed, (almost) zero-alloc pipes, now in C#.
Asemic utility library that introduces a forward pipe 'operator' (if you can call it that) to C#. It eliminates the temporary variable mess and nested method calls by turning them into a linear, readable flow. Works similarly to the F#'s `|>` operator or the basic Bash pipe (`|`)-you get the idea.

## Why?
Syntactic sugar.
On a more serious note, standard C# async composition is often a mess of `await` keywords and intermediate variables. This library 'stitches' the state machines together via source generation, so you could pipe directly into and out of asynchronous tasks without the annoying syntax salt.

## Should I use this?
Probably not. But if you:
* Miss F#'s `|>` operator
* Think LINQ is too verbose
* Wanna confuse your coworkers
* Are willing to explain `._()` with 1e308 type hints inside your IDE in a code review

... then welcome aboard. :^

## Usage
```csharp
using Spnch.Csharp.Pipe;

// Sync flow
var result = "spinach"
    ._(s => s.ToUpper())
    ._(s => s.Length);

// Async flow (source generated)
var asyncResult = await ValueTask.FromResult("pipes 4ever")
    ._(GetStringLength)
    ._(n => n * 2);

// Helper methods (for the example above)
int GetStringLength(string s) => s.Length;
```

## Key Features
* **Asemic Design:** Uses simple syntax (`._()`) to stay visually minimal. Under the hood it's just a method named '_';
* **Async-Native:** Automatic handling of `Task`/`ValueTask` via incremental source generation;
* **Performance:** Extensive use of `[MethodImpl(MethodImplOptions.AggressiveInlining)]` to ensure the JIT optimizes the pipe away.

## Contributing
PRs welcome. Issues also welcome. "???????"s and "why--"s are expected and accepted.

## Roadmap
I'm not yet sure whether I'll keep working on this library, but here are my nearest ideas:
* **0.0.2-alpha:** Null-short-circuiting support via `?._()`;
* **Future:** Unsafe pipes leveraging function pointers (`delegate*`) for true zero-allocation execution. Expected syntax is `.__()` (but it's not yet decided upon). Not gonna lie, `?.__()` looks diabolical.

## License
MIT. Check LICENSE.

<sub>please don't use this in prod</sub>
