using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleApp.Infrastucture.Migrations
{
    public partial class SeedContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Email", "FullName", "PhoneNumber" },
                values: new object[] { 1, "London, UK", "jsmith@mail.com", "John Smith", "123456" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Email", "FullName", "PhoneNumber" },
                values: new object[] { 2, "Albuquerque, New Mexico, USA", "wwhite@gmail.com", "Walter White", "654321" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
