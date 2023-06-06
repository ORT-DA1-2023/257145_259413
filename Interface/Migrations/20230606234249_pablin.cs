using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interface.Migrations
{
    /// <inheritdoc />
    public partial class pablin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "scenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "models",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_scenes_clientId",
                table: "scenes",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_models_ClientId",
                table: "models",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_materials_clientId",
                table: "materials",
                column: "clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_materials_clients_clientId",
                table: "materials",
                column: "clientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_models_clients_ClientId",
                table: "models",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_scenes_clients_clientId",
                table: "scenes",
                column: "clientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materials_clients_clientId",
                table: "materials");

            migrationBuilder.DropForeignKey(
                name: "FK_models_clients_ClientId",
                table: "models");

            migrationBuilder.DropForeignKey(
                name: "FK_scenes_clients_clientId",
                table: "scenes");

            migrationBuilder.DropIndex(
                name: "IX_scenes_clientId",
                table: "scenes");

            migrationBuilder.DropIndex(
                name: "IX_models_ClientId",
                table: "models");

            migrationBuilder.DropIndex(
                name: "IX_materials_clientId",
                table: "materials");

            migrationBuilder.DropColumn(
                name: "clientId",
                table: "scenes");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "models");

            migrationBuilder.DropColumn(
                name: "clientId",
                table: "materials");
        }
    }
}
