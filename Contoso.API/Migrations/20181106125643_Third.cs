using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contoso.API.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessType",
                table: "Sales");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 974, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 578, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sellers",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 980, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 584, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sales",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 981, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 585, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Operations",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 985, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 595, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 578, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 974, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sellers",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 584, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 980, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sales",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 585, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 981, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "ProcessType",
                table: "Sales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Operations",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 595, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 985, DateTimeKind.Local));
        }
    }
}
