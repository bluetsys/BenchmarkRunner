// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<Test>();

public class Test
{
	Random _Random = new Random();

	[BenchmarkDotNet.Attributes.Benchmark]
	public double MethodIf()
	{
		return double.MaxValue % 2;
	}
}
