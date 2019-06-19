using Microsoft.EntityFrameworkCore.Migrations;

namespace EFFunzies.Migrations
{
    public partial class voteslol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Messages_MessageId",
                table: "Vote");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Users_UserId",
                table: "Vote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vote",
                table: "Vote");

            migrationBuilder.RenameTable(
                name: "Vote",
                newName: "Votes");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_UserId",
                table: "Votes",
                newName: "IX_Votes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_MessageId",
                table: "Votes",
                newName: "IX_Votes_MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "VoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Messages_MessageId",
                table: "Votes",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Messages_MessageId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.RenameTable(
                name: "Votes",
                newName: "Vote");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_UserId",
                table: "Vote",
                newName: "IX_Vote_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_MessageId",
                table: "Vote",
                newName: "IX_Vote_MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vote",
                table: "Vote",
                column: "VoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Messages_MessageId",
                table: "Vote",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Users_UserId",
                table: "Vote",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
