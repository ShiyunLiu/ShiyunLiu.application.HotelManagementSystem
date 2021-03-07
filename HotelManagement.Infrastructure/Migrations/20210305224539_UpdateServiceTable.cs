using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Infrastructure.Migrations
{
    public partial class UpdateServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SERVICES_ROOMS_RoomId",
                table: "SERVICES");

            migrationBuilder.DropIndex(
                name: "IX_SERVICES_RoomId",
                table: "SERVICES");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "SERVICES");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICES_ROOMNO",
                table: "SERVICES",
                column: "ROOMNO");

            migrationBuilder.AddForeignKey(
                name: "FK_SERVICES_ROOMS_ROOMNO",
                table: "SERVICES",
                column: "ROOMNO",
                principalTable: "ROOMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SERVICES_ROOMS_ROOMNO",
                table: "SERVICES");

            migrationBuilder.DropIndex(
                name: "IX_SERVICES_ROOMNO",
                table: "SERVICES");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "SERVICES",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SERVICES_RoomId",
                table: "SERVICES",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_SERVICES_ROOMS_RoomId",
                table: "SERVICES",
                column: "RoomId",
                principalTable: "ROOMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
