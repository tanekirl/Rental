using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental.Migrations
{
    /// <inheritdoc />
    public partial class AddCarImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Category_categoryID",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "horsePower",
                table: "Car",
                newName: "horsepower");

            migrationBuilder.RenameColumn(
                name: "categoryID",
                table: "Car",
                newName: "Categoryid");

            migrationBuilder.RenameColumn(
                name: "transmissionType",
                table: "Car",
                newName: "transmission");

            migrationBuilder.RenameColumn(
                name: "seats",
                table: "Car",
                newName: "seatingCapacity");

            migrationBuilder.RenameColumn(
                name: "engineVolume",
                table: "Car",
                newName: "engineDisplacement");

            migrationBuilder.RenameIndex(
                name: "IX_Car_categoryID",
                table: "Car",
                newName: "IX_Car_Categoryid");

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CarImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarImages_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarId",
                table: "CarImages",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Category_Categoryid",
                table: "Car",
                column: "Categoryid",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Category_Categoryid",
                table: "Car");

            migrationBuilder.DropTable(
                name: "CarImages");

            migrationBuilder.DropColumn(
                name: "color",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "horsepower",
                table: "Car",
                newName: "horsePower");

            migrationBuilder.RenameColumn(
                name: "Categoryid",
                table: "Car",
                newName: "categoryID");

            migrationBuilder.RenameColumn(
                name: "transmission",
                table: "Car",
                newName: "transmissionType");

            migrationBuilder.RenameColumn(
                name: "seatingCapacity",
                table: "Car",
                newName: "seats");

            migrationBuilder.RenameColumn(
                name: "engineDisplacement",
                table: "Car",
                newName: "engineVolume");

            migrationBuilder.RenameIndex(
                name: "IX_Car_Categoryid",
                table: "Car",
                newName: "IX_Car_categoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Category_categoryID",
                table: "Car",
                column: "categoryID",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
