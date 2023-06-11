using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class PositionedModel
	{
		public int Id { get; set; }
		public Model model { get; set; }
		public Coordinate position { get; set; }

		public override string ToString()
		{
			return "Model: " + this.model.name + "  " +
				  "Position: " + this.position.ToString();
		}

	}
}
