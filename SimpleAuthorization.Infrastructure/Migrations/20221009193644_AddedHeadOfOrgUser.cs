using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAuthorization.Infrastructure.Migrations
{
    public partial class AddedHeadOfOrgUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "head_of_org_user_id",
                table: "organizations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "ix_organizations_head_of_org_user_id",
                table: "organizations",
                column: "head_of_org_user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_organizations_users_head_of_org_user_id1",
                table: "organizations",
                column: "head_of_org_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_organizations_users_head_of_org_user_id1",
                table: "organizations");

            migrationBuilder.DropIndex(
                name: "ix_organizations_head_of_org_user_id",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "head_of_org_user_id",
                table: "organizations");
        }
    }
}
