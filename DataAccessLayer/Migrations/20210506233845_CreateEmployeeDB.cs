using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class CreateEmployeeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    job_title = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    is_online = table.Column<bool>(type: "bit", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true),
                    target = table.Column<int>(type: "int", nullable: true),
                    budget = table.Column<int>(type: "int", nullable: true),
                    phone = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "nchar(500)", fixedLength: true, maxLength: 500, nullable: true),
                    img_id = table.Column<int>(type: "int", nullable: true),
                    gender = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
