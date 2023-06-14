using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interface.Migrations
{
    /// <inheritdoc />
    public partial class primera1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "aperture",
                table: "scenes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "fieldOfView",
                table: "scenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "lookAt",
                table: "scenes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lookFrom",
                table: "scenes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aperture",
                table: "scenes");

            migrationBuilder.DropColumn(
                name: "fieldOfView",
                table: "scenes");

            migrationBuilder.DropColumn(
                name: "lookAt",
                table: "scenes");

            migrationBuilder.DropColumn(
                name: "lookFrom",
                table: "scenes");
        }
    }
}
