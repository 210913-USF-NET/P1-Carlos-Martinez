﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class migrationTEST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TooBad",
                table: "StoreFronts",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TooBad",
                table: "StoreFronts");
        }
    }
}
