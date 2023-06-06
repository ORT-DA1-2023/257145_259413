using Domain;
using Interface.DataAccess;
using System.Security.Cryptography;

namespace Interface.BusinessLogic
{
	public class SceneRepository
	{

		private Client _logged;
		private ApplicationContext _dbContext;
		private SessionManager _sessionManager;



		public SceneRepository(SessionManager sessionManager, ApplicationContext applicationContext)
		{
			_logged = sessionManager.CurrentUser;
			_dbContext = applicationContext;
			_sessionManager = sessionManager;
		}

		public List<Scene> GetScenes()
		{
			return _dbContext.scenes.Where(s => s.client.Id == _logged.Id).ToList();
		}

		public Scene GetSceneByName(string name)
		{
			List<Scene> scenes = GetScenes();
		    return _dbContext.scenes.Where(s => s.client.Id == _logged.Id).FirstOrDefault(s => s.name == name);
		}

		public void Add(Scene scene) 
		{
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
