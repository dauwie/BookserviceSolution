using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookservice.WebAPI.Migrations
{
    public partial class ReaderAndRatingInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publisher_PublisherId",
                table: "Book");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "Book",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Book",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Reader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true),
                    ReaderId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Reader_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Reader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "Created", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 7, 19, 12, 37, 434, DateTimeKind.Local), "James", "Sharp" },
                    { 2, new DateTime(1992, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 7, 19, 12, 37, 434, DateTimeKind.Local), "Sophie", "Netty" },
                    { 3, new DateTime(1996, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 7, 19, 12, 37, 434, DateTimeKind.Local), "Elisa", "Yammy" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Country", "Created", "Name" },
                values: new object[,]
                {
                    { 1, "UK", new DateTime(2018, 11, 7, 19, 12, 37, 494, DateTimeKind.Local), "IT-Publishers" },
                    { 2, "Sweden", new DateTime(2018, 11, 7, 19, 12, 37, 494, DateTimeKind.Local), "FoodBooks" }
                });

            migrationBuilder.InsertData(
                table: "Reader",
                columns: new[] { "Id", "Created", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 11, 7, 19, 12, 37, 517, DateTimeKind.Local), "Joe", "Pageturner" },
                    { 2, new DateTime(2018, 11, 7, 19, 12, 37, 517, DateTimeKind.Local), "Linda", "Bookslaughter" },
                    { 3, new DateTime(2018, 11, 7, 19, 12, 37, 517, DateTimeKind.Local), "Wendy", "Allreader" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Created", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2018, 11, 7, 19, 12, 37, 682, DateTimeKind.Local), "book1.jpg", "123456789", 420, 24.99m, 1, "Learning C#", 2018 },
                    { 2, 2, new DateTime(2018, 11, 7, 19, 12, 37, 682, DateTimeKind.Local), "book2.jpg", "45689132", 360, 35.99m, 1, "Mastering Linq", 2016 },
                    { 3, 1, new DateTime(2018, 11, 7, 19, 12, 37, 682, DateTimeKind.Local), "book3.jpg", "15856135", 360, 50.00m, 1, "Mastering Xamarin", 2017 },
                    { 4, 2, new DateTime(2018, 11, 7, 19, 12, 37, 682, DateTimeKind.Local), "book1.jpg", "56789564", 360, 45.00m, 1, "Exploring ASP.Net Core 2.0", 2018 },
                    { 5, 2, new DateTime(2018, 11, 7, 19, 12, 37, 682, DateTimeKind.Local), "book2.jpg", "234546684", 420, 70.50m, 1, "Unity Game Development", 2017 },
                    { 6, 3, new DateTime(2018, 11, 7, 19, 12, 37, 682, DateTimeKind.Local), "book3.jpg", "789456258", 40, 52.00m, 2, "Cooking is fun", 2007 },
                    { 7, 3, new DateTime(2018, 11, 7, 19, 12, 37, 682, DateTimeKind.Local), "book3.jpg", "94521546", 53, 30.00m, 2, "Secret recipes", 2017 }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "BookId", "Created", "ReaderId", "Score" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2018, 11, 7, 19, 12, 37, 508, DateTimeKind.Local), 1, 3 },
                    { 4, 1, new DateTime(2018, 11, 7, 19, 12, 37, 508, DateTimeKind.Local), 2, 4 },
                    { 2, 2, new DateTime(2018, 11, 7, 19, 12, 37, 508, DateTimeKind.Local), 1, 2 },
                    { 5, 2, new DateTime(2018, 11, 7, 19, 12, 37, 508, DateTimeKind.Local), 3, 2 },
                    { 3, 3, new DateTime(2018, 11, 7, 19, 12, 37, 508, DateTimeKind.Local), 2, 5 },
                    { 6, 3, new DateTime(2018, 11, 7, 19, 12, 37, 508, DateTimeKind.Local), 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_BookId",
                table: "Rating",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ReaderId",
                table: "Rating",
                column: "ReaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publisher_PublisherId",
                table: "Book",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publisher_PublisherId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Reader");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "Book",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Book",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "Created", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 25, 11, 59, 44, 955, DateTimeKind.Local), "James", "Sharp" },
                    { 2, new DateTime(1992, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 25, 11, 59, 44, 955, DateTimeKind.Local), "Sophie", "Netty" },
                    { 3, new DateTime(1996, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 25, 11, 59, 44, 955, DateTimeKind.Local), "Elisa", "Yammy" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Country", "Created", "Name" },
                values: new object[,]
                {
                    { 1, "UK", new DateTime(2018, 10, 25, 11, 59, 44, 956, DateTimeKind.Local), "IT-Publishers" },
                    { 2, "Sweden", new DateTime(2018, 10, 25, 11, 59, 44, 956, DateTimeKind.Local), "FoodBooks" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Created", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 1, null, "book1.jpg", "123456789", 420, 24.99m, 1, "Learning C#", 2018 },
                    { 2, 2, null, "book2.jpg", "45689132", 360, 35.99m, 1, "Mastering Linq", 2016 },
                    { 3, 1, null, "book3.jpg", "15856135", 360, 50.00m, 1, "Mastering Xamarin", 2017 },
                    { 4, 2, null, "book1.jpg", "56789564", 360, 45.00m, 1, "Exploring ASP.Net Core 2.0", 2018 },
                    { 5, 2, null, "book2.jpg", "234546684", 420, 70.50m, 1, "Unity Game Development", 2017 },
                    { 6, 3, null, "book3.jpg", "789456258", 40, 52.00m, 2, "Cooking is fun", 2007 },
                    { 7, 3, null, "book3.jpg", "94521546", 53, 30.00m, 2, "Secret recipes", 2017 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publisher_PublisherId",
                table: "Book",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
