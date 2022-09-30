using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAuthorization.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "users",
                type: "TEXT",
                nullable: false,
                defaultValue: "Active",
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "Active");
        }
    }
}
