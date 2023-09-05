using LUP.DependencyInjection;
using System.Collections;

var builder = new EmptyServiceCollection();

builder.AddScoped<SomeClass, SomeClass>()
    .AddScoped(typeof(SomeGeneric<>), typeof(SomeGeneric<>));

var services = builder.BuildProvider();
var scope = services.CreateScope();

var generic = scope.GetService<SomeGeneric<int>>();
var some = scope.GetService<SomeClass>();

Console.WriteLine();


class SomeGeneric<T>
{

}


class SomeClass
{
    public SomeGeneric<int> Generic { get; }

    public SomeClass(SomeGeneric<int> generic)
    {
        Generic = generic;
    }
}