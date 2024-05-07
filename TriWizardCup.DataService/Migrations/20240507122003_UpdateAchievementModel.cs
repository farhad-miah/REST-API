using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriWizardCup.DataService.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAchievementModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorldChampionship",
                table: "Achievements",
                newName: "TriWizardCupWins");

            migrationBuilder.RenameColumn(
                name: "PodiumPosition",
                table: "Achievements",
                newName: "TopThreeFinishes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TriWizardCupWins",
                table: "Achievements",
                newName: "WorldChampionship");

            migrationBuilder.RenameColumn(
                name: "TopThreeFinishes",
                table: "Achievements",
                newName: "PodiumPosition");
        }
    }
}
