using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REPRPoc.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddedSoftDeleteToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cars",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("8bd7635e-d72a-4d63-b209-be88c72448e7"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e9b22bae-3afd-43e5-b739-174f74523055"),
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cars");
        }
    }
}
