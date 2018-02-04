using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Extreme_Test.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    E1Id = table.Column<int>(type: "int", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkToE1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryMax = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SalaryMin = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Schedule = table.Column<int>(type: "int", nullable: false),
                    WorkingType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.E1Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacancies");
        }
    }
}
