using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADVprogramming_ass2.Migrations
{
    public partial class firstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Item_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Item_Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Item_Type = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    QuantSold = table.Column<int>(type: "int", nullable: false),
                    Price_Pound = table.Column<float>(type: "real", nullable: false),
                    Onsale = table.Column<bool>(type: "bit", nullable: false),
                    Item_description = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Item_Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Name",
                columns: table => new
                {
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    User_Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Use_Age = table.Column<int>(type: "int", nullable: false),
                    Loyalty_Card = table.Column<bool>(type: "bit", nullable: false),
                    Staff_Member = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Name", x => x.User_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "User_Name");
        }
    }
}
