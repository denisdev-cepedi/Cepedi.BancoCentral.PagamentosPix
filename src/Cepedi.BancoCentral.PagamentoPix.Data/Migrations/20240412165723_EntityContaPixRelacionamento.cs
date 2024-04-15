using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.BancoCentral.PagamentoPix.Data.Migrations
{
    /// <inheritdoc />
    public partial class EntityContaPixRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    IdConta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPessoa = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.IdConta);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    IdConta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "TransacaoPix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChavePix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChaveDeSeguranca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPixOrigem = table.Column<int>(type: "int", nullable: false),
                    IdPixDestino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacaoPix", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pix",
                columns: table => new
                {
                    IdPix = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdConta = table.Column<int>(type: "int", nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: false),
                    ChavePix = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IdTipoPix = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pix", x => x.IdPix);
                    table.ForeignKey(
                        name: "FK_Pix_Contas_IdConta",
                        column: x => x.IdConta,
                        principalTable: "Contas",
                        principalColumn: "IdConta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pix_IdConta",
                table: "Pix",
                column: "IdConta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Pix");

            migrationBuilder.DropTable(
                name: "TransacaoPix");

            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
