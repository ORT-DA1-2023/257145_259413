using Interface.BusinessLogic;
using Interface.DataAccess;
using System;
using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.test
{
	[TestClass]
	public class FiguresTest
	{
		private FigureRepository figureRepository;
		private SessionManager sessionManager;

		[TestInitialize]
		public void Initialize()
		{
			figureRepository = new FigureRepository(sessionManager, TestContextFactory.CreateContext());
			sessionManager.CurrentUser = new Client("TestManager", "PasswordTest");
		}

		[TestMethod]
		public void ResturnsTrueIfFigureIsAdded()
		{
			figureRepository.CreateFigure("myFigure", 2);
			Figure result = figureRepository.MatchingFigure("myFigure");
			Assert.AreEqual("myFigure", result.name);
		}

		[TestMethod]
		public void ReturnsTrueIfFigureIsFound()
		{
			figureRepository.CreateFigure("foundFigure", 2);
			Figure result = figureRepository.MatchingFigure("foundFigure");
			Figure found = figureRepository.Find(result.Id);
			Assert.AreEqual("foundFigure", found.name);
		}
	}
}
