using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DinnerClub.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Familys_FamilyID",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Familys",
                table: "Familys");

            migrationBuilder.RenameTable(
                name: "Familys",
                newName: "Families");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Families",
                table: "Families",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Families_FamilyID",
                table: "People",
                column: "FamilyID",
                principalTable: "Families",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Families_FamilyID",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Families",
                table: "Families");

            migrationBuilder.RenameTable(
                name: "Families",
                newName: "Familys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Familys",
                table: "Familys",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Familys_FamilyID",
                table: "People",
                column: "FamilyID",
                principalTable: "Familys",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
