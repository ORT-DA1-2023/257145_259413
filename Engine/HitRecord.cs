using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
	public class MetalMaterial : Material
	{

	}

	public class HitRecord
	{
		private double t;
		private Vector intersection;
		private Vector normal;
		private Vector attenuation;
		private string material;
		private double roughness;

		public HitRecord(double t, Vector intersection, Vector normal, Vector attenuation, Material material)
		{
			this.t = t;
			this.intersection = intersection;
			this.normal = normal;
			this.attenuation = attenuation;
			this.roughness = 0;
			this.material = material.type;
			if (material is MetalMaterial)
			{
				this.roughness = material.blurred;
			}
		}

		public double T
		{
			get { return t; }
			set { t = value; }
		}

		public Vector Intersection
		{
			get { return intersection; }
			set { intersection = value; }
		}

		public Vector Normal
		{
			get { return normal; }
			set { normal = value; }
		}

		public Vector Attenuation
		{
			get { return attenuation; }
			set { attenuation = value; }
		}

		public string Material
		{
			get { return material; }
			set { material = value; }
		}

		public double Roughness
		{
			get { return roughness; }
			set { roughness = value; }
		}
	}
}