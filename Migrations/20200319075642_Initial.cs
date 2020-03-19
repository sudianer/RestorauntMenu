using Microsoft.EntityFrameworkCore.Migrations;

namespace RestorauntMenu.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Ingredients = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    TimeToMake = table.Column<int>(nullable: false),
                    Img = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dish");
        }
    }
}
