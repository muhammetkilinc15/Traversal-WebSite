using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class update_Reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_AppUserId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Reservations",
                newName: "AppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_AppUserId",
                table: "Reservations",
                newName: "IX_Reservations_AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_AppUserID",
                table: "Reservations",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_AppUserID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "Reservations",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_AppUserID",
                table: "Reservations",
                newName: "IX_Reservations_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_AppUserId",
                table: "Reservations",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
