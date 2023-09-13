using LUP;
using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;
using LUP.Logging;

var builder = new ApplicationBuilder();

builder.Services.RegisterType<FatalErrorThrower>().As<ILoggerService>().AsSingleton();

var app = builder.Build();
app.Run();

Console.ReadLine();



class FatalErrorThrower : ILoggerService
{
    public void Message(LogMessage message)
    {
        Console.WriteLine("ОШИБКА");
    }
}