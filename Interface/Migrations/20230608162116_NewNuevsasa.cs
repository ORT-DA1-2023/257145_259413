using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interface.Migrations
{
    /// <inheritdoc />
    public partial class NewNuevsasa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_models_figures_figureId",
                table: "models");

            migrationBuilder.DropForeignKey(
                name: "FK_models_materials_materialId",
                table: "models");

            migrationBuilder.AddForeignKey(
                name: "FK_models_figures_figureId",
                table: "models",
                column: "figureId",
                principalTable: "figures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_models_materials_materialId",
                table: "models",
                column: "materialId",
                principalTable: "materials",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_models_figures_figureId",
                table: "models");

            migrationBuilder.DropForeignKey(
                name: "FK_models_materials_materialId",
                table: "models");

            migrationBuilder.AddForeignKey(
                name: "FK_models_figures_figureId",
                table: "models",
                column: "figureId",
                principalTable: "figures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_models_materials_materialId",
                table: "models",
                column: "materialId",
                principalTable: "materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
