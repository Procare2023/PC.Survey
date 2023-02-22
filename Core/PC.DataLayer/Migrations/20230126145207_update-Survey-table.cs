using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC.DataLayer.Migrations
{
    public partial class updateSurveytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateStamp",
                table: "GeneralSurveyReport",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateStamp",
                table: "GeneralSurveyReport");
        }
    }
}
