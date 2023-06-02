using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interface.Migrations
{
    /// <inheritdoc />
    public partial class CreateUfdfdfdfds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "figures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_figures_clientId",
                table: "figures",
                column: "clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_figures_clients_clientId",
                table: "figures",
                column: "clientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_figures_clients_clientId",
                table: "figures");

            migrationBuilder.DropIndex(
                name: "IX_figures_clientId",
                table: "figures");

            migrationBuilder.DropColumn(
                name: "clientId",
                table: "figures");
        }
    }
}
