using Domain;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Interface.DataAccess;

public class ApplicationContext : DbContext
{
	public DbSet<Client> Clients { get; set; }

	public DbSet<Figure> Figures { get; set; }

	public DbSet<Material> Materials { get; set; }

	public DbSet<Model> Models { get; set; }

	public DbSet<PositionedModel> PositionedModels { get; set; }

	public DbSet<Scene> Scenes { get; set; }


	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Material>()
		.Property(m => m.color)
		.HasConversion(
			c => c.ToArgb(),
			c => Color.FromArgb(c)
		)
		.HasColumnName("Color");

		modelBuilder.Entity<Model>()
		.HasOne(m => m.material)
		.WithMany()
		.IsRequired()
		.OnDelete(DeleteBehavior.NoAction);

		modelBuilder.Entity<Model>()
			.HasOne(m => m.figure)
			.WithMany()
			.IsRequired()
			.OnDelete(DeleteBehavior.NoAction);

		modelBuilder.Entity<PositionedModel>()
			.HasOne(pm => pm.model)
			.WithMany()
			.IsRequired()
			.OnDelete(DeleteBehavior.NoAction);


		modelBuilder.Entity<PositionedModel>()
			.Property(pm => pm.position)
			.HasConversion(
			p => $"{p.x},{p.y},{p.z}",
			p => new Coordinate(p)
			);

		modelBuilder.Entity<Material>()
			.HasDiscriminator<string>("Type")
			.HasValue<LambertianoMaterial>("Lambertian")
			.HasValue<MetalicMaterial>("Metalic");
	}

}
