using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace global_impact_idoei.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Alimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoAlimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Alimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Doacao",
                columns: table => new
                {
                    IdOng = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdAlimento = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    DtRecebimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Doacao", x => new { x.IdOng, x.IdEmpresa, x.IdAlimento });
                });

            migrationBuilder.CreateTable(
                name: "Tb_Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoAlimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDoacao = table.Column<int>(type: "int", nullable: false),
                    IdAlimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Ong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaAtuacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Ong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Resultado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtRealizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOng = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Resultado", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Alimento");

            migrationBuilder.DropTable(
                name: "Tb_Doacao");

            migrationBuilder.DropTable(
                name: "Tb_Empresa");

            migrationBuilder.DropTable(
                name: "Tb_Ong");

            migrationBuilder.DropTable(
                name: "Tb_Resultado");
        }
    }
}
