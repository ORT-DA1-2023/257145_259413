using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interface.Migrations
{
    /// <inheritdoc />
    public partial class CreateUltims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SceneId",
                table: "positionedModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_positionedModels_SceneId",
                table: "positionedModels",
                column: "SceneId");

            migrationBuilder.AddForeignKey(
                name: "FK_positionedModels_scenes_SceneId",
                table: "positionedModels",
                column: "SceneId",
                principalTable: "scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_positionedModels_scenes_SceneId",
                table: "positionedModels");

            migrationBuilder.DropIndex(
                name: "IX_positionedModels_SceneId",
                table: "positionedModels");

            migrationBuilder.DropColumn(
                name: "SceneId",
                table: "positionedModels");
        }
    }
}
