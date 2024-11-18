using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rannaSoftwareProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class formentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserKey",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
