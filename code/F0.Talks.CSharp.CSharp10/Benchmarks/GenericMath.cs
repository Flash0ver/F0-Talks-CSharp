namespace F0.Talks.CSharp.CSharp10.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser(false)]
public class GenericMath
{
    private IEnumerable<int> sequence = null!;

    [Params(10, 100, 1_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        int[] array = new int[Count];
        Array.Fill(array, 0x_F0);
        sequence = array;
    }

    [Benchmark(Description = $"{nameof(LinqSum)} .NET 6.0")]
    public int LinqSum()
    {
        return sequence.Sum();
    }
}
