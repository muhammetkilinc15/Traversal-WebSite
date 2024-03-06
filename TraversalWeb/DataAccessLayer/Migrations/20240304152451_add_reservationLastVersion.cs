using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_reservationLastVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationStatusID",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReservationStatuses",
                columns: table => new
                {
                    ReservationStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatuses", x => x.ReservationStatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationStatusID",
                table: "Reservations",
                column: "ReservationStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationStatuses_ReservationStatusID",
                table: "Reservations",
                column: "ReservationStatusID",
                principalTable: "ReservationStatuses",
                principalColumn: "ReservationStatusID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationStatuses_ReservationStatusID",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "ReservationStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationStatusID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationStatusID",
                table: "Reservations");
        }
    }
}
