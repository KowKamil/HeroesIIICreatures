using Microsoft.EntityFrameworkCore.Migrations;

namespace Heroes_3_Creatures.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityText = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fractions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fractions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Creatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    FractionId = table.Column<int>(nullable: false),
                    UpgradedFromId = table.Column<int>(nullable: true),
                    Tier = table.Column<int>(nullable: false),
                    Attack = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    Shots = table.Column<int>(nullable: false),
                    DamageMinimum = table.Column<int>(nullable: false),
                    DamageMaximum = table.Column<int>(nullable: false),
                    Health = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    GoldCost = table.Column<int>(nullable: false),
                    BaseGrowth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creatures_Fractions_FractionId",
                        column: x => x.FractionId,
                        principalTable: "Fractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Creatures_Creatures_UpgradedFromId",
                        column: x => x.UpgradedFromId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreatureAbility",
                columns: table => new
                {
                    CreatureId = table.Column<int>(nullable: false),
                    AbilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureAbility", x => new { x.CreatureId, x.AbilityId });
                    table.ForeignKey(
                        name: "FK_CreatureAbility_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureAbility_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceCosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatureID = table.Column<int>(nullable: false),
                    ResourceID = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceCosts_Creatures_CreatureID",
                        column: x => x.CreatureID,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceCosts_Resources_ResourceID",
                        column: x => x.ResourceID,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreatureAbility_AbilityId",
                table: "CreatureAbility",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Creatures_FractionId",
                table: "Creatures",
                column: "FractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Creatures_UpgradedFromId",
                table: "Creatures",
                column: "UpgradedFromId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceCosts_CreatureID",
                table: "ResourceCosts",
                column: "CreatureID");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceCosts_ResourceID",
                table: "ResourceCosts",
                column: "ResourceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatureAbility");

            migrationBuilder.DropTable(
                name: "ResourceCosts");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Creatures");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Fractions");
        }
    }
}
