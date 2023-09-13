namespace LUP.DependencyInjection
{
    public readonly struct ActivatedContext<T>
    {
        public T Instance { get; init; }

        public IServiceScope Scope { get; init; }
    }

    public delegate void ActivatedMiddleware<T>(ActivatedContext<T> context);

    public delegate void ActivatedMiddleware(object instance, IServiceScope scope);
}
