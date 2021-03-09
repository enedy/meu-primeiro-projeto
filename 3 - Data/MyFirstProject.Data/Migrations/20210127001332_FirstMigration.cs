using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFirstProject.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    EmailAdress = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Number = table.Column<string>(type: "VARCHAR(14)", nullable: true),
                    DocumentType = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "INT", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "idx_user_name",
                table: "User",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "idx_user_name_status",
                table: "User",
                columns: new[] { "Name", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Number",
                table: "User",
                column: "Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
