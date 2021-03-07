using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Infrastructure.Migrations
{
    public partial class CustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROOMNO = table.Column<int>(type: "int", nullable: true),
                    CNAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PHONE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CHECKIN = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalPERSONS = table.Column<int>(type: "int", nullable: true),
                    BookingDays = table.Column<int>(type: "int", nullable: true),
                    ADVANCE = table.Column<decimal>(type: "Money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
