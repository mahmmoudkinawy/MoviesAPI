using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesAPI.Data.Migrations
{
    public partial class UpdatedNameColumnToBeRequriedInGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("791b45cf-4fab-42ad-bfa2-abb4ca38b287"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ad4a7265-20bc-4e6f-bc49-b66b7fd6b932"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c933dc80-cb03-425f-bf64-eaf5cb2752fc"));

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("36c6a9fe-a54c-46eb-8f0f-0b9a584864d3"), "Drama" },
                    { new Guid("3ae09852-d426-4782-8737-e062a814394f"), "Action" },
                    { new Guid("8064cf6c-e113-4144-9ac7-1b9f540397fc"), "Comedy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("36c6a9fe-a54c-46eb-8f0f-0b9a584864d3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3ae09852-d426-4782-8737-e062a814394f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8064cf6c-e113-4144-9ac7-1b9f540397fc"));

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
    }
}
