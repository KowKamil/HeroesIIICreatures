using Microsoft.EntityFrameworkCore.Migrations;

namespace Heroes_3_Creatures.Migrations
{
    public partial class CreatureAbilityAssociationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreatureAbility_Abilities_AbilityId",
                table: "CreatureAbility");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatureAbility_Creatures_CreatureId",
                table: "CreatureAbility");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreatureAbility",
                table: "CreatureAbility");

            migrationBuilder.RenameTable(
                name: "CreatureAbility",
                newName: "CreatureAbilities");

            migrationBuilder.RenameIndex(
                name: "IX_CreatureAbility_AbilityId",
                table: "CreatureAbilities",
                newName: "IX_CreatureAbilities_AbilityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreatureAbilities",
                table: "CreatureAbilities",
                columns: new[] { "CreatureId", "AbilityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureAbilities_Abilities_AbilityId",
                table: "CreatureAbilities",
                column: "AbilityId",
                principalTable: "Abilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureAbilities_Creatures_CreatureId",
                table: "CreatureAbilities",
                column: "CreatureId",
                principalTable: "Creatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreatureAbilities_Abilities_AbilityId",
                table: "CreatureAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatureAbilities_Creatures_CreatureId",
                table: "CreatureAbilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreatureAbilities",
                table: "CreatureAbilities");

            migrationBuilder.RenameTable(
                name: "CreatureAbilities",
                newName: "CreatureAbility");

            migrationBuilder.RenameIndex(
                name: "IX_CreatureAbilities_AbilityId",
                table: "CreatureAbility",
                newName: "IX_CreatureAbility_AbilityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreatureAbility",
                table: "CreatureAbility",
                columns: new[] { "CreatureId", "AbilityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureAbility_Abilities_AbilityId",
                table: "CreatureAbility",
                column: "AbilityId",
                principalTable: "Abilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatureAbility_Creatures_CreatureId",
                table: "CreatureAbility",
                column: "CreatureId",
                principalTable: "Creatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
