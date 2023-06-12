using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interface.Migrations
{
    /// <inheritdoc />
    public partial class primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "figures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    radius = table.Column<double>(type: "float", nullable: false),
                    clientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_figures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_figures_clients_clientId",
                        column: x => x.clientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    clientId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    blurred = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_materials_clients_clientId",
                        column: x => x.clientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "scenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastRendered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_scenes_clients_clientId",
                        column: x => x.clientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    figureId = table.Column<int>(type: "int", nullable: false),
                    materialId = table.Column<int>(type: "int", nullable: false),
                    clientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_models_clients_clientId",
                        column: x => x.clientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_models_figures_figureId",
                        column: x => x.figureId,
                        principalTable: "figures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_models_materials_materialId",
                        column: x => x.materialId,
                        principalTable: "materials",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "positionedModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    modelId = table.Column<int>(type: "int", nullable: false),
                    sceneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positionedModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_positionedModels_models_modelId",
                        column: x => x.modelId,
                        principalTable: "models",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_positionedModels_scenes_sceneId",
                        column: x => x.sceneId,
                        principalTable: "scenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_figures_clientId",
                table: "figures",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_materials_clientId",
                table: "materials",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_models_clientId",
                table: "models",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_models_figureId",
                table: "models",
                column: "figureId");

            migrationBuilder.CreateIndex(
                name: "IX_models_materialId",
                table: "models",
                column: "materialId");

            migrationBuilder.CreateIndex(
                name: "IX_positionedModels_modelId",
                table: "positionedModels",
                column: "modelId");

            migrationBuilder.CreateIndex(
                name: "IX_positionedModels_sceneId",
                table: "positionedModels",
                column: "sceneId");

            migrationBuilder.CreateIndex(
                name: "IX_scenes_clientId",
                table: "scenes",
                column: "clientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "positionedModels");

            migrationBuilder.DropTable(
                name: "models");

            migrationBuilder.DropTable(
                name: "scenes");

            migrationBuilder.DropTable(
                name: "figures");

            migrationBuilder.DropTable(
                name: "materials");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
