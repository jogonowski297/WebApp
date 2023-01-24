using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingFee",
                table: "TrainingFee");

            migrationBuilder.RenameTable(
                name: "TrainingFee",
                newName: "TrainingFees");

            migrationBuilder.AddColumn<string>(
                name: "Track",
                table: "TrainingFees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingFees",
                table: "TrainingFees",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingFees",
                table: "TrainingFees");

            migrationBuilder.DropColumn(
                name: "Track",
                table: "TrainingFees");

            migrationBuilder.RenameTable(
                name: "TrainingFees",
                newName: "TrainingFee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingFee",
                table: "TrainingFee",
                column: "Id");
        }
    }
}
