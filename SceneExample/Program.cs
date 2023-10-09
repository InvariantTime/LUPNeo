using LUP.DependencyInjection;
using LUP.SceneGraph;
using LUP.Client;
using LUP;
using LUP.SceneGraph.Components;
using LUP.Graphics.OpenGL;

var builder = new ApplicationBuilder();
builder.Services.AddSceneSystem();
builder.Services.AddOpenGL();

builder.Services.AddDesktopWindow(x => {

    x.Title = "Hello window!";
    x.Visible = true;
    x.Resizable = true;
});

 var app = builder.Build();
app.AddStage<ISceneProcessor>();
app.AddStage<IWindowProcessor>();

var sceneP = app.Services.GetService<ISceneProcessor>()!;
sceneP.LoadScene(null);
var scene = sceneP.Provider!.Scene;
var obj = scene.GetRootObjects().Instantiate(null);

var component = new SuperComponent();
obj.AddComponent(component);
component.Destroy();


app.Run();


class SuperComponent : ComponentBase
{
    protected override void OnInitialized()
    {
        Console.WriteLine("INIT");
    }


    protected override void OnUnitialized()
    {
        Console.WriteLine("UNINIT");
    }
}