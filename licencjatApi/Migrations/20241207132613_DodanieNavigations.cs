using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace licencjatApi.Migrations
{
    /// <inheritdoc />
    public partial class DodanieNavigations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HostelCriterionValues_MountainHostelId",
                table: "HostelCriterionValues",
                column: "MountainHostelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HostelCriterionValues_Criteria_CriterionId",
                table: "HostelCriterionValues",
                column: "CriterionId",
                principalTable: "Criteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HostelCriterionValues_MountainHostels_MountainHostelId",
                table: "HostelCriterionValues",
                column: "MountainHostelId",
                principalTable: "MountainHostels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HostelCriterionValues_Criteria_CriterionId",
                table: "HostelCriterionValues");

            migrationBuilder.DropForeignKey(
                name: "FK_HostelCriterionValues_MountainHostels_MountainHostelId",
                table: "HostelCriterionValues");

            migrationBuilder.DropIndex(
                name: "IX_HostelCriterionValues_MountainHostelId",
                table: "HostelCriterionValues");
        }
    }
}
