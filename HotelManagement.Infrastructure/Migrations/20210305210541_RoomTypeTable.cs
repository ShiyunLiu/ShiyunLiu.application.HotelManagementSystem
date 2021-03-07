using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Infrastructure.Migrations
{
    public partial class RoomTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "ROOMS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ROOMTYPES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RTDESC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Rent = table.Column<decimal>(type: "Money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROOMTYPES", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ROOMS_ROOMTYPES_RoomTypeId",
                table: "ROOMS");

            migrationBuilder.DropTable(
                name: "ROOMTYPES");

            migrationBuilder.DropIndex(
                name: "IX_ROOMS_RoomTypeId",
                table: "ROOMS");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "ROOMS");
        }
    }
}
