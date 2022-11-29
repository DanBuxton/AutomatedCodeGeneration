using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomatedCodeGeneration.DataLayer.Migrations;

public partial class AddedClassType : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "Type",
            table: "Classes",
            type: "int",
            nullable: false,
            defaultValue: 0);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Type",
            table: "Classes");
    }
}
