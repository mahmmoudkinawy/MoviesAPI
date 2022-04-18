using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesAPI.Data.Migrations
{
    public partial class AddedGenreTableAndSeedSomeGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("791b45cf-4fab-42ad-bfa2-abb4ca38b287"), "Action" },
                    { new Guid("ad4a7265-20bc-4e6f-bc49-b66b7fd6b932"), "Drama" },
                    { new Guid("c933dc80-cb03-425f-bf64-eaf5cb2752fc"), "Comedy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
