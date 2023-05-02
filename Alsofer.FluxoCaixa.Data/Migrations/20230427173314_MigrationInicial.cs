using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alsofer.FluxoCaixa.Data.Migrations
{
    public partial class MigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeCliente = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    cpfCnpj = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ddd = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    nmUsuarioCadastro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nmUsuarioAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ContasPagar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFornecedor = table.Column<int>(type: "int", nullable: false),
                    idDespesa = table.Column<int>(type: "int", nullable: false),
                    idStatus = table.Column<int>(type: "int", nullable: false),
                    descricaoContaPagar = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    dtPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vlPagamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nmUsuarioCadastro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nmUsuarioAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasPagar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ContasReceber",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    idDespesa = table.Column<int>(type: "int", nullable: false),
                    idStatus = table.Column<int>(type: "int", nullable: false),
                    descricaoContasReceber = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    dtPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vlPagamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nmUsuarioCadastro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nmUsuarioAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasReceber", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeDespesa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descricaoDespesa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    nmUsuarioCadastro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nmUsuarioAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razaoSocial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nomeFantasia = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    cpfCnpj = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ddd = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    nmUsuarioCadastro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nmUsuarioAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nmUsuarioCadastro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtCadastro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nmUsuarioAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeReceita = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descricaoReceita = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    nmUsuarioCadastro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nmUsuarioAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nmUsuarioCadastro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtCadastro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    nmUsuarioAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ContasPagar");

            migrationBuilder.DropTable(
                name: "ContasReceber");

            migrationBuilder.DropTable(
                name: "Despesa");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
