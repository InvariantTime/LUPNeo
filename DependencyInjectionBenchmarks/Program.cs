using BenchmarkDotNet.Attributes;
using LUP.DependencyInjection;

BenchmarkDotNet.Running.BenchmarkRunner.Run<DiBenchmark>();

public class DiBenchmark
{
    private readonly IServicesProvider services;

    public DiBenchmark()
    {
        var builder = new EmptyServiceCollection();
        services = builder.AddSingleton<ISome1, Some1>()
            .AddSingleton<ISome2, Some2>()
            .BuildProvider();

        services.GetService(typeof(Some1));
    }


    [Benchmark(Baseline = true)]
    public void Forward()
    {
        ISome2 some2 = new Some2();
        ISome1 some1 = new Some1(some2);
    }


    [Benchmark]
    public void DiBased()
    {
        var some1 = services.GetService(typeof(ISome1));
    }
}


interface ISome1
{

}

class Some1 : ISome1
{
    private readonly ISome2 some2;

    public Some1(ISome2 some2)
    {
        this.some2 = some2;
    }
}


interface ISome2
{

}


class Some2 : ISome2
{

}