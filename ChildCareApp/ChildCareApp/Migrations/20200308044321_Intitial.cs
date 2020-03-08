using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChildCareApp.Migrations
{
    public partial class Intitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    ClassName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    DayWorkdetails = table.Column<string>(nullable: true),
                    PersonType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildActivity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ActivityType = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityId", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_ChildActivity_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildActivity_Id",
                table: "ChildActivity",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildActivity");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
