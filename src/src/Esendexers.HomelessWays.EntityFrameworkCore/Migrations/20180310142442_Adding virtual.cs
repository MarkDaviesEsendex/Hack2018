using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Esendexers.HomelessWays.Migrations
{
    public partial class Addingvirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PositivitySentimentScore",
                table: "Incidents",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "PositivitySentimentScore",
                table: "Incidents",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
