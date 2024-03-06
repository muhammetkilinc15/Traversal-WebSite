using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateReservationStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationStatuses_Reservations_ReservationId",
                table: "ReservationStatuses");

            migrationBuilder.DropIndex(
                name: "IX_ReservationStatuses_ReservationId",
                table: "ReservationStatuses");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "ReservationStatuses");

            migrationBuilder.AddColumn<int>(
                name: "ReservationStatus",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StatusId",
                table: "Reservations",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationStatuses_StatusId",
                table: "Reservations",
                column: "StatusId",
                principalTable: "ReservationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationStatuses_StatusId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_StatusId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationStatus",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "ReservationStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationStatuses_ReservationId",
                table: "ReservationStatuses",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationStatuses_Reservations_ReservationId",
                table: "ReservationStatuses",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
