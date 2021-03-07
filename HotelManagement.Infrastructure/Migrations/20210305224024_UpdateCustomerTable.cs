using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Infrastructure.Migrations
{
    public partial class UpdateCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUSTOMERS_ROOMS_RoomId",
                table: "CUSTOMERS");

            migrationBuilder.DropIndex(
                name: "IX_CUSTOMERS_RoomId",
                table: "CUSTOMERS");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "CUSTOMERS");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_ROOMNO",
                table: "CUSTOMERS",
                column: "ROOMNO");

            migrationBuilder.AddForeignKey(
                name: "FK_CUSTOMERS_ROOMS_ROOMNO",
                table: "CUSTOMERS",
                column: "ROOMNO",
                principalTable: "ROOMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUSTOMERS_ROOMS_ROOMNO",
                table: "CUSTOMERS");

            migrationBuilder.DropIndex(
                name: "IX_CUSTOMERS_ROOMNO",
                table: "CUSTOMERS");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "CUSTOMERS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_RoomId",
                table: "CUSTOMERS",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_CUSTOMERS_ROOMS_RoomId",
                table: "CUSTOMERS",
                column: "RoomId",
                principalTable: "ROOMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
