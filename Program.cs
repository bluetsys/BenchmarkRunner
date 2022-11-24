// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using System.Linq;
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");
var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Test>();

[BenchmarkDotNet.Attributes.SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Mono)]
[BenchmarkDotNet.Attributes.SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60)]
[BenchmarkDotNet.Attributes.SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net70)]
public class Test
{
    private int[] data;

    [Params(100, 1000)]
    public int N;

    [GlobalSetup]
    public void Setup()
    {
        var _Buffer = new byte[N];
        new Random(42).NextBytes(_Buffer);

        data = Array.ConvertAll(_Buffer, c => (int)c);
    }

 //   [BenchmarkDotNet.Attributes.Benchmark]
	//public double MethodIf()
	//{
	//	return double.MaxValue % 2;
	//}

    [BenchmarkDotNet.Attributes.Benchmark]
    public double Linq()
    {
        return data.Sum();
    }


    [BenchmarkDotNet.Attributes.Benchmark]
    public double LinqAsParallel()
    {
        return data.AsParallel().Sum();
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public double For()
    {
        double d = 0;
        for (int i = 0; i < data.Length; i++)
        {
            d += data[i];
        }

        return d;
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public double ForEach()
    {
        double d = 0;
        foreach (var item in data)
        {
            d += item;
        }

        return d;
    }

    [BenchmarkDotNet.Attributes.Benchmark]
    public double ForEachAsParallel()
    {
        double d = 0;
        foreach (var item in data.AsParallel())
        {
            d += item;
        }

        return d;
    }
}
