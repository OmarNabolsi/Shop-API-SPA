using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_Back.Migrations
{
    public partial class SeedCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO carts (UserId) VALUES(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
