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

		public void addScene(Scene scene)
		{
			logged.AddScene(scene);
		}

		public Scene GetScenebyName(string name)
		{

			/*foreach (Scene scene in GetScenes()){
                if (scene.name == name)
                {
					return scene;
				}
            }*/

			return null;
		}

		public void DeleteScene(Scene scene)
		{
			//GetScenes().Remove(scene);

		}

	}





}
