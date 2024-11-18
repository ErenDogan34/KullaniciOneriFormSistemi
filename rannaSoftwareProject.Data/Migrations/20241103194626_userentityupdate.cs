using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rannaSoftwareProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class userentityupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserKey",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
