using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HACCPTrack.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInviteNullableRestaurantId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Restaurants_RestaurantId",
                table: "Invites");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "Invites",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Restaurants_RestaurantId",
                table: "Invites",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Restaurants_RestaurantId",
                table: "Invites");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "Invites",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Restaurants_RestaurantId",
                table: "Invites",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
