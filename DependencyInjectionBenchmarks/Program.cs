using BenchmarkDotNet.Attributes;
using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;

BenchmarkDotNet.Running.BenchmarkRunner.Run<DiBenchmark>();

public class DiBenchmark
{
    private readonly IServiceProvider services;

    public DiBenchmark()
    {
        var builder = new ServiceCollection();
        builder.RegisterType<Some1>().As<ISome1>().AsSingleton();
        builder.RegisterType<Some2>().As<ISome2>().AsSingleton();
        services = builder.BuildProvider();
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