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

		public int sceneId { get; set; }
		public Scene scene { get; set; }

		public PositionedModel()
        {
            model = new Model();
            position = new Coordinate(0,0,0);
        }

        public PositionedModel(Model model, Coordinate position)
        {
			this.model = model;
			this.position = position;
		}

        public override string ToString()
        {
            return "Model: " + this.model.name + "  " +
                  "Position: " + this.position.ToString();
        }
    }
}
