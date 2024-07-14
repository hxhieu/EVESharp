using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVESharp.Database.Entity.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountPasswordV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password_v2",
                table: "account",
                type: "varchar(80)",
                maxLength: 80,
                nullable: true,
                collation: "utf8mb3_unicode_ci")
                .Annotation("MySql:CharSet", "utf8mb3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_v2",
                table: "account");
        }
    }
}
