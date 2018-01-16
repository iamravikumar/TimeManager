using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimeManager.Migrations
{
    public partial class decimalFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TimeSpent",
                table: "TimeSpending",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "TimeSpent",
                table: "TimeSpending",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
