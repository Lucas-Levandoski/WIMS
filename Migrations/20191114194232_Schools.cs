using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Schools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_extracao = table.Column<DateTime>(nullable: true),
                    dep_administrativa = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true),
                    inep = table.Column<int>(nullable: true),
                    nome = table.Column<string>(nullable: false),
                    abr_nome = table.Column<string>(nullable: true),
                    logradouro = table.Column<string>(nullable: true),
                    numero = table.Column<int>(nullable: true),
                    bairro = table.Column<string>(nullable: true),
                    cep = table.Column<int>(nullable: true),
                    latitude = table.Column<float>(nullable: true),
                    longitude = table.Column<float>(nullable: true),
                    telefone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    url_website = table.Column<string>(nullable: true),
                    blog = table.Column<string>(nullable: true),
                    twitter = table.Column<string>(nullable: true),
                    facebook = table.Column<string>(nullable: true),
                    reg_conselho_tutelar = table.Column<int>(nullable: true),
                    desc_reg_conselho_tutelar = table.Column<string>(nullable: true),
                    reg_orcamento_part = table.Column<int>(nullable: true),
                    desc_reg_orcamento_part = table.Column<string>(nullable: true),
                    situacao_funcionamento = table.Column<string>(nullable: true),
                    convenio_municipal = table.Column<string>(nullable: true),
                    convenio_estadual = table.Column<string>(nullable: true),
                    convenio_federal = table.Column<string>(nullable: true),
                    convenio_fasc = table.Column<string>(nullable: true),
                    escola_especial = table.Column<string>(nullable: true),
                    cat_part_privada = table.Column<string>(nullable: true),
                    cat_part_comunitaria = table.Column<string>(nullable: true),
                    cat_part_confessional = table.Column<string>(nullable: true),
                    cat_part_filantropica = table.Column<string>(nullable: true),
                    mant_empresa_privada = table.Column<string>(nullable: true),
                    mant_sindicato = table.Column<string>(nullable: true),
                    mant_sistema_s = table.Column<string>(nullable: true),
                    mant_ong = table.Column<string>(nullable: true),
                    mant_apae = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
