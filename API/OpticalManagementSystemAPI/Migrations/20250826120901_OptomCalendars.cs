using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticalManagementSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class OptomCalendars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_OptomCalendar_CalendarId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_OptomCalendar_Optometrists_OptomId",
                table: "OptomCalendar");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_OptomCalendar_OptomCalendarId",
                table: "WorkingHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OptomCalendar",
                table: "OptomCalendar");

            migrationBuilder.DropColumn(
                name: "CalenderId",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "OptomCalendar",
                newName: "OptomCalenders");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Appointments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_OptomCalendar_OptomId",
                table: "OptomCalenders",
                newName: "IX_OptomCalenders_OptomId");

            migrationBuilder.AlterColumn<int>(
                name: "CalendarId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptomCalenders",
                table: "OptomCalenders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_OptomCalenders_CalendarId",
                table: "Appointments",
                column: "CalendarId",
                principalTable: "OptomCalenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptomCalenders_Optometrists_OptomId",
                table: "OptomCalenders",
                column: "OptomId",
                principalTable: "Optometrists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_OptomCalenders_OptomCalendarId",
                table: "WorkingHours",
                column: "OptomCalendarId",
                principalTable: "OptomCalenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_OptomCalenders_CalendarId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_OptomCalenders_Optometrists_OptomId",
                table: "OptomCalenders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_OptomCalenders_OptomCalendarId",
                table: "WorkingHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OptomCalenders",
                table: "OptomCalenders");

            migrationBuilder.RenameTable(
                name: "OptomCalenders",
                newName: "OptomCalendar");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Appointments",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_OptomCalenders_OptomId",
                table: "OptomCalendar",
                newName: "IX_OptomCalendar_OptomId");

            migrationBuilder.AlterColumn<int>(
                name: "CalendarId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CalenderId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptomCalendar",
                table: "OptomCalendar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_OptomCalendar_CalendarId",
                table: "Appointments",
                column: "CalendarId",
                principalTable: "OptomCalendar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OptomCalendar_Optometrists_OptomId",
                table: "OptomCalendar",
                column: "OptomId",
                principalTable: "Optometrists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_OptomCalendar_OptomCalendarId",
                table: "WorkingHours",
                column: "OptomCalendarId",
                principalTable: "OptomCalendar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
