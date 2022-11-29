using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogixTest.Infrastructure.Migrations
{
    public partial class AddForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieName",
                table: "MovieTransactions");

            migrationBuilder.AddColumn<Guid>(
                name: "MovieId",
                table: "MovieTransactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MovieTransactions_MovieId",
                table: "MovieTransactions",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTransactions_Movies_MovieId",
                table: "MovieTransactions",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTransactions_Movies_MovieId",
                table: "MovieTransactions");

            migrationBuilder.DropIndex(
                name: "IX_MovieTransactions_MovieId",
                table: "MovieTransactions");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "MovieTransactions");

            migrationBuilder.AddColumn<string>(
                name: "MovieName",
                table: "MovieTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
