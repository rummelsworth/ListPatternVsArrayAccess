using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

public class ABCDRetrieval
{
    private static double[] ABCD() => new double[] { 1, 2, 3, 4 };

    [Benchmark]
    public double ListPattern()
    {
        var abcd = ABCD();
        if (abcd is [var a, var b, var c, var d])
        {
            return a + b + c + d;
        }
        else
        {
            throw new Exception("Can't happen.");
        }
    }

    [Benchmark]
    public double ArrayAccess()
    {
        var abcd = ABCD();
        var (a, b, c, d) = (abcd[0], abcd[1], abcd[2], abcd[3]);
        return a + b + c + d;
    }

    [Benchmark]
    public double ArrayAccessHighToLow()
    {
        var abcd = ABCD();
        var (d, c, b, a) = (abcd[3], abcd[2], abcd[1], abcd[0]);
        return a + b + c + d;
    }
}