using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkRun.NpgSql.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "per");

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "per",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Idn = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    TaxNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SurName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ModifierDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RowVersion = table.Column<long>(type: "bigint", nullable: false),
                    UpdateCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons",
                schema: "per");
        }
    }
}
