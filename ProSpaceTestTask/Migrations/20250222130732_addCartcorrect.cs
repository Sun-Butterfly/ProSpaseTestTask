using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSpaceTestTask.Migrations
{
    /// <inheritdoc />
    public partial class addCartcorrect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Carts_Id",
                table: "Customers");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Customers_Id",
                table: "Carts",
                column: "Id",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_Id",
                table: "Carts");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Carts_Id",
                table: "Customers",
                column: "Id",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
