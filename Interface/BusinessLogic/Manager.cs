using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using static System.Exception;
using Exceptions;
using Interface.DataAccess; 
using Microsoft.EntityFrameworkCore;

namespace Interface.BusinessLogic
{
    public class Manager
    {
        public Client logged { get; set; }
        public List<Client> clients;

        public Manager() 
        {
			this.clients = new List<Client>();
        }

      

        public Material MatchingMaterial(string name)
        {
            foreach(var material in this.logged.getMaterials())
            {
                if(material.name == name) 
                {
                    return material;
                }
            }
            return new LambertianoMaterial();   
        }


        
     

      

        public void addMaterial(Material material)
        {
            logged.AddMaterial(material);
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
                GetMaterials().Remove(material);
            }
        }

        public void addModel(Model model)
        {
            logged.AddModel(model);
        }

        public List<Model> GetModels()
        {
            return logged.getModels();
        }

        public void DeleteModel(Model model)
        {
            if (logged.ModelIsLinked(model))
            {
                throw new InvalidOperationException("El modelo seleccionado está siendo usado por una escena existente");
            }
            else
            {
                GetModels().Remove(model);
            }
        }

        public void addScene(Scene scene)
        {
            logged.AddScene(scene);
        }

        public List<Scene> GetScenes() 
        { 
            return logged.getScenes();
        }

       public Scene GetScenebyName(string name)
        {

            foreach (Scene scene in GetScenes()){
                if (scene.name == name)
                {
					return scene;
				}
            }

            return null;
        }

		public void DeleteScene(Scene scene)
		{
			GetScenes().Remove(scene);

		}

	}





}
