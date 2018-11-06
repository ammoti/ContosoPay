using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contoso.API.Migrations
{
    public partial class FinalVerso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 429, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 974, DateTimeKind.Local));

            migrationBuilder.AlterColumn<int>(
                name: "MinRange",
                table: "Sellers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxRange",
                table: "Sellers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sellers",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 444, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 980, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sales",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 450, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 981, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Operations",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 461, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 985, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 974, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 429, DateTimeKind.Local));

            migrationBuilder.AlterColumn<string>(
                name: "MinRange",
                table: "Sellers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "MaxRange",
                table: "Sellers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sellers",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 980, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 444, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sales",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 981, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 450, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Operations",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 15, 56, 42, 985, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 461, DateTimeKind.Local));
        }
    }
}
