using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations.Local
{
    public partial class AddingMediaEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beneficiaries_addresses_AddressId1",
                table: "beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_beneficiaries_AddressId1",
                table: "beneficiaries");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItem_TransactionId1",
                table: "TransactionItem",
                column: "TransactionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionItem_Transaction_TransactionId1",
                table: "TransactionItem",
                column: "TransactionId1",
                principalTable: "Transaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.CreateTable(
                name: "MediaResource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 364, DateTimeKind.Unspecified).AddTicks(9612), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 365, DateTimeKind.Unspecified).AddTicks(45), new TimeSpan(0, 0, 0, 0, 0))),
                    Size = table.Column<long>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    SourceUrl = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaResource", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "ProductMedia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 592, DateTimeKind.Unspecified).AddTicks(7160), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 592, DateTimeKind.Unspecified).AddTicks(7533), new TimeSpan(0, 0, 0, 0, 0))),
                    MediaResourceId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    IsThumbnail = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMedia_MediaResource_MediaResourceId",
                        column: x => x.MediaResourceId,
                        principalTable: "MediaResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMedia_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedia_MediaResourceId",
                table: "ProductMedia",
                column: "MediaResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedia_ProductId",
                table: "ProductMedia",
                column: "ProductId");        
    }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionItem_Transaction_TransactionId1",
                table: "TransactionItem");

            migrationBuilder.DropIndex(
                name: "IX_TransactionItem_TransactionId1",
                table: "TransactionItem");

            migrationBuilder.DropColumn(
                name: "TransactionId1",
                table: "TransactionItem");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_beneficiaries_AddressId1",
                table: "beneficiaries",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_beneficiaries_addresses_AddressId1",
                table: "beneficiaries",
                column: "AddressId",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
