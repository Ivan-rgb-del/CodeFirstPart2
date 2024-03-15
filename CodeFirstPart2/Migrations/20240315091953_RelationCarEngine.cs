using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstPart2.Migrations
{
    /// <inheritdoc />
    public partial class RelationCarEngine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Engines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Engines_CarId",
                table: "Engines",
                column: "CarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_Cars_CarId",
                table: "Engines",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Cars_CarId",
                table: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_Engines_CarId",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Engines");
        }
    }
}
