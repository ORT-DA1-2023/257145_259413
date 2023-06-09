using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain
{
    public class Model
    {
        public int Id { get; set; }
        public string name { get;  set; }
        public Figure figure { get; set; }
        public Material material { get; set; }

        public Client client { get; set; }
        

	public Model()
        {

        }

        public Model(string name)
        {
            this.name = name;
        }

        public Model(string name, Figure figure, Material material)
        {
            this.name = name;
            this.figure = figure;
            this.material = material;
        }

        public bool VerifyName(string name)
        {
            if (name.Length == 0 || !Regex.IsMatch(name, @"^[^\s].*[^\s]$"))
            {
                throw new InvalidDataException("El nombre es incorrecto");
            }

            return true;
        }
    }
}
