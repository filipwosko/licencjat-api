using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace licencjat_api.Migrations
{
    /// <inheritdoc />
    public partial class AddCriterionTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Criteria",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Criteria");
        }
    }
}
