using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSMayHan2.Migrations
{
    /// <inheritdoc />
    public partial class database3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_device_manages_standard_machine_name",
                table: "device_manages");

            migrationBuilder.DropForeignKey(
                name: "FK_parameters_standard_machine_name",
                table: "parameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_standard",
                table: "standard");

            migrationBuilder.RenameTable(
                name: "standard",
                newName: "standards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_standards",
                table: "standards",
                column: "machine_name");

            migrationBuilder.AddForeignKey(
                name: "FK_device_manages_standards_machine_name",
                table: "device_manages",
                column: "machine_name",
                principalTable: "standards",
                principalColumn: "machine_name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_parameters_standards_machine_name",
                table: "parameters",
                column: "machine_name",
                principalTable: "standards",
                principalColumn: "machine_name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_device_manages_standards_machine_name",
                table: "device_manages");

            migrationBuilder.DropForeignKey(
                name: "FK_parameters_standards_machine_name",
                table: "parameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_standards",
                table: "standards");

            migrationBuilder.RenameTable(
                name: "standards",
                newName: "standard");

            migrationBuilder.AddPrimaryKey(
                name: "PK_standard",
                table: "standard",
                column: "machine_name");

            migrationBuilder.AddForeignKey(
                name: "FK_device_manages_standard_machine_name",
                table: "device_manages",
                column: "machine_name",
                principalTable: "standard",
                principalColumn: "machine_name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_parameters_standard_machine_name",
                table: "parameters",
                column: "machine_name",
                principalTable: "standard",
                principalColumn: "machine_name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
