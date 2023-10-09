using LUP;
using LUP.DependencyInjection;
using LUP.SceneGraph;

namespace SceneTests
{
    [TestClass]
    public class SceneObjectTests
    {
        [TestMethod]
        public void Children_Root_Count_Test1()
        {
            var scene = CreateScene();
            scene.GetRootObjects().Instantiate();

            int count = 1;

            Assert.AreEqual(scene.GetRootObjects().Children.Count, count);
        }


        [TestMethod]
        public void Children_Root_Count_Test2()
        {
            var scene = CreateScene();
            scene.GetRootObjects().Instantiate();
            scene.GetRootObjects().Instantiate();

            int count = 2;

            Assert.AreEqual(scene.GetRootObjects().Children.Count, count);
        }


        [TestMethod]
        public void Children_Root_Count_Test3()
        {
            var scene = CreateScene();
            var o1 = scene.GetRootObjects().Instantiate();
            var o2 = scene.GetRootObjects().Instantiate();

            o1.Destroy();
            o2.Destroy();

            scene.GetRootObjects().Instantiate();
            scene.GetRootObjects().Instantiate();
            scene.GetRootObjects().Instantiate();

            int count = 3;

            Assert.AreEqual(scene.GetRootObjects().Children.Count, count);
        }


        private static IScene CreateScene()
        {
            var builder = new ApplicationBuilder();
            builder.Services.AddSceneSystem();

            var app = builder.Build();

            var stage = app.Services.GetService<ISceneProcessor>();
            stage!.LoadScene(null);
            
            return stage.Provider!.Scene;
        }
    }
}