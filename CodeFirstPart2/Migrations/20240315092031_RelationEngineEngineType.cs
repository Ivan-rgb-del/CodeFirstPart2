using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstPart2.Migrations
{
    /// <inheritdoc />
    public partial class RelationEngineEngineType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EngineTypeId",
                table: "Engines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Engines_EngineTypeId",
                table: "Engines",
                column: "EngineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_EngineTypes_EngineTypeId",
                table: "Engines",
                column: "EngineTypeId",
                principalTable: "EngineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engines_EngineTypes_EngineTypeId",
                table: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_Engines_EngineTypeId",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "EngineTypeId",
                table: "Engines");
        }
    }
}
