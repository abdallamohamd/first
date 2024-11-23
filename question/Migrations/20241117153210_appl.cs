using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace question.Migrations
{
    /// <inheritdoc />
    public partial class appl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notes_AspNetUsers_applicant_name",
                table: "notes");

            migrationBuilder.DropForeignKey(
                name: "FK_notes_jobs_job_id",
                table: "notes");

            migrationBuilder.DropIndex(
                name: "IX_notes_applicant_name",
                table: "notes");

            migrationBuilder.DropIndex(
                name: "IX_notes_job_id",
                table: "notes");

            migrationBuilder.DropColumn(
                name: "job_id",
                table: "notes");

            migrationBuilder.DropColumn(
                name: "status",
                table: "notes");

            migrationBuilder.AlterColumn<string>(
                name: "applicant_name",
                table: "notes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "applicationid",
                table: "notes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_notes_applicationid",
                table: "notes",
                column: "applicationid");

            migrationBuilder.AddForeignKey(
                name: "FK_notes_applications_applicationid",
                table: "notes",
                column: "applicationid",
                principalTable: "applications",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notes_applications_applicationid",
                table: "notes");

            migrationBuilder.DropIndex(
                name: "IX_notes_applicationid",
                table: "notes");

            migrationBuilder.DropColumn(
                name: "applicationid",
                table: "notes");

            migrationBuilder.AlterColumn<string>(
                name: "applicant_name",
                table: "notes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "job_id",
                table: "notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_notes_applicant_name",
                table: "notes",
                column: "applicant_name");

            migrationBuilder.CreateIndex(
                name: "IX_notes_job_id",
                table: "notes",
                column: "job_id");

            migrationBuilder.AddForeignKey(
                name: "FK_notes_AspNetUsers_applicant_name",
                table: "notes",
                column: "applicant_name",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notes_jobs_job_id",
                table: "notes",
                column: "job_id",
                principalTable: "jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
