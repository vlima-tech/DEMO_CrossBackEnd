using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CrossBackEnd.GeoLocation.Infra.Server.Data.Migrations
{
    public partial class GeoLocation_v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coutries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(nullable: false),
                    Abbreviation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coutries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<Guid>(nullable: false),
                    Abbreviation = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_States_Coutries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Coutries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<Guid>(nullable: false),
                    IsCapital = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Population = table.Column<int>(nullable: false),
                    StateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Coutries");
        }
    }
}
