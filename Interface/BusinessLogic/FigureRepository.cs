using Interface.DataAccess;
using Domain;
using Exceptions;
using Interface.Pages.User;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Linq.Expressions;





namespace Interface.BusinessLogic
{
	public class FigureRepository
	{

		private Client logged;
		private ApplicationContext _dbContext;
		private SessionManager sessionManager;
		private ClientRepository clientRepository;



		public FigureRepository(SessionManager sessionManager, ApplicationContext _dbContext)
		{
			this.sessionManager = sessionManager;
			this._dbContext = _dbContext;
			this.clientRepository = new ClientRepository(_dbContext, sessionManager);
			this.logged = clientRepository.Find(sessionManager.CurrentUser.Id);
		}

		public List<Figure> GetFigures()
		{
			return _dbContext.figures.Where(f => f.client.Id == logged.Id).ToList();
		}

		public Figure MatchingFigure(string name)
		{
			List<Figure> figures = GetFigures();
			foreach (var figure in figures)
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
			List<Figure> figures = GetFigures();
			if (figures != null)
			{
				foreach (Figure fig in figures)
				{
					if (fig.name == figure.name)
					{
						return;
					}
				}
			}
			_dbContext.figures.Add(figure);
			_dbContext.SaveChanges();
		}

		public void CreateFigure(string name, double radiusNumber)
		{
			Figure fig = new Figure();

			if (fig.VerifyNameFigure(name) && fig.VerifyRadiusFigure(radiusNumber))
			{
				Figure newFig = new Figure(name, radiusNumber);
				newFig.client = this.logged;
				addFigure(newFig);
			}
			else
			{
				throw new InvalidOperationException("Radio o Nombre Incorrecto");
			}
		}

		public bool FigureIsLinked(Figure figure)
		{
			List<Model> models = _dbContext.models.Where(m => m.client.Id == logged.Id).ToList();
			foreach (Model model in models)
			{
				if (model.figure == figure)
				{
					return true;
				}
			}
			return false;
		}

		public void Delete(Figure figure)
		{
			if (FigureIsLinked(figure))
			{
				throw new InvalidOperationException("La figura seleccionada está siendo usada por un modelo existente");
			}
			else
			{
				_dbContext.figures.Remove(figure);
				_dbContext.SaveChanges();
			}
		}

		public Figure Find(int id)
		{
			Figure result = _dbContext.figures.FirstOrDefault(f => f.Id == id);
			_dbContext.SaveChanges();
			return result;
		}





	}
}
