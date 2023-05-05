using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLogic
{
    public class Manager
    {
        public Client logged { get; set; }
        public List<Client> clients;

        public Manager() 
        {
            this.clients = new List<Client>();
        }

        public Figure MatchingFigure(string name)
        {
            foreach(var figure in this.logged.getFigures())
            {
                if(figure.name == name)
                {
                    return figure;
                }
            }
            return new Figure();
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
            return new Material();
        }


        public void add(Client client1)
        {
            foreach (Client client in clients)
            {
                if (client.name == client1.name)
                {
                    return;
                }
            }
            this.clients.Add(client1);
        }

        public Client logIn(string name, string password)
        {
            foreach (Client client in clients)
            {
                if (client.MatchingUsername(name) && client.MatchingPassword(password))
                {
                    this.logged = client;
                    return client;
                }
            }
            return null;
        }

        public bool Verify()
        {
            if(clients.Count == 0)
            {
                return false;
            }
            if(clients.Count == 1)
            {
                return true;
            }
            for(int i= 0; i < clients.Count; i++)
            {
                for(int j = i+1; j < clients.Count; j++)
                {
                    if (clients[i].name == clients[j].name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Client SignUp(string name, string password)
        {
            Client client= new Client();
            if (!client.VerifyName(name) || !client.VerifyPassword(password) || Exists(name))
            {
                return client;
            }
            client.name = name;
            client.password = password;
            return client;
        }

        public bool Exists(string name)
        {
            foreach(Client client in clients)
            {
                if (client.MatchingUsername(name))
                {
                    return true;
                }
            }
            return false;
        }

        public void addFigure(Figure figure)
        {
            logged.AddFigure(figure);
        }

        public List<Figure> GetFigures()
        {
            return logged.getFigures();
        }

        public void DeleteFigure(Figure figure)
        {
            if (logged.FigureIsLinked(figure))
            {
                throw new InvalidOperationException("La figura seleccionada está siendo usada por un modelo existente");
            }
            else
            {
                GetFigures().Remove(figure);
            }
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

	
	}
}
