﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddChoreStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Chores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Chores");
        }
    }
}
