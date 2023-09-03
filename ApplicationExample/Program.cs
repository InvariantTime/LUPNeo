using LUP;

var builder = new ApplicationBuilder();

var app = builder.Build();
app.Run();

SomeObject obj = new();
Console.ReadLine();




class SomeObject : LUPObject
{
    public SomeObject()
    {

    }
}