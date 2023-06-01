using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interface.Migrations
{
    /// <inheritdoc />
    public partial class nuevasdss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_positionedModels_scenes_Id",
                table: "positionedModels");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "positionedModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_positionedModels_sceneId",
                table: "positionedModels",
                column: "sceneId");

            migrationBuilder.AddForeignKey(
                name: "FK_positionedModels_scenes_sceneId",
                table: "positionedModels",
                column: "sceneId",
                principalTable: "scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_positionedModels_scenes_sceneId",
                table: "positionedModels");

            migrationBuilder.DropIndex(
                name: "IX_positionedModels_sceneId",
                table: "positionedModels");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "positionedModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_positionedModels_scenes_Id",
                table: "positionedModels",
                column: "Id",
                principalTable: "scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
