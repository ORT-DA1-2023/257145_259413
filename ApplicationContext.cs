using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DataAccess;

public class ApplicationContext: DbContext
{
	public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) {	}

}
