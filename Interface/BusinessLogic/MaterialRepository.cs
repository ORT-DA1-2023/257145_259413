using Interface.DataAccess;
using Domain;
using System.Drawing;

namespace Interface.BusinessLogic
{
    public class MaterialRepository
    {
        public Client logged { get; set; }
        private ApplicationContext _dbContext;
        private SessionManager sessionManager;



        public MaterialRepository(SessionManager sessionManager, ApplicationContext _dbContext)
        {
            this.sessionManager = sessionManager;
            this._dbContext = _dbContext;
            this.logged = sessionManager.CurrentUser;
        }



        public void CreateMaterial(string selectedMaterial, string name, Color color, double valueMetalic)
        {


            Material newMaterial = Material.createMaterial(selectedMaterial, name, color, valueMetalic);
            addMaterial(newMaterial);
        }










        public Material MatchingMaterial(string name)
        {
            foreach (var material in this.logged.getMaterials())
            {
                if (material.name == name)
                {
                    return material;
                }
            }
            return new LambertianoMaterial();
        }

        public void addMaterial(Material material)
        {

            logged.AddMaterial(material);
            _dbContext.SaveChanges();
        }

        public List<Material> GetMaterials()
        {
            return logged.getMaterials();
        }

        public void DeleteMaterial(Material material)
        {
            if (logged.MaterialIsLinked(material))
            {
                throw new InvalidOperationException("El material seleccionado está siendo usado por un modelo existente");
            }
            else
            {
                List<Material> list = GetMaterials();
                list.Remove(material);
                _dbContext.SaveChanges();
            }
        }














    }
}
