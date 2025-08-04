using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace licencjatApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintToCriterion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Criteria",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_Name",
                table: "Criteria",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Criteria_Name",
                table: "Criteria");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Criteria",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
