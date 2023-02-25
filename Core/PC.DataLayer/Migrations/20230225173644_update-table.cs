using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC.DataLayer.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "DoctorSubAnswer",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "NursesAndStaffSubAnswer",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "OverallSubAnswer",
                table: "GeneralSurveyReport");

            migrationBuilder.RenameColumn(
                name: "complainOrFeedback",
                table: "GeneralSurveyReport",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "Specialty",
                table: "GeneralSurveyReport",
                newName: "UrlOriginal");

            migrationBuilder.RenameColumn(
                name: "ReceptionStaffSubAnswer",
                table: "GeneralSurveyReport",
                newName: "CreatedById");

            migrationBuilder.RenameColumn(
                name: "ReceptionStaffComment",
                table: "GeneralSurveyReport",
                newName: "UrlBitly");

            migrationBuilder.RenameColumn(
                name: "PatientName",
                table: "GeneralSurveyReport",
                newName: "ReceptionStaffSatisfiedComment");

            migrationBuilder.RenameColumn(
                name: "OverallComment",
                table: "GeneralSurveyReport",
                newName: "ReceptionStaffNotSatisfiedComment");

            migrationBuilder.RenameColumn(
                name: "NursesAndStaffComment",
                table: "GeneralSurveyReport",
                newName: "OverallSatisfiedComment");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "GeneralSurveyReport",
                newName: "OverallNotSatisfiedComment");

            migrationBuilder.RenameColumn(
                name: "MRN",
                table: "GeneralSurveyReport",
                newName: "NursesAndStaffSatisfiedComment");

            migrationBuilder.RenameColumn(
                name: "InsuranceProvider",
                table: "GeneralSurveyReport",
                newName: "NursesAndStaffNotSatisfiedComment");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "GeneralSurveyReport",
                newName: "DoctorSatisfiedComment");

            migrationBuilder.RenameColumn(
                name: "DoctorComment",
                table: "GeneralSurveyReport",
                newName: "DoctorNotSatisfiedComment");

            migrationBuilder.AddColumn<long>(
                name: "CreateTimeTick",
                table: "GeneralSurveyReport",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorSurveyReason",
                table: "GeneralSurveyReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoctorSurveySatisfiedReason",
                table: "GeneralSurveyReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeneralSurveyReason",
                table: "GeneralSurveyReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeneralSurveySatisfiedReason",
                table: "GeneralSurveyReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NursesAndStaffReason",
                table: "GeneralSurveyReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NursesAndStaffSatisfiedReason",
                table: "GeneralSurveyReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReceptionStaffNotSatisfied",
                table: "GeneralSurveyReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReceptionStaffSatisfied",
                table: "GeneralSurveyReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "complainFeedbacks",
                table: "GeneralSurveyReport",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTimeTick",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "DoctorSurveyReason",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "DoctorSurveySatisfiedReason",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "GeneralSurveyReason",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "GeneralSurveySatisfiedReason",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "NursesAndStaffReason",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "NursesAndStaffSatisfiedReason",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "ReceptionStaffNotSatisfied",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "ReceptionStaffSatisfied",
                table: "GeneralSurveyReport");

            migrationBuilder.DropColumn(
                name: "complainFeedbacks",
                table: "GeneralSurveyReport");

            migrationBuilder.RenameColumn(
                name: "UrlOriginal",
                table: "GeneralSurveyReport",
                newName: "Specialty");

            migrationBuilder.RenameColumn(
                name: "UrlBitly",
                table: "GeneralSurveyReport",
                newName: "ReceptionStaffComment");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                table: "GeneralSurveyReport",
                newName: "complainOrFeedback");

            migrationBuilder.RenameColumn(
                name: "ReceptionStaffSatisfiedComment",
                table: "GeneralSurveyReport",
                newName: "PatientName");

            migrationBuilder.RenameColumn(
                name: "ReceptionStaffNotSatisfiedComment",
                table: "GeneralSurveyReport",
                newName: "OverallComment");

            migrationBuilder.RenameColumn(
                name: "OverallSatisfiedComment",
                table: "GeneralSurveyReport",
                newName: "NursesAndStaffComment");

            migrationBuilder.RenameColumn(
                name: "OverallNotSatisfiedComment",
                table: "GeneralSurveyReport",
                newName: "Mobile");

            migrationBuilder.RenameColumn(
                name: "NursesAndStaffSatisfiedComment",
                table: "GeneralSurveyReport",
                newName: "MRN");

            migrationBuilder.RenameColumn(
                name: "NursesAndStaffNotSatisfiedComment",
                table: "GeneralSurveyReport",
                newName: "InsuranceProvider");

            migrationBuilder.RenameColumn(
                name: "DoctorSatisfiedComment",
                table: "GeneralSurveyReport",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "DoctorNotSatisfiedComment",
                table: "GeneralSurveyReport",
                newName: "DoctorComment");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "GeneralSurveyReport",
                newName: "ReceptionStaffSubAnswer");

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

            migrationBuilder.AddColumn<int>(
                name: "DoctorSubAnswer",
                table: "GeneralSurveyReport",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NursesAndStaffSubAnswer",
                table: "GeneralSurveyReport",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OverallSubAnswer",
                table: "GeneralSurveyReport",
                type: "int",
                nullable: true);
        }
    }
}
