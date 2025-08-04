using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace licencjatApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCriterionValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HostelCriterionValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MountainHostelId = table.Column<int>(type: "int", nullable: false),
                    CriterionId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostelCriterionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HostelCriterionValues_Criteria_CriterionId",
                        column: x => x.CriterionId,
                        principalTable: "Criteria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostelCriterionValues_MountainHostels_MountainHostelId",
                        column: x => x.MountainHostelId,
                        principalTable: "MountainHostels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HostelCriterionValues_CriterionId",
                table: "HostelCriterionValues",
                column: "CriterionId");

            migrationBuilder.CreateIndex(
                name: "IX_HostelCriterionValues_MountainHostelId",
                table: "HostelCriterionValues",
                column: "MountainHostelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HostelCriterionValues");
        }
    }
}
