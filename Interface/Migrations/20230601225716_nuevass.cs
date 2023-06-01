using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interface.Migrations
{
    /// <inheritdoc />
    public partial class nuevass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "positionedModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "sceneId",
                table: "positionedModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_positionedModels_scenes_Id",
                table: "positionedModels",
                column: "Id",
                principalTable: "scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_positionedModels_scenes_Id",
                table: "positionedModels");

            migrationBuilder.DropColumn(
                name: "sceneId",
                table: "positionedModels");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "positionedModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
