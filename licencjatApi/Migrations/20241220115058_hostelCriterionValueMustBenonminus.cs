using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace licencjatApi.Migrations
{
    /// <inheritdoc />
    public partial class hostelCriterionValueMustBenonminus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_HostelCriterionValue_Value_NonNegative",
                table: "HostelCriterionValues",
                sql: "Value >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_HostelCriterionValue_Value_NonNegative",
                table: "HostelCriterionValues");
        }
    }
}
