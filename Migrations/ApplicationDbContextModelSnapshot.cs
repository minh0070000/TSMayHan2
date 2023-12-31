﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TSMayHan2.Context;

#nullable disable

namespace TSMayHan2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TSMayHan2.Models.device_manage", b =>
                {
                    b.Property<int>("id_device")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_device"));

                    b.Property<string>("machine_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_device");

                    b.HasIndex("machine_name");

                    b.ToTable("device_manages");
                });

            modelBuilder.Entity("TSMayHan2.Models.parameter", b =>
                {
                    b.Property<int>("id_parameter")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_parameter"));

                    b.Property<DateTime?>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("create_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cycle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("device_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("energy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("freq_chg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("last_modify_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("last_modify_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("machine_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("pk_pwr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("port_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("set_ampA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("set_ampB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("string_time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("total_abs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("total_col")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trigger_force")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("velocity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weld_col")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weld_force")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_parameter");

                    b.HasIndex("machine_name");

                    b.ToTable("parameters");
                });

            modelBuilder.Entity("TSMayHan2.Models.standard", b =>
                {
                    b.Property<string>("machine_name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cycle_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cycle_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("energy_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("energy_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("freq_chg_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("freq_chg_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("modify_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("modify_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pk_pwr_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pk_pwr_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("set_ampA_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("set_ampA_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("set_ampB_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("set_ampB_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("string_time_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("string_time_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("total_abs_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("total_abs_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("total_col_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("total_col_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trigger_force_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trigger_force_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("velocity_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("velocity_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weld_col_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weld_col_min")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weld_force_max")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weld_force_min")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("machine_name");

                    b.ToTable("standards");
                });

            modelBuilder.Entity("TSMayHan2.Models.users", b =>
                {
                    b.Property<int>("id_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_user"));

                    b.Property<string>("passcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_user");

                    b.ToTable("users");
                });

            modelBuilder.Entity("TSMayHan2.Models.device_manage", b =>
                {
                    b.HasOne("TSMayHan2.Models.standard", "standard")
                        .WithMany("device_manages")
                        .HasForeignKey("machine_name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("standard");
                });

            modelBuilder.Entity("TSMayHan2.Models.parameter", b =>
                {
                    b.HasOne("TSMayHan2.Models.standard", "standard")
                        .WithMany("Parameters")
                        .HasForeignKey("machine_name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("standard");
                });

            modelBuilder.Entity("TSMayHan2.Models.standard", b =>
                {
                    b.Navigation("Parameters");

                    b.Navigation("device_manages");
                });
#pragma warning restore 612, 618
        }
    }
}
