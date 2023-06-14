using Interface.DataAccess;
using Domain;
using Exceptions;
using Interface.Pages.User;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Interface.BusinessLogic
{
	public class FigureRepository
	{

		private Client _logged;
		private ApplicationContext _dbContext;
		private SessionManager _sessionManager;
		private ClientRepository _clientRepository;



        public FigureRepository(SessionManager sessionManager, ApplicationContext _dbContext)
        {
            this._sessionManager = sessionManager;
			this._dbContext = _dbContext;
			this._clientRepository = new ClientRepository(_dbContext, sessionManager);
			this._logged = _clientRepository.Find(sessionManager.CurrentUser.Id);
        }

		public List<Figure> GetFigures()
		{
			  return _dbContext.Figures.Where(f => f.client.Id == _logged.Id).ToList();
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
			_dbContext.Figures.Add(figure);
			_dbContext.SaveChanges();
		}

		public void CreateFigure(string name, double radiusNumber)
		{
			Figure fig = new Figure();

			if (fig.VerifyNameFigure(name) && fig.VerifyRadiusFigure(radiusNumber))
			{
				Figure newFig = new Figure(name, radiusNumber);
				newFig.client = this._logged;
				addFigure(newFig);
			}
			else
			{
				throw new InvalidOperationException("Radio o Nombre Incorrecto");
			}
		}

		public bool FigureIsLinked(Figure figure)
		{
			List<Model> models = _dbContext.Models.Where(m => m.client.Id == _logged.Id).ToList();
			foreach(Model model in models)
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
				_dbContext.Figures.Remove(figure);
                _dbContext.SaveChanges();
            }
		}

		public Figure Find(int id)
		{
			Figure result = _dbContext.Figures.FirstOrDefault(f => f.Id == id);
            _dbContext.SaveChanges();
            return result;
		}





	}
}
