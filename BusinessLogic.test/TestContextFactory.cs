using Interface.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.test
{
	public static class TestContextFactory
	{
		private const string ConnectionString = "Data Source=DESKTOP-G58UOLC;Initial Catalog=TestObligatorio;Integrated Security=True;TrustServerCertificate=true;";

		public static ApplicationContext CreateContext()
			=> new ApplicationContext(
				new DbContextOptionsBuilder<ApplicationContext>()
				.UseSqlServer(ConnectionString)
				.Options
				);
	}
}