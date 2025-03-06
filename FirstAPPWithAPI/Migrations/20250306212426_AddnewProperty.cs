using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddnewProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isQualified",
                schema: "Mov",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isQualified",
                schema: "Mov",
                table: "Movies");
        }
    }
}
