using System;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataAccess;

public class ApplicationContext: DbContext
{


	public DbSet<Client> clients { get; set; }

	public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) {	}
	// para migraciones el -v te da los logs
	//dotnet ef migrations add CreateUsers -v
}
