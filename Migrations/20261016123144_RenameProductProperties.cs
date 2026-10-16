using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMonolithic.Migrations
{
    /// <inheritdoc />
    public partial class RenameProductProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Product",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "Product",
                newName: "DescriptionRecord");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Person",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Product",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "DescriptionRecord",
                table: "Product",
                newName: "ProductDescription");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Person",
                newName: "id");
        }
    }
}
