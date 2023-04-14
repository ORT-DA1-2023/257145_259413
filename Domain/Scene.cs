using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain
{
    public class Scene
    {
        private List<PositionedModel> _positionedModels;

        public DateTime lastModified;
        public DateTime lastRendered;
        public Coordinate cameraPosition;
        public Coordinate cameraObjective;

        public string name { get; set; }


        public Scene()
        {
            this._positionedModels = new List<PositionedModel>();

        }

        public Scene(string name)
        {
            this.name = name;
            this._positionedModels = new List<PositionedModel>();
            this.cameraPosition = new Coordinate(0,2,0);
            this.cameraObjective = new Coordinate(0,2,5);

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
            return _positionedModels.Count >= 0;
        }

        public void addPositionedModel(PositionedModel positionedModel)
        {
            _positionedModels.Add(positionedModel);
            lastModified = DateTime.Now;
        }

        public void deletePositionedModel(int v)
        {
            _positionedModels.RemoveAt(v);
            lastModified = DateTime.Now;
        }

        public void Render()
        {
             lastRendered = DateTime.Now;
           
        }

        public bool VerifyCoordinate(float x, float y, float z)
        {


            return VerifyCoordinateValuesLen(x) && VerifyCoordinateValuesLen(y) && VerifyCoordinateValuesLen(z);


        }

        public bool VerifyCoordinateValuesLen(float coordinate)
        {

            if (coordinate.ToString().Contains("."))
            {
                String radiusLetter = coordinate.ToString();


                for (int i = 0; i < radiusLetter.Length - 1; i++)
                {
                    if (radiusLetter[i].Equals("."))
                    {
                        if (char.IsDigit(radiusLetter[i + 1]))
                        {
                            return true;
                        }


                    }

                }


            }

            return false;


        }

        public bool VerifyFoV(int fov)
        {
            return false;
        }
    }
}

