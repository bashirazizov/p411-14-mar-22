using Microsoft.EntityFrameworkCore.Migrations;

namespace vesper.Migrations
{
    public partial class testimonialseditesdeletred : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Testimonials");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
