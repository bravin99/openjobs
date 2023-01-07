using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenJobs.Data.Migrations
{
    /// <inheritdoc />
    public partial class ResumeStorage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StoredResume",
                table: "JobApplications",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoredResume",
                table: "JobApplications");
        }
    }
}
