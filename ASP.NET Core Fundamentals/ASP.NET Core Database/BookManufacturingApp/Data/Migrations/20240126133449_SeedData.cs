using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManufacturingApp.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "BirthDate", "Email", "Name", "Nationality", "PhoneNumber" },
                values: new object[] { 1, "Dan Brown is the author of numerous #1 bestselling novels. Brown’s novels are published in 56 languages around the world with over 200 million copies in print.", new DateTime(1964, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "danBrown@gmail.com", "Dan Brown", "American", "0883332351" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "BirthDate", "Email", "Name", "Nationality", "PhoneNumber" },
                values: new object[] { 2, " He has been popularly identified as the \"father\" of modern fantasy literature—or, more precisely, of high fantasy, and is widely regarded as one of the most influential authors of all time.", new DateTime(1982, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "j.r.r.tolkien@yahoo.com", "J. R. R. Tolkien", "British", "0999283911" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "BirthDate", "Email", "Name", "Nationality", "PhoneNumber" },
                values: new object[] { 3, "American novelist, screenwriter, television producer, and short story writer. He is the author of the series of epic fantasy novels A Song of Ice and Fire.", new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "g.r.r.Martin@gmail.com", "George R. R. Martin", "American", "8889106871" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "Information", "Pages", "Price", "PrintingDate", "Title" },
                values: new object[] { 1, 1, "Thriller", "The Da Vinci Code follows symbologist Robert Langdon and cryptologist Sophie Neveu after a murder in the Louvre Museum in Paris causes them to become involved in a battle between the Priory of Sion and Opus Dei over the possibility of Jesus Christ and Mary Magdalene having had a child together.", 689, 24m, new DateTime(2003, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Da Vinci Code" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "Information", "Pages", "Price", "PrintingDate", "Title" },
                values: new object[] { 2, 2, "Fantasy", "The book is recognized as a classic in children's literature and is one of the best-selling books of all time, with over 100 million copies sold.", 310, 18m, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hobbit" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "Information", "Pages", "Price", "PrintingDate", "Title" },
                values: new object[] { 3, 3, "Fantasy", "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin.", 694, 32m, new DateTime(1996, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
