using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace licencjatApi.Migrations
{
    /// <inheritdoc />
    public partial class DodanieUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HostelCriterionValues_Criteria_CriterionId",
                table: "HostelCriterionValues");

            migrationBuilder.DropForeignKey(
                name: "FK_HostelCriterionValues_MountainHostels_MountainHostelId",
                table: "HostelCriterionValues");

            migrationBuilder.DropIndex(
                name: "IX_HostelCriterionValues_CriterionId",
                table: "HostelCriterionValues");

            migrationBuilder.DropIndex(
                name: "IX_HostelCriterionValues_MountainHostelId",
                table: "HostelCriterionValues");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MountainHostels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_MountainHostels_Name",
                table: "MountainHostels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HostelCriterionValues_CriterionId_MountainHostelId",
                table: "HostelCriterionValues",
                columns: new[] { "CriterionId", "MountainHostelId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MountainHostels_Name",
                table: "MountainHostels");

            migrationBuilder.DropIndex(
                name: "IX_HostelCriterionValues_CriterionId_MountainHostelId",
                table: "HostelCriterionValues");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MountainHostels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_HostelCriterionValues_CriterionId",
                table: "HostelCriterionValues",
                column: "CriterionId");

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
    }
}
