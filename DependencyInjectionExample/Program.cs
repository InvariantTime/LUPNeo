using LUP.DependencyInjection;
using System.Collections;

var builder = new ServiceCollection();

builder.AddSingleton<ILogger, Logger>();
builder.AddSingleton<ILogger, Logger>();
builder.AddScoped<Component, Component>();

var services = builder.BuildProvider();

var logger = services.GetService(typeof(ILogger));

Console.WriteLine();

interface ILogger
{

}


class Logger : ILogger
{

}


class Component
{
    public readonly ILogger logger;

    public Component(ILogger logger)
    {
        this.logger = logger;
    }
}


class ServiceCollection : IServiceCollection
{
    private readonly HashSet<ServiceDescriptor> descriptors = new();

    public void Add(ServiceDescriptor descriptor)
    {
        descriptors.Add(descriptor);
    }


    public IEnumerator<ServiceDescriptor> GetEnumerator()
    {
        return descriptors.GetEnumerator();
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}