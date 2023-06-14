using Domain;
using Exceptions;
using Interface.DataAccess;
using Interface.Pages.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Interface.BusinessLogic
{
    public class ModelRepository
    {

        private ApplicationContext _dbContext;
        private SessionManager _sessionManager;
        private ClientRepository _clientRepository;
        private Client _logged;

        public ModelRepository(SessionManager sessionManager, ApplicationContext _dbContext)
        {
            this._sessionManager = sessionManager;
            this._dbContext = _dbContext;
            _clientRepository = new ClientRepository(_dbContext, _sessionManager);
            this._logged = _clientRepository.Find(sessionManager.CurrentUser.Id);
        }

        public void CreateModel(string name, Figure figure, Material material)
        {
            Model model = new Model(name, figure, material);
            model.client = _logged;
            AddModel(model);
        }


        public List<Model> GetModels()
        {
            return _dbContext.Models.Where(m => m.client.Id == _logged.Id).Include(m => m.figure).Include(m => m.material).ToList();
        }

        public void Delete(Model model)
        {
            if (ModelIsLinked(model))
            {
                throw new LinkedModelException();
            }
            _dbContext.Remove(model);
            _dbContext.SaveChanges();
        }

        public void AddModel(Model model1)
        {
            List<Model> models = GetModels();
            foreach (Model model in models)
            {

                if (model.name == model1.name)
                {
                    return;
                }
            }
            _dbContext.Models.Add(model1);
            _dbContext.SaveChanges();
        }

        public Model Find(string name)
        {
            return _dbContext.Models.FirstOrDefault(m => m.name == name);
        }

        public bool ModelIsLinked(Model model)
        {
            List<Scene> scenes = _dbContext.Scenes.Where(m => m.client.Id == _logged.Id).ToList();
            foreach (Scene scene in scenes)
            {
                if (scene.ModelIsPositioned(model))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
