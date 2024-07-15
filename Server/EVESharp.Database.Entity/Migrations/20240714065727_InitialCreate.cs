using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVESharp.Database.Entity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           // Intentionally blank as we don't want to create the DB while it's already existed
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Intentionally blank as we don't want to create the DB while it's already existed 
        }
    }
}
