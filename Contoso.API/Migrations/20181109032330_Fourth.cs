using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contoso.API.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 9, 6, 23, 29, 981, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 429, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sellers",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 9, 6, 23, 29, 985, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 444, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sales",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 9, 6, 23, 29, 987, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 450, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Operations",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 9, 6, 23, 29, 990, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 461, DateTimeKind.Local));

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 11, 9, 6, 23, 29, 992, DateTimeKind.Local)),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SellerId = table.Column<int>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    OperationType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_SellerId",
                table: "Reports",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 429, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 9, 6, 23, 29, 981, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sellers",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 444, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 9, 6, 23, 29, 985, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Sales",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 450, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 9, 6, 23, 29, 987, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Operations",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 6, 16, 13, 37, 461, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 9, 6, 23, 29, 990, DateTimeKind.Local));
        }
    }
}
