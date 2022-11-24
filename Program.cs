// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Test>();

[BenchmarkDotNet.Attributes.SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Mono)]
[BenchmarkDotNet.Attributes.SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60)]
[BenchmarkDotNet.Attributes.SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net70)]
public class Test
{
	Random _Random = new Random();

	[BenchmarkDotNet.Attributes.Benchmark]
	public double MethodIf()
	{
		return double.MaxValue % 2;
	}
}
