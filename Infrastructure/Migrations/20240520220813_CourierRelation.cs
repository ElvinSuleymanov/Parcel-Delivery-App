using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CourierRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourierOrders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CourierId",
                table: "Orders",
                column: "CourierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Couriers_CourierId",
                table: "Orders",
                column: "CourierId",
                principalTable: "Couriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Couriers_CourierId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CourierId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "CourierOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourierId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierOrders_Couriers_CourierId",
                        column: x => x.CourierId,
                        principalTable: "Couriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourierOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CourierOrders_CourierId",
                table: "CourierOrders",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierOrders_OrderId",
                table: "CourierOrders",
                column: "OrderId");
        }
    }
}
