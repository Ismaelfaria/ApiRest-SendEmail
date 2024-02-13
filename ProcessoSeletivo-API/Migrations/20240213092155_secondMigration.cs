using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcessoSeletivo_API.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailEntity_Candidato_CandidatoId",
                table: "EmailEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailEntity",
                table: "EmailEntity");

            migrationBuilder.RenameTable(
                name: "EmailEntity",
                newName: "Emails");

            migrationBuilder.RenameIndex(
                name: "IX_EmailEntity_CandidatoId",
                table: "Emails",
                newName: "IX_Emails_CandidatoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emails",
                table: "Emails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Candidato_CandidatoId",
                table: "Emails",
                column: "CandidatoId",
                principalTable: "Candidato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Candidato_CandidatoId",
                table: "Emails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emails",
                table: "Emails");

            migrationBuilder.RenameTable(
                name: "Emails",
                newName: "EmailEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_CandidatoId",
                table: "EmailEntity",
                newName: "IX_EmailEntity_CandidatoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailEntity",
                table: "EmailEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailEntity_Candidato_CandidatoId",
                table: "EmailEntity",
                column: "CandidatoId",
                principalTable: "Candidato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
