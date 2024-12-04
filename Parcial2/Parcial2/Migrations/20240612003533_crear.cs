using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parcial2.Migrations
{
    /// <inheritdoc />
    public partial class crear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneroMusical = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaLanzamiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadVendida = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Banda = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Canciones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneroMusical = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    FechaLanzamiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Canciones_Discos_DiscoId",
                        column: x => x.DiscoId,
                        principalTable: "Discos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Discos",
                columns: new[] { "Id", "Banda", "CantidadVendida", "FechaLanzamiento", "GeneroMusical", "SKU", "Titulo" },
                values: new object[,]
                {
                    { 1L, "Pink Floyd", 4500000, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "DSM", "The Dark Side of the Moon" },
                    { 2L, "Michael Jackson", 70000000, new DateTime(1982, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop", "THR", "Thriller" },
                    { 3L, "AC/DC", 50000000, new DateTime(1980, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "BIA", "Back in Black" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nombre", "Password", "UserName" },
                values: new object[,]
                {
                    { 1L, "emi@gmail.com", "Emiliano Pilo", "123456", "user1" },
                    { 2L, "usuario@gmail.com", "USuario 2", "654321", "user2" },
                    { 3L, "usuario3@gmail.com", "Usuario 3", "123456", "user3" }
                });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "DiscoId", "Duracion", "FechaLanzamiento", "GeneroMusical", "Nombre" },
                values: new object[,]
                {
                    { 1L, 1L, 420, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Time" },
                    { 2L, 1L, 382, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Money" },
                    { 3L, 1L, 462, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Us and Them" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_DiscoId",
                table: "Canciones",
                column: "DiscoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Discos");
        }
    }
}
