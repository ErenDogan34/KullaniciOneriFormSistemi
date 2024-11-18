using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rannaSoftwareProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class formupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "SupportForms",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
