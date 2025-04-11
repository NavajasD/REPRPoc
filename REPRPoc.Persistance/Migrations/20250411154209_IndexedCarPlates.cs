using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REPRPoc.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class IndexedCarPlates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cars_Plate",
                table: "Cars",
                column: "Plate",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_Plate",
                table: "Cars");
        }
    }
}
