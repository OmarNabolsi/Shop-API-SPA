using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_Back.Migrations
{
    public partial class SeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Users(Name, Email) VALUES ('Omar', 'test@test.com')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Users WHERE User.Name = 'Omar'");
        }
    }
}
