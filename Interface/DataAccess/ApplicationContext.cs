using System;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Drawing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interface.DataAccess;

public class ApplicationContext : DbContext
{
	public DbSet<Client> clients { get; set; }

	public DbSet<Figure> figures { get; set; }

	public DbSet<Material> materials { get; set; }

	public DbSet<Model> models { get; set; }

	public DbSet<PositionedModel> positionedModels { get; set; }

	public DbSet<Scene> scenes { get; set; }


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
