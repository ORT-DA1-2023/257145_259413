using Domain;

namespace Engine.test
{
	[TestClass]
	public class RenderTest
	{
		[TestMethod]
		public void ReturnsTrueIfPersonalizedRenderIsCreatedCorrectly()
		{
			Scene scene = new Scene();
			int resolutionX = 10;
			int resolutionY = 10;
			int samplesPerPixel = 5;
			int maxDepth = 5;
			Render render = new Render(scene, resolutionX, resolutionY, samplesPerPixel, maxDepth);
			Assert.AreEqual(render.scene, scene);
			Assert.AreEqual(render._resolutionX, resolutionX);
			Assert.AreEqual(render._resolutionY, resolutionY);
			Assert.AreEqual(render.samplesPerPixel, samplesPerPixel);
			Assert.AreEqual(render.maxDepth, maxDepth);
		}

		[TestMethod]
		public void ReturnsTrueIfDefaultRenderIsCreatedCorrectly()
		{
			Scene scene = new Scene();
			int resolutionX = 300;
			int resolutionY = 200;
			int samplesPerPixel = 50;
			int maxDepth = 20;
			Render render = new Render(scene);
			Assert.AreEqual(render.scene, scene);
			Assert.AreEqual(render._resolutionX, resolutionX);
			Assert.AreEqual(render._resolutionY, resolutionY);
			Assert.AreEqual(render.samplesPerPixel, samplesPerPixel);
			Assert.AreEqual(render.maxDepth, maxDepth);
		}

		[TestMethod]
		public void ReturnsTrueIfSceneWithNoModelIsRendered()
		{
			Scene scene = new Scene("_noModel");
			Render render = new Render(scene, 1, 1, 1, 1);
			render.RenderScene("test");
			string path = Path.Combine(Directory.GetCurrentDirectory(), @"Images", @"test", scene.name + ".ppm");
			bool result = File.Exists(path);
			Assert.IsTrue(result);
		}
	}
}