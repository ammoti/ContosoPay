﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contoso.API.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 578, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 3, 19, 1, 42, 619, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sellers",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 584, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 3, 19, 1, 42, 623, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sales",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 585, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 3, 19, 1, 42, 625, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Operations",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 595, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 3, 19, 1, 42, 628, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 3, 19, 1, 42, 619, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 578, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sellers",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 3, 19, 1, 42, 623, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 584, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sales",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 3, 19, 1, 42, 625, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 585, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Operations",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 3, 19, 1, 42, 628, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 4, 15, 31, 4, 595, DateTimeKind.Local));
        }
    }
}
