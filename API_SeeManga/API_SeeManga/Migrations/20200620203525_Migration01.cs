using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_SeeManga.Migrations
{
    public partial class Migration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    ID_GENERO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_GENERO = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.ID_GENERO);
                });

            migrationBuilder.CreateTable(
                name: "Situacoes",
                columns: table => new
                {
                    ID_SITUACAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SITUACAO = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacoes", x => x.ID_SITUACAO);
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    ID_MANGA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITULO = table.Column<string>(maxLength: 150, nullable: false),
                    SINOPSE = table.Column<string>(maxLength: 2500, nullable: false),
                    CAPA = table.Column<byte[]>(nullable: false),
                    ID_SITUACAO = table.Column<int>(nullable: false),
                    ID_GENERO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.ID_MANGA);
                    table.ForeignKey(
                        name: "FK_MANGA_GENERO",
                        column: x => x.ID_GENERO,
                        principalTable: "Generos",
                        principalColumn: "ID_GENERO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MANGA_SITUACAO",
                        column: x => x.ID_SITUACAO,
                        principalTable: "Situacoes",
                        principalColumn: "ID_SITUACAO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Capitulos",
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
                    table.PrimaryKey("PK_Capitulos", x => x.ID_CAPITULOS);
                    table.ForeignKey(
                        name: "FK_CAPITULOS_MANGA",
                        column: x => x.ID_MANGA,
                        principalTable: "Mangas",
                        principalColumn: "ID_MANGA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
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
                    table.PrimaryKey("PK_Comentarios", x => x.ID_COMENTARIOS);
                    table.ForeignKey(
                        name: "FK_COMENTARIOS_MANGA",
                        column: x => x.ID_MANGA,
                        principalTable: "Mangas",
                        principalColumn: "ID_MANGA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paginas",
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
                    table.PrimaryKey("PK_Paginas", x => x.ID_PAGINAS);
                    table.ForeignKey(
                        name: "FK_PAGINAS_CAPITULOS",
                        column: x => x.ID_CAPITULOS,
                        principalTable: "Capitulos",
                        principalColumn: "ID_CAPITULOS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Capitulos_ID_MANGA",
                table: "Capitulos",
                column: "ID_MANGA");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ID_MANGA",
                table: "Comentarios",
                column: "ID_MANGA");

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_ID_GENERO",
                table: "Mangas",
                column: "ID_GENERO");

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_ID_SITUACAO",
                table: "Mangas",
                column: "ID_SITUACAO");

            migrationBuilder.CreateIndex(
                name: "IX_Paginas_ID_CAPITULOS",
                table: "Paginas",
                column: "ID_CAPITULOS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Paginas");

            migrationBuilder.DropTable(
                name: "Capitulos");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Situacoes");
        }
    }
}
