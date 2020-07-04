using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_SeeManga.Migrations
{
    public partial class Migration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GENEROS",
                columns: table => new
                {
                    ID_GENERO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_GENERO = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GENEROS", x => x.ID_GENERO);
                });

            migrationBuilder.CreateTable(
                name: "SITUACOES",
                columns: table => new
                {
                    ID_SITUACAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SITUACAO = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SITUACOES", x => x.ID_SITUACAO);
                });

            migrationBuilder.CreateTable(
                name: "MANGAS",
                columns: table => new
                {
                    ID_MANGA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITULO = table.Column<string>(maxLength: 150, nullable: false),
                    SINOPSE = table.Column<string>(maxLength: 2500, nullable: false),
                    CAPA = table.Column<byte[]>(nullable: false),
                    ID_SITUACAO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANGAS", x => x.ID_MANGA);
                    table.ForeignKey(
                        name: "FK_MANGA_SITUACAO",
                        column: x => x.ID_SITUACAO,
                        principalTable: "SITUACOES",
                        principalColumn: "ID_SITUACAO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CAPITULOS",
                columns: table => new
                {
                    ID_CAPITULOS = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMERO = table.Column<int>(nullable: false),
                    QT_CAPITULOS = table.Column<int>(nullable: false),
                    ID_MANGA = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAPITULOS", x => x.ID_CAPITULOS);
                    table.ForeignKey(
                        name: "FK_CAPITULOS_MANGA",
                        column: x => x.ID_MANGA,
                        principalTable: "MANGAS",
                        principalColumn: "ID_MANGA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COMENTARIOS",
                columns: table => new
                {
                    ID_COMENTARIOS = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMENTARIO = table.Column<string>(maxLength: 500, nullable: false),
                    ID_USUARIO = table.Column<int>(nullable: false),
                    ID_MANGA = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMENTARIOS", x => x.ID_COMENTARIOS);
                    table.ForeignKey(
                        name: "FK_COMENTARIOS_MANGA",
                        column: x => x.ID_MANGA,
                        principalTable: "MANGAS",
                        principalColumn: "ID_MANGA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MANGA_GENEROS",
                columns: table => new
                {
                    ID_MANGA = table.Column<int>(nullable: false),
                    ID_GENERO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANGA_GENEROS", x => new { x.ID_GENERO, x.ID_MANGA });
                    table.ForeignKey(
                        name: "FK_MANGA_GENEROS_GENERO",
                        column: x => x.ID_GENERO,
                        principalTable: "GENEROS",
                        principalColumn: "ID_GENERO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MANGA_GENEROS_MANGA",
                        column: x => x.ID_MANGA,
                        principalTable: "MANGAS",
                        principalColumn: "ID_MANGA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PAGINAS",
                columns: table => new
                {
                    ID_PAGINAS = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMERO = table.Column<int>(nullable: false),
                    PAGINA = table.Column<byte[]>(nullable: false),
                    ID_CAPITULOS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGINAS", x => x.ID_PAGINAS);
                    table.ForeignKey(
                        name: "FK_PAGINAS_CAPITULO",
                        column: x => x.ID_CAPITULOS,
                        principalTable: "CAPITULOS",
                        principalColumn: "ID_CAPITULOS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CAPITULOS_ID_MANGA",
                table: "CAPITULOS",
                column: "ID_MANGA");

            migrationBuilder.CreateIndex(
                name: "IX_COMENTARIOS_ID_MANGA",
                table: "COMENTARIOS",
                column: "ID_MANGA");

            migrationBuilder.CreateIndex(
                name: "IX_MANGA_GENEROS_ID_MANGA",
                table: "MANGA_GENEROS",
                column: "ID_MANGA");

            migrationBuilder.CreateIndex(
                name: "IX_MANGAS_ID_SITUACAO",
                table: "MANGAS",
                column: "ID_SITUACAO");

            migrationBuilder.CreateIndex(
                name: "IX_PAGINAS_ID_CAPITULOS",
                table: "PAGINAS",
                column: "ID_CAPITULOS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMENTARIOS");

            migrationBuilder.DropTable(
                name: "MANGA_GENEROS");

            migrationBuilder.DropTable(
                name: "PAGINAS");

            migrationBuilder.DropTable(
                name: "GENEROS");

            migrationBuilder.DropTable(
                name: "CAPITULOS");

            migrationBuilder.DropTable(
                name: "MANGAS");

            migrationBuilder.DropTable(
                name: "SITUACOES");
        }
    }
}
