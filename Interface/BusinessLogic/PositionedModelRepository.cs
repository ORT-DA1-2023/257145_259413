using Domain;
using Interface.DataAccess;

namespace Interface.BusinessLogic
{
	public class PositionedModelRepository
	{
		private ApplicationContext _dbContext;
		private Client _logged;

		public PositionedModelRepository(SessionManager sessionManager, ApplicationContext applicationContext)
		{
			ClientRepository clientRepository = new ClientRepository(applicationContext, sessionManager);
			_dbContext = applicationContext;
			_logged = clientRepository.Find(sessionManager.CurrentUser.Id);
		}

		public void Create(Scene scene, Model model, Coordinate position)
		{
			PositionedModel positionedModel = new PositionedModel();
			positionedModel.model = model;
			positionedModel.position = position;
			positionedModel.scene = scene;
			scene.lastModified = DateTime.Now;
			Add(positionedModel);
		}

		public void Add(PositionedModel positionedModel)
		{
			_dbContext.PositionedModels.Add(positionedModel);
			_dbContext.SaveChanges();
		}

		public void Delete(PositionedModel positionedModel)
		{
			PositionedModel toRemove = Find(positionedModel.Id);
			_dbContext.PositionedModels.Remove(toRemove);
			_dbContext.SaveChanges();
		}

		public PositionedModel Find(int id)
		{
			return _dbContext.PositionedModels.Find(id);
		}
	}
}
