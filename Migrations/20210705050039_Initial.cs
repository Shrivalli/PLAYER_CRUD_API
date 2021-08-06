using Microsoft.EntityFrameworkCore.Migrations;

namespace API_CRUD.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    P_Jno = table.Column<int>(type: "int", nullable: false),
                    P_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P_Age = table.Column<int>(type: "int", nullable: false),
                    P_Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.P_Jno);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
