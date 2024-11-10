using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental.Migrations
{
    /// <inheritdoc />
    public partial class cartitemrepeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CarInCart",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarInCart",
                table: "Car");
        }
    }
}
