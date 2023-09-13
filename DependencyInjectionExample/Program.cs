using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;

var builder = new ServiceCollection();

builder.RegisterType<SomeClass>().AsSelf().AsScoped();

var services = builder.BuildProvider();
var scope = services.CreateScope();


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