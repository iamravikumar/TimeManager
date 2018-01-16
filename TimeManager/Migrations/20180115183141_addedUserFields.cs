using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimeManager.Migrations
{
    public partial class addedUserFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_AspNetUsers_AssignedToUserId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpending_AspNetUsers_WorkerUserId",
                table: "TimeSpending");

            migrationBuilder.DropIndex(
                name: "IX_TimeSpending_WorkerUserId",
                table: "TimeSpending");

            migrationBuilder.DropIndex(
                name: "IX_Task_AssignedToUserId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "WorkerUserId",
                table: "TimeSpending");

            migrationBuilder.DropColumn(
                name: "AssignedToUserId",
                table: "Task");

            migrationBuilder.AlterColumn<string>(
                name: "Worker",
                table: "TimeSpending",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssignedTo",
                table: "Task",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSpending_Worker",
                table: "TimeSpending",
                column: "Worker");

            migrationBuilder.CreateIndex(
                name: "IX_Task_AssignedTo",
                table: "Task",
                column: "AssignedTo");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_AspNetUsers_AssignedTo",
                table: "Task",
                column: "AssignedTo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpending_AspNetUsers_Worker",
                table: "TimeSpending",
                column: "Worker",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_AspNetUsers_AssignedTo",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSpending_AspNetUsers_Worker",
                table: "TimeSpending");

            migrationBuilder.DropIndex(
                name: "IX_TimeSpending_Worker",
                table: "TimeSpending");

            migrationBuilder.DropIndex(
                name: "IX_Task_AssignedTo",
                table: "Task");

            migrationBuilder.AlterColumn<string>(
                name: "Worker",
                table: "TimeSpending",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkerUserId",
                table: "TimeSpending",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssignedTo",
                table: "Task",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignedToUserId",
                table: "Task",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSpending_WorkerUserId",
                table: "TimeSpending",
                column: "WorkerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_AssignedToUserId",
                table: "Task",
                column: "AssignedToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_AspNetUsers_AssignedToUserId",
                table: "Task",
                column: "AssignedToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSpending_AspNetUsers_WorkerUserId",
                table: "TimeSpending",
                column: "WorkerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
