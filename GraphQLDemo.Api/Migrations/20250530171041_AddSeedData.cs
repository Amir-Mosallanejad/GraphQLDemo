using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLDemo.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "Salary" },
                values: new object[] { new Guid("5ed6729c-6d82-428e-809a-0fe47cf48168"), "SomeInstructorFirstname", "SomeInstructorLastname", 1.2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("5ed6729c-6d82-428e-809a-0fe47cf48168"));
        }
    }
}
