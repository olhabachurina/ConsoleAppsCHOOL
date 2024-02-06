using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsoleAppsCHOOL.Migrations
{
    /// <inheritdoc />
    public partial class i : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Mathematics Course", "Mathematics" },
                    { 2, "Physics Course", "Physics" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Alan", "Turing" },
                    { 2, "Grace", "Hopper" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe" },
                    { 2, new DateTime(1999, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "CourseId", "EnrollmentDate", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 6, 19, 53, 55, 481, DateTimeKind.Local).AddTicks(3533), 1 },
                    { 2, 2, new DateTime(2024, 2, 6, 19, 53, 55, 481, DateTimeKind.Local).AddTicks(3584), 2 },
                    { 3, 1, new DateTime(2024, 2, 6, 19, 53, 55, 481, DateTimeKind.Local).AddTicks(3588), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);
        }
    }
}
