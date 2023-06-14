using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Exceptions;
using static System.Formats.Asn1.AsnWriter;

namespace Domain
{
	public class Scene : IComparable<Scene>
	{
		public int Id { get; set; }

		public string name { get; set; }

		public virtual ICollection<PositionedModel> positionedModels { get; set; }

		public DateTime lastModified { get; set; }
		public DateTime lastRendered { get; set; }
		public DateTime created { get; set; }

		public Coordinate lookFrom { get; set; }

		public Coordinate lookAt { get; set; }

		public int fieldOfView { get; set; }

		public double aperture { get; set; }

		public Client client { get; set; }

		public Scene()
		{
			this.positionedModels = new List<PositionedModel>();
			this.created = DateTime.Now;
			this.lastModified = this.created;
		}

		public Scene(string name) : this()
		{
			this.name = name;
			this.fieldOfView = 30;
			this.aperture = 0;
			this.lookFrom = new Coordinate(0, 0, 0);
			this.lookAt = new Coordinate(0, 0, 0);
		}

		public ICollection<PositionedModel> GetPositionedModels()
		{
			return this.positionedModels;
		}

		public bool MatchingName(string name)
		{


			if (name.Length != this.name.Length)
			{
				return false;
			}
			for (int i = 0; i < name.Length; i++)
			{
				if (name[i] != this.name[i])
				{
					return false;
				}
			}
			return true;
		}

		public bool VerifyName(string name)
		{


			if (name.Length == 0 || !Regex.IsMatch(name, @"^[^\s].*[^\s]$"))
			{
				return false;
			}

			return true;




		}

		public bool VerifyDate(DateTime date)
		{
			DateTime dateNow = DateTime.Now;

			if (DateTime.Compare(dateNow, date) > 0)
			{

				return true;
			}

			return false;
		}

		public bool VerifyPositionedModels()
		{
			return positionedModels.Count >= 0;
		}

		public void addPositionedModel(PositionedModel positionedModel)
		{
			positionedModels.Add(positionedModel);
			lastModified = DateTime.Now;
		}

		public bool VerifyCoordinate(float x, float y, float z)
		{


			return VerifyCoordinateValuesLens(x) && VerifyCoordinateValuesLens(y) && VerifyCoordinateValuesLens(z);


		}

		public bool ModelIsPositioned(Model model)
		{
			foreach (PositionedModel positionedModel in positionedModels)
			{
				if (positionedModel.model == model)
				{
					return true;
				}
			}
			return false;
		}

		public bool VerifyCoordinateValuesLens(Object coordinate)
		{
			return coordinate.GetType() == typeof(float);
		}

		public bool VerifyFoV(int fov)
		{
			return (fov >= 1 && fov <= 160) ? true : throw new FovOutOfBoundException();
		}

		public int CompareTo(Scene scene)
		{
			if (scene.lastModified < this.lastModified)
			{
				return -1;
			}
			else if (scene.lastModified > this.lastModified)
			{

				return 1;
			}
			else
			{
				return 0;
			}


		}

		public bool VerifyAperture(Object aperture)
		{
			if (!(aperture is double) || (double)aperture <= 0 || (double)aperture > 3)
			{
				throw new InvalidDataException("La apertura debe ser un número entre 0 y 3");
			}
			return true;
		}
	}
}