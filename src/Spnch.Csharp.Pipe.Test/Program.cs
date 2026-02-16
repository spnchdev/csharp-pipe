using Spnch.Csharp.Pipe;

const string myName = "spinach";

// basic stuff with lambdas:
myName
    ._(s => s.ToUpper())
    ._(s =>
    {
        Console.Write($"{s} ");
        return s;
    })
    ._(s => s.Length)
    ._(n => Console.WriteLine($"is {n} characters long."));
// shall output "SPINACH is 7 characters long."

// stuff with predefined methods + asynchrony
var stringLengthAsync = await ValueTask.FromResult("pipes 4ever")
    ._(GetStringLength)
    ._(Subtract5);

// more stuff!
const byte listCapacity = 10;
var list = new List<int>(listCapacity);
stringLengthAsync
    ._(n =>
    {
        for (var i = 0; i < listCapacity; ++i)
        {
            list.Add(n * (i + 1));
        }

        return list.Select(x => Math.Pow(x, 2));
    })
    ._(l => string.Join(", ", l))
    ._(Console.WriteLine);
// shall output "36, 144, 324, 576, 900, 1296, 1764, 2304, 2916, 3600"

return;

// user defined methods
int Subtract5(int n) => n - 5;
int GetStringLength(string s) => s.Length;
