using LUP;
using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;
using LUP.Graphics.OpenGL;
using LUP.Logging;

var builder = new ApplicationBuilder();
builder.Services.RegisterType<ConsoleLoggerService>().As<ILoggerService>();
builder.Services.AddOpenGL();

var app = builder.Build();
app.Run();