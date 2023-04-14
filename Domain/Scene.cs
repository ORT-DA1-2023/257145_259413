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

        public DateTime _lastModified;
        public DateTime _lastRendered;

        public string name { get; set; }


        public Scene()
        {
            this._positionedModels = new List<PositionedModel>();
        }

        public Scene(string name)
        {
            this.name = name;
            this._positionedModels = new List<PositionedModel>();

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
            _lastModified = DateTime.Now;
        }

        public void deletePositionedModel(int v)
        {
            _positionedModels.RemoveAt(v);
            _lastModified = DateTime.Now;
        }

        public void Render()
        {
             _lastRendered = DateTime.Now;
           
        }

        public bool VerifyCoordinate(float x, float y, float z)
        {
           return false;
        }
    }
}

