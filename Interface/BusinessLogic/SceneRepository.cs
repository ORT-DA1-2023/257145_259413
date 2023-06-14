using Domain;
using Interface.DataAccess;
using Exceptions;
using Engine;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Interface.BusinessLogic
{
	public class SceneRepository
	{

		private Client _logged;
		private ApplicationContext _dbContext;
		private ClientRepository clientRepository;



		public SceneRepository(SessionManager sessionManager, ApplicationContext applicationContext)
		{
			clientRepository = new ClientRepository(applicationContext, sessionManager);
			_dbContext = applicationContext;
			_logged = clientRepository.Find(sessionManager.CurrentUser.Id);
		}

		public List<Scene> GetScenes()
		{
			return _dbContext.Scenes.Where(s => s.client.Id == _logged.Id).ToList();
		}

		public List<PositionedModel> GetPositionedModels(Scene scene)
		{
			return _dbContext.PositionedModels.Where(pm => pm.scene.Id == scene.Id).ToList();
		}

		public Scene GetSceneByName(string name)
		{
			return _dbContext.Scenes.Where(s => s.client.Id == _logged.Id).FirstOrDefault(s => s.name == name);
		}

		public void Create(string name)
		{
			Scene scene = new Scene(name);
			if (scene.VerifyName(name))
			{
				scene.client = _logged;
				Add(scene);
			}
			else
			{
				throw new SceneNameException();
			}
		}

		public void Add(Scene scene)
		{
			foreach (Scene auxScene in GetScenes())
			{
				if (auxScene.MatchingName(scene.name))
				{
					return;
				}
			}
			_dbContext.Scenes.Add(scene);
			_dbContext.SaveChanges();
		}

		public Image<Rgba32> Render(Scene scene, int fov, bool isDifuminated, Coordinate lookFrom, Coordinate lookAt, double aperture)

		{

			Render render;
			scene.VerifyFoV(fov);
			scene.lookAt = lookAt;
			scene.lookFrom = lookFrom;
			scene.fieldOfView = fov;
			scene.aperture = aperture;
			if (isDifuminated)
			{
				scene.VerifyAperture(aperture);
				render = new Render(scene, lookFrom, lookAt, fov, aperture);
			}
			else
			{
				render = new Render(scene, lookFrom, lookAt, fov);
			}
			scene.lastRendered = DateTime.Now;
			render.RenderScene(_logged.name);


			_dbContext.SaveChanges();
			return render.GetImage();
		
		}

		public void Delete(Scene scene)
		{
			_dbContext.Remove(scene);
			_dbContext.SaveChanges();
		}
	}
}
