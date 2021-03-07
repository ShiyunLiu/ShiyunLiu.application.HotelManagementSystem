using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Infrastructure.Migrations
{
    public partial class RoomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "CUSTOMERS");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "CUSTOMERS",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CUSTOMERS",
                table: "CUSTOMERS",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ROOMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RTCODE = table.Column<int>(type: "int", nullable: true),
                    STATUS = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROOMS", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUSTOMERS_ROOMS_RoomId",
                table: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "ROOMS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CUSTOMERS",
                table: "CUSTOMERS");

            migrationBuilder.DropIndex(
                name: "IX_CUSTOMERS_RoomId",
                table: "CUSTOMERS");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "CUSTOMERS");

            migrationBuilder.RenameTable(
                name: "CUSTOMERS",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");
        }
    }
}
