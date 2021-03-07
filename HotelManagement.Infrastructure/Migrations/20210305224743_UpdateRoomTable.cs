using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Infrastructure.Migrations
{
    public partial class UpdateRoomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ROOMS_ROOMTYPES_RoomTypeId",
                table: "ROOMS");

            migrationBuilder.DropIndex(
                name: "IX_ROOMS_RoomTypeId",
                table: "ROOMS");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "ROOMS");

            migrationBuilder.CreateIndex(
                name: "IX_ROOMS_RTCODE",
                table: "ROOMS",
                column: "RTCODE");

            migrationBuilder.AddForeignKey(
                name: "FK_ROOMS_ROOMTYPES_RTCODE",
                table: "ROOMS",
                column: "RTCODE",
                principalTable: "ROOMTYPES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ROOMS_ROOMTYPES_RTCODE",
                table: "ROOMS");

            migrationBuilder.DropIndex(
                name: "IX_ROOMS_RTCODE",
                table: "ROOMS");

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "ROOMS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ROOMS_RoomTypeId",
                table: "ROOMS",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ROOMS_ROOMTYPES_RoomTypeId",
                table: "ROOMS",
                column: "RoomTypeId",
                principalTable: "ROOMTYPES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
