using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BasicBilling.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Charge = table.Column<string>(type: "TEXT", nullable: false),
                    Period = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    BillingCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    BillingStatusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Billings_BillingCategories_BillingCategoryId",
                        column: x => x.BillingCategoryId,
                        principalTable: "BillingCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Billings_BillingStatus_BillingStatusId",
                        column: x => x.BillingStatusId,
                        principalTable: "BillingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Billings_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BillingCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "WATER" },
                    { 2, "ELECTRICITY" },
                    { 3, "SEWER" }
                });

            migrationBuilder.InsertData(
                table: "BillingStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Paid" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Billings_BillingCategoryId",
                table: "Billings",
                column: "BillingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_BillingStatusId",
                table: "Billings",
                column: "BillingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_ClientId",
                table: "Billings",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropTable(
                name: "BillingCategories");

            migrationBuilder.DropTable(
                name: "BillingStatus");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
