using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrCdse",
                table: "Products",
                newName: "UseRestriction");            

            migrationBuilder.AddColumn<float>(
                name: "Concentration",
                table: "Products",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "FisicForm",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stripe",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concentration",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FisicForm",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Stripe",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UseRestriction",
                table: "Products",
                newName: "PrCdse");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Syncronization",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 556, DateTimeKind.Unspecified).AddTicks(5388), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 335, DateTimeKind.Unspecified).AddTicks(742), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Syncronization",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 545, DateTimeKind.Unspecified).AddTicks(1109), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 323, DateTimeKind.Unspecified).AddTicks(8875), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Supplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 855, DateTimeKind.Unspecified).AddTicks(2061), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 615, DateTimeKind.Unspecified).AddTicks(7045), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Supplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 855, DateTimeKind.Unspecified).AddTicks(1402), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 615, DateTimeKind.Unspecified).AddTicks(6424), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "StockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 848, DateTimeKind.Unspecified).AddTicks(8312), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 609, DateTimeKind.Unspecified).AddTicks(3662), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "StockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 848, DateTimeKind.Unspecified).AddTicks(7741), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 609, DateTimeKind.Unspecified).AddTicks(3145), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "StockChange",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 847, DateTimeKind.Unspecified).AddTicks(6147), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 608, DateTimeKind.Unspecified).AddTicks(3049), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "StockChange",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 847, DateTimeKind.Unspecified).AddTicks(5631), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 608, DateTimeKind.Unspecified).AddTicks(2579), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductSupplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 960, DateTimeKind.Unspecified).AddTicks(7394), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 716, DateTimeKind.Unspecified).AddTicks(3538), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductSupplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 960, DateTimeKind.Unspecified).AddTicks(6705), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 716, DateTimeKind.Unspecified).AddTicks(2981), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductStockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 959, DateTimeKind.Unspecified).AddTicks(6376), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 715, DateTimeKind.Unspecified).AddTicks(3412), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductStockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 959, DateTimeKind.Unspecified).AddTicks(5616), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 715, DateTimeKind.Unspecified).AddTicks(2802), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductShelfLife",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 959, DateTimeKind.Unspecified).AddTicks(181), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 714, DateTimeKind.Unspecified).AddTicks(6220), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductShelfLife",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 958, DateTimeKind.Unspecified).AddTicks(9668), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 714, DateTimeKind.Unspecified).AddTicks(5543), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 956, DateTimeKind.Unspecified).AddTicks(1063), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 711, DateTimeKind.Unspecified).AddTicks(8752), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 956, DateTimeKind.Unspecified).AddTicks(549), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 711, DateTimeKind.Unspecified).AddTicks(8292), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductPrice",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 958, DateTimeKind.Unspecified).AddTicks(4045), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 713, DateTimeKind.Unspecified).AddTicks(9592), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductPrice",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 958, DateTimeKind.Unspecified).AddTicks(3487), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 713, DateTimeKind.Unspecified).AddTicks(9079), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductMedia",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 957, DateTimeKind.Unspecified).AddTicks(3708), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 713, DateTimeKind.Unspecified).AddTicks(463), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductMedia",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 957, DateTimeKind.Unspecified).AddTicks(3152), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 712, DateTimeKind.Unspecified).AddTicks(9918), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductCategory",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 948, DateTimeKind.Unspecified).AddTicks(5529), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 704, DateTimeKind.Unspecified).AddTicks(5229), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductCategory",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 948, DateTimeKind.Unspecified).AddTicks(4928), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 704, DateTimeKind.Unspecified).AddTicks(4607), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "POSOrderItem",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 868, DateTimeKind.Unspecified).AddTicks(5227), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 628, DateTimeKind.Unspecified).AddTicks(2571), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "POSOrderItem",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 868, DateTimeKind.Unspecified).AddTicks(4580), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 628, DateTimeKind.Unspecified).AddTicks(2014), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "POSOrder",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 864, DateTimeKind.Unspecified).AddTicks(2882), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 624, DateTimeKind.Unspecified).AddTicks(1752), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "POSOrder",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 864, DateTimeKind.Unspecified).AddTicks(2291), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 624, DateTimeKind.Unspecified).AddTicks(1163), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "MediaResource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 869, DateTimeKind.Unspecified).AddTicks(340), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 628, DateTimeKind.Unspecified).AddTicks(6959), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "MediaResource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 868, DateTimeKind.Unspecified).AddTicks(9887), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 628, DateTimeKind.Unspecified).AddTicks(6539), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 946, DateTimeKind.Unspecified).AddTicks(7618), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 702, DateTimeKind.Unspecified).AddTicks(8074), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 946, DateTimeKind.Unspecified).AddTicks(6929), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 702, DateTimeKind.Unspecified).AddTicks(7532), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Billings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 873, DateTimeKind.Unspecified).AddTicks(565), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 632, DateTimeKind.Unspecified).AddTicks(5154), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Billings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 873, DateTimeKind.Unspecified).AddTicks(45), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 632, DateTimeKind.Unspecified).AddTicks(4651), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "beneficiaries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 945, DateTimeKind.Unspecified).AddTicks(4108), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 701, DateTimeKind.Unspecified).AddTicks(6618), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "beneficiaries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 945, DateTimeKind.Unspecified).AddTicks(3298), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 701, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 876, DateTimeKind.Unspecified).AddTicks(5620), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 636, DateTimeKind.Unspecified).AddTicks(765), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 2, 15, 38, 32, 876, DateTimeKind.Unspecified).AddTicks(5094), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 636, DateTimeKind.Unspecified).AddTicks(240), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
