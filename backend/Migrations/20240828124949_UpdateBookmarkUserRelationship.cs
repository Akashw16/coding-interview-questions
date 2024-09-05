using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingInterviewQuestionsApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookmarkUserRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Questions",
                newName: "QuestionText");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Questions",
                newName: "CodeSnippet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionText",
                table: "Questions",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CodeSnippet",
                table: "Questions",
                newName: "Code");
        }
    }
}
