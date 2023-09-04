using LUP;
using LUP.Logging;

var builder = new ApplicationBuilder();

var app = builder.Build();
app.Run();

SomeObject obj = new();

obj.Logger.Debug("Инициализация");
obj.Logger.Info("Идет загрузка сервера");
obj.Logger.Warn("Что-то пошло не так");
obj.Logger.Error("Ошибка подключения, идет анализ ошибки");
obj.Logger.Fatal("Анализатор ошибок не был подключен в приложение это вызвало фатальную ошибку", new InvalidOperationException("analizer is not defined"));

Console.ReadLine();




class SomeObject : LUPObject
{
    public SomeObject()
    {

    }
}