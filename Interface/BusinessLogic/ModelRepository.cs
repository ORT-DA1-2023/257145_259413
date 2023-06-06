using Domain;
using Interface.DataAccess;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Interface.BusinessLogic
{
	public class ModelRepository
	{

		private ApplicationContext _dbContext;
		private SessionManager _sessionManager;
		private Client _logged;

		public ModelRepository(SessionManager sessionManager, ApplicationContext _dbContext)
		{
			this._sessionManager = sessionManager;
			this._dbContext = _dbContext;
			this._logged = sessionManager.CurrentUser;
		}

		public List<Model> GetModels()
		{
			return _dbContext.models.Where(m => m.client.Id == _logged.Id).ToList();
		}

		public void Delete(Model model)
		{
			_dbContext.Remove(model);
			_dbContext.SaveChanges();
		}
	}
}
