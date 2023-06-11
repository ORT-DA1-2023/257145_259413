using Domain;
using Interface.DataAccess;
using Exceptions;
using System.Security.Cryptography;

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
			return _dbContext.scenes.Where(s => s.client.Id == _logged.Id).ToList();
		}

		public Scene GetSceneByName(string name)
		{
			return _dbContext.scenes.Where(s => s.client.Id == _logged.Id).FirstOrDefault(s => s.name == name);
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
			_dbContext.scenes.Add(scene);
			_dbContext.SaveChanges();
		}

		public void Delete(Scene scene)
		{
			_dbContext.Remove(scene);
			_dbContext.SaveChanges();
		}
	}
}
