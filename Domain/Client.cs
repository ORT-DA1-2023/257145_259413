using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Domain
{
    public class Client
    {
        public string name;
        public string password;   // cambie a publico
        private List<Figure> figures;
        private List<Material> materials;
        private List<Model> models;
        private List<Scene> scenes;


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

        public  bool VerifyDate(DateTime date)
        {

            DateTime dateNow= DateTime.Now;

            if (DateTime.Compare(dateNow, date) >0 )
            { 

                return true;
            }

            return false;
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

        public void addFigures(Figure figure1)
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

        public bool VerifyName(string name)
        {
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

        public void addModel(Model model1)
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

        public void addScenes(Scene scene1)
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

        internal bool Equals(Client client)
        {
            return client.MatchingUsername(this.name) && client.MatchingPassword(this.password);
        }
    }
}