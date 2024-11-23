using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace question.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "jobs",
                newName: "company");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "company",
                table: "jobs",
                newName: "status");
        }
    }
}
