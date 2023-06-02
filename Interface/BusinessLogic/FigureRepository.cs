using Interface.DataAccess;
using Domain;
using Exceptions;
using Interface.DataAccess;
using Interface.Pages.User;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Linq.Expressions;





namespace Interface.BusinessLogic
{
	public class FigureRepository
	{

		public Client logged { get; set; }
		private ApplicationContext _dbContext;
		private SessionManager sessionManager;



        public FigureRepository(SessionManager sessionManager, ApplicationContext _dbContext)
        {
            this.sessionManager = sessionManager;
			this._dbContext = _dbContext;
			this.logged = sessionManager.CurrentUser;
        }


        public Figure MatchingFigure(string name)
		{
			foreach (var figure in this.logged.getFigures())
			{
				if (figure.name == name)
				{
					return figure;
				}
			}
			return new Figure();
		}

		public void addFigure(Figure figure)
		{
            sessionManager.CurrentUser.AddFigure(figure);
			_dbContext.SaveChanges();	
		}

		public void CreateFigure(string name, double radiusNumber)
		{
            Figure fig = new Figure();

            if (fig.VerifyNameFigure(name) && fig.VerifyRadiusFigure(radiusNumber))
            {


                Figure newFig = new Figure(name, radiusNumber);
				newFig.client= sessionManager.CurrentUser;
				addFigure(newFig);


            }
            else
            {
				throw new InvalidOperationException("Radio o Nombre Incorrecto");
            }


        }




		public List<Figure> GetFigures()
		{
			return sessionManager.CurrentUser.getFigures();





		}


		public void Delete(Figure figure)
		{
			if (sessionManager.CurrentUser.FigureIsLinked(figure))
			{
				throw new InvalidOperationException("La figura seleccionada está siendo usada por un modelo existente");
			}
			else
			{
				_dbContext.figures.Remove(figure);
                _dbContext.SaveChanges();
            }
		}

		public Figure Find (string name)
		{
			Figure result = _dbContext.figures.FirstOrDefault(f => f.name == name);
            _dbContext.SaveChanges();
            return result;
		}





	}
}
