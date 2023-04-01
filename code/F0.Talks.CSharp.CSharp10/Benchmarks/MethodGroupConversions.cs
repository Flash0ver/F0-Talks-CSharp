namespace F0.Talks.CSharp.CSharp10.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser(false)]
public class MethodGroupConversions
{
    [Benchmark(Description = $"{nameof(LambdaExpression)} C# 10")]
    public int LambdaExpression()
    {
        return Invoker(static (int parameter) => Method(parameter));
    }

    // No cache delegates for static method group
    [Benchmark(Description = $"{nameof(MethodGroupConversion)} C# 10")]
    public int MethodGroupConversion()
    {
        return Invoker(Method);
    }

    private static int Method(int value) => value;

    private static int Invoker(Func<int, int> @delegate)
    {
        int value = 0x_F0;
        return @delegate.Invoke(value);
    }
}
