using LUP;
using LUP.Client;
using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;
using LUP.Graphics.OpenGL;
using OpenGLExample;

var builder = new ApplicationBuilder();

builder.Services.AddDesktopWindow(x =>
{
    x.Resizable = false;
    x.Title = "My super window with opengl graphics";
});
builder.Services.AddOpenGL();
builder.Services.RegisterType<OpenGLDrawer>().AsSelf()
    .As<IApplicationStage>().AsSingleton();

var app = builder.Build();

app.Services.GetService<IWindowProcessor>();

app.AddStage<OpenGLDrawer>();
app.AddStage<IWindowProcessor>();
app.Run();