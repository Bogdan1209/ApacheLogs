using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApacheLogs.Migrations
{
    public partial class FixNameRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Requests_RequestId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_RequestId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "DownloadedFileId",
                table: "Requests",
                newName: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_FileId",
                table: "Requests",
                column: "FileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Files_FileId",
                table: "Requests",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Files_FileId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_FileId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "Requests",
                newName: "DownloadedFileId");

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Files",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_RequestId",
                table: "Files",
                column: "RequestId",
                unique: true,
                filter: "[RequestId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Requests_RequestId",
                table: "Files",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
