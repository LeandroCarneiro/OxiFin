using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace OxiFin.Data.Migrations
{
    public partial class AddingUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblDebtors_tblUsers_UserId",
                table: "tblDebtors");

            migrationBuilder.DropForeignKey(
                name: "FK_tblPayers_tblUsers_UserId",
                table: "tblPayers");

            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropIndex(
                name: "IX_tblPayers_UserId",
                table: "tblPayers");

            migrationBuilder.DropIndex(
                name: "IX_tblDebtors_UserId",
                table: "tblDebtors");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "tblPayments",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "tblBankAccounts",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "tblRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tblRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1L, "04a8fc4f-8f02-4cf0-8ef7-daca7c6b2a0b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "tblRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2L, "0d3c74de-a585-4d83-aa04-a3a6dea1858a", "Visitor", "VISITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblRoles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tblPayments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tblBankAccounts");

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPayers_UserId",
                table: "tblPayers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDebtors_UserId",
                table: "tblDebtors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblDebtors_tblUsers_UserId",
                table: "tblDebtors",
                column: "UserId",
                principalTable: "tblUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblPayers_tblUsers_UserId",
                table: "tblPayers",
                column: "UserId",
                principalTable: "tblUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
