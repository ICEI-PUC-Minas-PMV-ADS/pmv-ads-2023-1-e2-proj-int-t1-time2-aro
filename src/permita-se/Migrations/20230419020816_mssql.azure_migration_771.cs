using Microsoft.EntityFrameworkCore.Migrations;

namespace permita_se.Migrations
{
    public partial class mssqlazure_migration_771 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    descricao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pergunta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    texto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pergunta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "questionario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    senha = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    idade = table.Column<int>(type: "int", nullable: true),
                    telefone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    gerente = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    descricao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    preco = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    imagem_url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK__produto__id_cate__60A75C0F",
                        column: x => x.id_categoria,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "opcao_resposta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_pergunta = table.Column<int>(type: "int", nullable: false),
                    texto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opcao_resposta", x => x.id);
                    table.ForeignKey(
                        name: "FK__opcao_res__id_pe__6EF57B66",
                        column: x => x.id_pergunta,
                        principalTable: "pergunta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pergunta_questionario",
                columns: table => new
                {
                    id_questionario = table.Column<int>(type: "int", nullable: false),
                    id_pergunta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pergunta__DC4D1DA718F174D8", x => new { x.id_questionario, x.id_pergunta });
                    table.ForeignKey(
                        name: "FK__pergunta___id_pe__6C190EBB",
                        column: x => x.id_pergunta,
                        principalTable: "pergunta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__pergunta___id_qu__6B24EA82",
                        column: x => x.id_questionario,
                        principalTable: "questionario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "favoritos",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_produto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__favorito__D59D8EC601C60CFF", x => new { x.id_usuario, x.id_produto });
                    table.ForeignKey(
                        name: "FK__favoritos__id_pr__6477ECF3",
                        column: x => x.id_produto,
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__favoritos__id_us__6383C8BA",
                        column: x => x.id_usuario,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_favoritos_id_produto",
                table: "favoritos",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_opcao_resposta_id_pergunta",
                table: "opcao_resposta",
                column: "id_pergunta");

            migrationBuilder.CreateIndex(
                name: "IX_pergunta_questionario_id_pergunta",
                table: "pergunta_questionario",
                column: "id_pergunta");

            migrationBuilder.CreateIndex(
                name: "IX_produto_id_categoria",
                table: "produto",
                column: "id_categoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favoritos");

            migrationBuilder.DropTable(
                name: "opcao_resposta");

            migrationBuilder.DropTable(
                name: "pergunta_questionario");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "pergunta");

            migrationBuilder.DropTable(
                name: "questionario");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
