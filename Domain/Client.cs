using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Exceptions;

namespace Domain
{
    public class Client
    {
        public int Id { get; set; }
        public string name { get; set; }

        public string password { get; set; }
        private List<Figure> figures;
        private List<Material> materials;
        private List<Model> models;
        private List<Scene> scenes;


        /*
        private ICollection<Figure> figures { get; set; }
        private ICollection<Material> materials { get; set; }
        private ICollection<Model> models{ get; set; }
        private ICollection<Scene> scenes { get; set; }
         */


        public Client()
        {
            this.name = "";
            this.password = "";
            this.figures = new List<Figure>();
            this.materials = new List<Material>();
            this.models = new List<Model>();
            this.scenes = new List<Scene>();
        }


        public Client(string name, string password)
        {
            this.name = name;
            this.password = password;
            this.figures= new List<Figure>();
            this.materials = new List<Material>();
            this.models = new List<Model>();
            this.scenes = new List<Scene>();
        }

        public List<Figure> getFigures()
        {
            return this.figures;
        }

        public List<Material> getMaterials()
        {
            return this.materials;
        }

        public List<Model> getModels()
        {
            return this.models;
        }

        public List<Scene> getScenes()
        {
            return this.scenes;
        }

        public bool VerifyName(string name)
        {
            if(name == "")
            {
				
				throw new EmptyUserNameException();
				
			}
            if (name.Length<3 || name.Length>20 || !Regex.IsMatch(name, @"^\S+$"))
            { 
                return false;
            }
            bool hasNumber = false;
            bool hasLetter = false;
            foreach (char c in name)
            {
                if (char.IsDigit(c))
                {
                    hasNumber = true;
                }
                if (char.IsLetter(c))
                {
                    hasLetter = true;
                }
            }
            return hasNumber && hasLetter;
        }

        public bool VerifyPassword(string password)
        {
            if(password == "")
            {
						throw new EmptyUserNameException();	
			}
            if(password.Length < 5 || password.Length > 25)
            {
                return false;
            }
            bool hasUpperCase = false;
            bool hasNumber = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                if (char.IsDigit(c))
                {
                    hasNumber = true;
                }
            }
            return hasNumber && hasUpperCase;
        }

        public bool MatchingPassword(string password)
        {

            if (password.Length != this.password.Length)
            {
                return false;
            }
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] != this.password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool MatchingUsername(string name)
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

        public  bool VerifyDate(DateTime date)
        {

            DateTime dateNow= DateTime.Now;

            if (DateTime.Compare(dateNow, date) >0 )
            { 

                return true;
            }

            return false;
        }

        public void AddFigure(Figure figure1)
        {

            foreach (Figure figure in figures)
            {

                if  (figure.name == figure1.name)
                { 
                    return;
                }
            }



            this.figures.Add(figure1);
        }

        public  bool VerifyListFigures()
        { 

            if (figures.Count == 0)
            {
                return false;
            }

            if (figures.Count == 1)
            {
                return true;
            }

            for (int i=0;i < figures.Count; i++)
            {

                for (int j=i+1; j< figures.Count; j++)
                {

                    if (figures[i].name == figures[j].name)
                    {
                        return false;
                    }

                }

            }

            return true;
        }

        public bool FigureIsLinked(Figure figure)
        {
            foreach(Model model in this.models)
            {
                if(model.figure == figure)
                {
                    return true;
                }
            }
            return false;
        }


        public void AddMaterial(Material material1)
        {
            foreach(Material material in materials)
            {
                if (material.name == material1.name)
                {
                    return;
                }
            }
            materials.Add(material1);
        }

        public bool VerifyMaterials()
        {
            if (materials.Count == 0)
            {
                return false;
            }
            if (materials.Count == 1)
            {
                return true;
            }
            for(int i = 0; i < materials.Count; i++)
            {
                for(int j = i + 1; j < materials.Count; j++)
                {
                    if (materials[i].name == materials[j].name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool MaterialIsLinked(Material material)
        {
            foreach(Model model in this.models)
            {
                if (model.material == material)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddModel(Model model1)
        {
            foreach (Model model in models)
            {

                if (model.name == model1.name)
                {
                    return;
                }
            }



            this.models.Add(model1);



        }

        public bool VerifyListModels()
        {

            if (models.Count == 0)
            {
                return false;
            }
            if (models.Count == 1)
            {
                return true;
            }
            for (int i = 0; i < models.Count; i++)
            {
                for (int j = i + 1; j < models.Count; j++)
                {
                    if (models[i].name == models[j].name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool ModelIsLinked(Model model)
        {
            foreach(Scene scene in this.scenes)
            {
                if(scene.ModelIsPositioned(model))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddScene(Scene scene1)
        {

            foreach (Scene scene in scenes)
            {

                if (scene.name == scene1.name)
                {
                    return;
                }
            }



            this.scenes.Add(scene1);


        }

        public bool VerifyListScene()
        {


            if (scenes.Count == 0)
            {
                return false;
            }
            if (scenes.Count == 1)
            {
                return true;
            }
            for (int i = 0; i < scenes.Count; i++)
            {
                for (int j = i + 1; j < scenes.Count; j++)
                {
                    if (scenes[i].name == scenes[j].name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


    }
}