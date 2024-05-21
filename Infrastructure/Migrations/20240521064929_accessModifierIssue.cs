using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class accessModifierIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Couriers_AdminId",
                table: "Couriers",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Couriers_Admins_AdminId",
                table: "Couriers",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Couriers_Admins_AdminId",
                table: "Couriers");

            migrationBuilder.DropIndex(
                name: "IX_Couriers_AdminId",
                table: "Couriers");
        }
    }
}
