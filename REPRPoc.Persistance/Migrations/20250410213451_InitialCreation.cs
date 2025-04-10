using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace REPRPoc.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Plate = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Maker = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Model = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Color = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Created", "LastModified", "LastModifiedBy", "Maker", "Model", "Plate" },
                values: new object[,]
                {
                    { new Guid("8bd7635e-d72a-4d63-b209-be88c72448e7"), "Blue", new DateTime(2025, 4, 10, 18, 27, 37, 0, DateTimeKind.Utc), null, new Guid("71f94b6f-696c-4d10-9494-7185b7dba713"), "Honda", "Civic", "XYZ-5678" },
                    { new Guid("e9b22bae-3afd-43e5-b739-174f74523055"), "Red", new DateTime(2025, 4, 10, 18, 27, 37, 0, DateTimeKind.Utc), null, new Guid("71f94b6f-696c-4d10-9494-7185b7dba713"), "Toyota", "Corolla", "ABC-1234" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
