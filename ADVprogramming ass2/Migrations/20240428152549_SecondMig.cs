using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADVprogramming_ass2.Migrations
{
    public partial class SecondMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Onsale",
                table: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Onsale",
                table: "Item",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
