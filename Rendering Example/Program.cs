using LUP;
using LUP.Client;
using LUP.Client.Input;
using LUP.DependencyInjection;
using LUP.Graphics;
using LUP.Graphics.OpenGL;
using LUP.Math;
using LUP.Rendering;
using LUP.Rendering.Components;
using LUP.Rendering.Export;
using LUP.Rendering.Meshing;
using LUP.Rendering.ShaderLanguage;
using LUP.SceneGraph;
using LUP.SceneGraph.Components;
using Rendering_Example;

var builder = new ApplicationBuilder();

builder.Services.AddRendering();
builder.Services.AddSceneSystem();
builder.Services.AddOpenGL();
builder.Services.AddDesktopWindow(x =>
{
    x.Title = "Window";
    x.Visible = true;
});

var app = builder.Build();
app.Services.GetService<IWindowProcessor>();

var sceneProcessor = app.Services.GetService<ISceneProcessor>();

if (sceneProcessor == null)
    throw new InvalidOperationException();

sceneProcessor.LoadScene(null);
var scene = sceneProcessor.Provider!.Scene;
var obj = scene.Instantiate();

var device = app.Services.GetService<IGraphicsDevice>()!;
var commands = device.GetCommandList();

var input = app.Services.GetService<IInputHandler>()!;

var shader = Shaders.CreateShader(device);
shader.Bind();
shader.Uniforms.Set("color_in", new Vec3<float>(0.843f, 0.490f, 0.192f));
shader.Unbind();

var component = new ModelComponent(shader);
obj.AddComponent(component);



GraphicsState state = new()
{
    Depth = GraphicsDepth.Identity
};
commands.SetState(state);


var m = ModelImporter.Import("cat.obj");
var meshes = m.Meshes.Select(x => MeshBuilder.Build(x, device));

foreach (var mesh in meshes)
    component.AddMesh(mesh);

var cameraNode = scene.Instantiate();
var camera = new CameraComponent();
cameraNode.AddComponent(camera);
cameraNode.AddComponent(new InputComponent(input));

//app.AddStage<IInputProcessor>();
//app.AddStage<ISceneProcessor>();
//app.AddStage<IWindowProcessor>();


var compiler = app.Services.GetService<ShaderCompiler>()!;
compiler.Test();

//app.Run();

class InputComponent : Component, IRenderProvider
{
    private const float speed = 0.03f;
    private const float rotationSpeed = 0.08f;

    private Vector2 prev;
    private float angleX = 0;
    private float angleY = 0;

    private readonly IInputHandler input;

    public bool Enable => true;

    public InputComponent(IInputHandler input)
    {
        this.input = input;

        input.Mouse.MouseMoved += OnMouseMove;
        prev = input.Mouse.GetPosition();

        input.Mouse.Cursor.State = CursorStates.Disable;
    }


    public void Visit(IRenderVisitor visitor)
    {
        if (Transform == null)
            return;

        var keyboard = input.Keyboard;

        Vector3 direction = Vector3.Forward;
        Vector3 up = Quaternion.RotateVector(Vector3.Up, Transform.Rotation);
        Vector3 left;

        direction = Quaternion.RotateVector(direction, Transform.Rotation).Normalize();
        left = Vector3.Cross(direction, up).Normalize();

        if (keyboard.IsKeyPressed(KeyboardKeys.Up) == true)
            Transform.Position += direction * speed;

        if (keyboard.IsKeyPressed(KeyboardKeys.Down) == true)
            Transform.Position -= direction * speed;

        if (keyboard.IsKeyPressed(KeyboardKeys.Left) == true)
            Transform.Position += left * speed;

        if (keyboard.IsKeyPressed(KeyboardKeys.Right) == true)
            Transform.Position -= left * speed;
    }


    private void OnMouseMove(object? sender, CursorArgs args)
    {
        Vector2 delta = (args.Position - prev) * rotationSpeed;

        angleX += delta.X;
        angleY += delta.Y;

        Transform.Rotation = new Quaternion(Vector3.Up, angleX) * new Quaternion(Vector3.Right, angleY);
        prev = args.Position;
    }
}