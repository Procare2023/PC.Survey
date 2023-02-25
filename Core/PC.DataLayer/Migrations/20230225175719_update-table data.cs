using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC.DataLayer.Migrations
{
    public partial class updatetabledata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "GeneralSurveyReport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                table: "GeneralSurveyReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "GeneralSurveyReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MRN",
                table: "GeneralSurveyReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "GeneralSurveyReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "GeneralSurveyReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "GeneralSurveyReport",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "MRN",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "GeneralSurveyReport");
        }
    }
}
