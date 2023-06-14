using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
	abstract class Camera
	{
		public abstract Ray getRay(double u, double v);
	}
}
