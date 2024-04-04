using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedclientsbillings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 100, "Joseph Carlton" },
                    { 200, "Maria Juarez" },
                    { 300, "Albert Kenny" },
                    { 400, "Jessica Phillips" },
                    { 500, "Charles Johnson" }
                });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "Id", "BillingCategoryId", "BillingStatusId", "Charge", "ClientId", "Period" },
                values: new object[,]
                {
                    { 100, 1, 1, "200", 100, 202001 },
                    { 101, 1, 1, "200", 100, 202002 },
                    { 102, 1, 1, "200", 200, 202001 },
                    { 103, 1, 1, "200", 200, 202002 },
                    { 104, 1, 1, "200", 300, 202001 },
                    { 105, 1, 1, "200", 300, 202002 },
                    { 106, 1, 1, "200", 400, 202001 },
                    { 107, 1, 1, "200", 400, 202002 },
                    { 108, 1, 1, "200", 500, 202001 },
                    { 109, 1, 1, "200", 500, 202002 },
                    { 110, 2, 1, "200", 100, 202001 },
                    { 111, 2, 1, "200", 100, 202002 },
                    { 112, 2, 1, "200", 200, 202001 },
                    { 113, 2, 1, "200", 200, 202002 },
                    { 114, 2, 1, "200", 300, 202001 },
                    { 115, 2, 1, "200", 300, 202002 },
                    { 116, 2, 1, "200", 400, 202001 },
                    { 117, 2, 1, "200", 400, 202002 },
                    { 118, 2, 1, "200", 500, 202001 },
                    { 119, 2, 1, "200", 500, 202002 },
                    { 120, 3, 1, "200", 100, 202001 },
                    { 121, 3, 1, "200", 100, 202002 },
                    { 122, 3, 1, "200", 200, 202001 },
                    { 123, 3, 1, "200", 200, 202002 },
                    { 124, 3, 1, "200", 300, 202001 },
                    { 125, 3, 1, "200", 300, 202002 },
                    { 126, 3, 1, "200", 400, 202001 },
                    { 127, 3, 1, "200", 400, 202002 },
                    { 128, 3, 1, "200", 500, 202001 },
                    { 129, 3, 1, "200", 500, 202002 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 500);
        }
    }
}
