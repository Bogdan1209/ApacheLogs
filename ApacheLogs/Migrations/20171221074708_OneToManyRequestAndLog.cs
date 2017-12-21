using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApacheLogs.Migrations
{
    public partial class OneToManyRequestAndLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Requests_LogFileId",
                table: "Requests");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_LogFileId",
                table: "Requests",
                column: "LogFileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Requests_LogFileId",
                table: "Requests");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_LogFileId",
                table: "Requests",
                column: "LogFileId",
                unique: true);
        }
    }
}
