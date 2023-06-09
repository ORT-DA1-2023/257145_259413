using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interface.Migrations
{
    /// <inheritdoc />
    public partial class microds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_models_clients_ClientId",
                table: "models");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "models",
                newName: "clientId");

            migrationBuilder.RenameIndex(
                name: "IX_models_ClientId",
                table: "models",
                newName: "IX_models_clientId");

            migrationBuilder.AlterColumn<int>(
                name: "clientId",
                table: "models",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_models_clients_clientId",
                table: "models",
                column: "clientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_models_clients_clientId",
                table: "models");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "models",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_models_clientId",
                table: "models",
                newName: "IX_models_ClientId");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "models",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_models_clients_ClientId",
                table: "models",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id");
        }
    }
}
