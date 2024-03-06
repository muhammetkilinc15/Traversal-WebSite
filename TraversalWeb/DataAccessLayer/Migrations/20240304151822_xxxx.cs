using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class xxxx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationStatuses_StatusReservationStatusID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_StatusReservationStatusID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationStatus",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StatusReservationStatusID",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationStatus",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusReservationStatusID",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StatusReservationStatusID",
                table: "Reservations",
                column: "StatusReservationStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationStatuses_StatusReservationStatusID",
                table: "Reservations",
                column: "StatusReservationStatusID",
                principalTable: "ReservationStatuses",
                principalColumn: "ReservationStatusID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
