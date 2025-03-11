using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCourse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KursTablosu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CoursePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CourseBeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseFinishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursTablosu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciTablosu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciTablosu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KursKayitTablosu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursKayitTablosu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KursKayitTablosu_KursTablosu_KursId",
                        column: x => x.KursId,
                        principalTable: "KursTablosu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KursKayitTablosu_OgrenciTablosu_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "OgrenciTablosu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KursKayitTablosu_KursId",
                table: "KursKayitTablosu",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_KursKayitTablosu_OgrenciId",
                table: "KursKayitTablosu",
                column: "OgrenciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KursKayitTablosu");

            migrationBuilder.DropTable(
                name: "KursTablosu");

            migrationBuilder.DropTable(
                name: "OgrenciTablosu");
        }
    }
}
