using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteBFF.Migrations {
    /// <summary>
    /// init migration
    /// </summary>
    public partial class init : Migration {
        /// <summary>
        /// Up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable (
                name: "Sexos",
                columns : table => new {
                    SexoId = table.Column<int> (nullable: false)
                        .Annotation ("Sqlite:Autoincrement", true),
                        Descricao = table.Column<string> (maxLength: 15, nullable: true)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_Sexos", x => x.SexoId);
                });

            migrationBuilder.CreateTable (
                name: "Usuarios",
                columns : table => new {
                    UserId = table.Column<int> (nullable: false)
                        .Annotation ("Sqlite:Autoincrement", true),
                        Nome = table.Column<string> (nullable: true),
                        DataNascimento = table.Column<DateTime> (nullable: false),
                        Email = table.Column<string> (nullable: true),
                        Senha = table.Column<string> (nullable: true),
                        Ativo = table.Column<bool> (nullable: false),
                        SexoId = table.Column<int> (nullable: false)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_Usuarios", x => x.UserId);
                    table.ForeignKey (
                        name: "FK_Usuarios_Sexos_SexoId",
                        column : x => x.SexoId,
                        principalTable: "Sexos",
                        principalColumn: "SexoId",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex (
                name: "IX_Usuarios_SexoId",
                table: "Usuarios",
                column: "SexoId");
        }

        /// <summary>
        /// down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable (
                name: "Usuarios");

            migrationBuilder.DropTable (
                name: "Sexos");
        }
    }
}