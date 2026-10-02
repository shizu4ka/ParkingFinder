using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpaces_Cars_CarId",
                table: "ParkingSpaces");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSpaces_CarId",
                table: "ParkingSpaces");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarId",
                table: "Users",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CarId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpaces_CarId",
                table: "ParkingSpaces",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpaces_Cars_CarId",
                table: "ParkingSpaces",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
