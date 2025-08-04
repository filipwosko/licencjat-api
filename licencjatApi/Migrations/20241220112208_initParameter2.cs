using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace licencjatApi.Migrations
{
    /// <inheritdoc />
    public partial class initParameter2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Description", "Key", "Value" },
                values: new object[] { 1, "Nazwa metody używanej przez program", "MethodName", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
