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
                name: "password_salt",
                table: "account",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8mb3_unicode_ci")
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.AddColumn<string>(
                name: "password_v2",
                table: "account",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                collation: "utf8mb3_unicode_ci")
                .Annotation("MySql:CharSet", "utf8mb3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_salt",
                table: "account");

            migrationBuilder.DropColumn(
                name: "password_v2",
                table: "account");
        }
    }
}
