using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSMayHan2.Migrations
{
    /// <inheritdoc />
    public partial class Db1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "standard",
                columns: table => new
                {
                    machine_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cycle_min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cycle_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    string_time_min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    string_time_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pk_pwr_min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pk_pwr_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    energy_min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    energy_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_abs_min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_abs_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weld_col_min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weld_col_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_col_min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_col_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trigger_force_min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trigger_force_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weld_force_min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weld_force_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    freq_chg_min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    freq_chg_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    set_ampA_min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    set_ampA_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    set_ampB_min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    set_ampB_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    velocity_min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    velocity_max = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modify_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modify_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_standard", x => x.machine_name);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id_user);
                });

            migrationBuilder.CreateTable(
                name: "device_manages",
                columns: table => new
                {
                    id_device = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    machine_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_device_manages", x => x.id_device);
                    table.ForeignKey(
                        name: "FK_device_manages_standard_machine_name",
                        column: x => x.machine_name,
                        principalTable: "standard",
                        principalColumn: "machine_name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parameters",
                columns: table => new
                {
                    id_parameter = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    machine_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cycle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    string_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pk_pwr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    energy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_abs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weld_col = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_col = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trigger_force = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weld_force = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    freq_chg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    set_ampA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    set_ampB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    velocity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    device_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    port_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_modify_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_modify_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameters", x => x.id_parameter);
                    table.ForeignKey(
                        name: "FK_parameters_standard_machine_name",
                        column: x => x.machine_name,
                        principalTable: "standard",
                        principalColumn: "machine_name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_device_manages_machine_name",
                table: "device_manages",
                column: "machine_name");

            migrationBuilder.CreateIndex(
                name: "IX_parameters_machine_name",
                table: "parameters",
                column: "machine_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "device_manages");

            migrationBuilder.DropTable(
                name: "parameters");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "standard");
        }
    }
}
