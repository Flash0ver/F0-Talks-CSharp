namespace F0.Talks.CSharp.CSharp11.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser(false)]
public class MethodGroupConversions
{
    [Benchmark(Description = $"{nameof(LambdaExpression)} C# 11")]
    public int LambdaExpression()
    {
        return Invoker(static (int parameter) => Method(parameter));
    }

    // Cache delegates for static method group
    [Benchmark(Description = $"{nameof(MethodGroupConversion)} C# 11")]
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
