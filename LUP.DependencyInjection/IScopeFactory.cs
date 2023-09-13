namespace LUP.DependencyInjection
{
    public interface IScopeFactory
    {
        IServiceScope CreateScope();
    }
}
