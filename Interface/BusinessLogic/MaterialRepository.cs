using Interface.DataAccess;
using Domain;
using System.Drawing;

namespace Interface.BusinessLogic
{
	public class MaterialRepository
	{
		public Client logged { get; set; }
		private ApplicationContext _dbContext;
		private ClientRepository clientRepository;


		public MaterialRepository(SessionManager sessionManager, ApplicationContext _dbContext)
		{
			this._dbContext = _dbContext;
			this.clientRepository = new ClientRepository(_dbContext, sessionManager);
			this.logged = clientRepository.Find(sessionManager.CurrentUser.Id);
		}



		public void CreateMaterial(string selectedMaterial, string name, Color color, double valueMetalic)
		{


			Material newMaterial = Material.createMaterial(selectedMaterial, name, color, valueMetalic);
			newMaterial.client = logged;
			addMaterial(newMaterial);
		}


		public Material MatchingMaterial(string name)
		{
			return _dbContext.materials.FirstOrDefault(m => m.name == name);
		}

		public void addMaterial(Material material)
		{
			_dbContext.materials.Add(material);
			_dbContext.SaveChanges();
		}

		public List<Material> GetMaterials()
		{
			return _dbContext.materials.Where(m => m.client.Id == logged.Id).ToList();
		}

		public void DeleteMaterial(Material material)
		{
			if (MaterialIsLinked(material))
			{
				throw new InvalidOperationException("El material seleccionado está siendo usado por un modelo existente");
			}
			else
			{
				_dbContext.materials.Remove(MatchingMaterial(material.name));
				_dbContext.SaveChanges();
			}
		}

		public bool MaterialIsLinked(Material material)
		{
			List<Model> models = _dbContext.models.Where(m => m.client.Id == logged.Id).ToList();
			foreach (Model model in models)
			{
				if (model.material == material)
				{
					return true;
				}
			}
			return false;
		}










	}
}
