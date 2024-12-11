using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CombatGame.Migrations
{
    public partial class CombatGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Battles",
                keyColumn: "Id",
                keyValue: 1,
                column: "BattleDate",
                value: new DateTime(2024, 12, 11, 6, 26, 29, 811, DateTimeKind.Local).AddTicks(1013));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Battles",
                keyColumn: "Id",
                keyValue: 1,
                column: "BattleDate",
                value: new DateTime(2024, 12, 11, 5, 44, 41, 244, DateTimeKind.Local).AddTicks(9297));
        }
    }
}
