using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasteTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TipoFeedbackMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoFeedback",
                table: "Feedback",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoFeedback",
                table: "Feedback");
        }
    }
}
