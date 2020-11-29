﻿// <auto-generated />
using System;
using GeeksChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeeksChallenge.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GeeksChallenge.Domain.Models.CloudProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CloudProviders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2020, 11, 29, 19, 32, 37, 623, DateTimeKind.Local).AddTicks(1287),
                            Name = "IGS"
                        });
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.Infrastructure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CloudProviderId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CloudProviderId");

                    b.ToTable("Infrastructures");
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.InfrastructureResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InfrastructureId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InfrastructureId");

                    b.HasIndex("ServiceId");

                    b.ToTable("InfrastructureResource");
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.InfrastructureResourceOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InfrastructureResourceId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceOptionId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InfrastructureResourceId");

                    b.HasIndex("ServiceOptionId");

                    b.ToTable("InfrastructureResourceOptions");
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.OptionDefaultValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OptionValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceOptionId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ServiceOptionId");

                    b.ToTable("OptionDefaultValues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2020, 11, 29, 19, 32, 37, 627, DateTimeKind.Local).AddTicks(1427),
                            OptionValue = "Windows",
                            ServiceOptionId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2020, 11, 29, 19, 32, 37, 627, DateTimeKind.Local).AddTicks(1488),
                            OptionValue = "Linux",
                            ServiceOptionId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2020, 11, 29, 19, 32, 37, 627, DateTimeKind.Local).AddTicks(1490),
                            OptionValue = "MySQL ",
                            ServiceOptionId = 2
                        },
                        new
                        {
                            Id = 4,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2020, 11, 29, 19, 32, 37, 627, DateTimeKind.Local).AddTicks(1491),
                            OptionValue = " SQL Server ",
                            ServiceOptionId = 2
                        });
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2020, 11, 29, 19, 32, 37, 626, DateTimeKind.Local).AddTicks(778),
                            Name = "Virtual Machines"
                        },
                        new
                        {
                            Id = 2,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2020, 11, 29, 19, 32, 37, 626, DateTimeKind.Local).AddTicks(854),
                            Name = "Database Servers"
                        });
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.ServiceOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceOptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2020, 11, 29, 19, 32, 37, 626, DateTimeKind.Local).AddTicks(6762),
                            Name = "Operating System",
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedById = -1,
                            CreatedDate = new DateTime(2020, 11, 29, 19, 32, 37, 626, DateTimeKind.Local).AddTicks(6847),
                            Name = "Database Engine",
                            ServiceId = 2
                        });
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.Infrastructure", b =>
                {
                    b.HasOne("GeeksChallenge.Domain.Models.CloudProvider", "CloudProvider")
                        .WithMany("Infrastructures")
                        .HasForeignKey("CloudProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CloudProvider");
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.InfrastructureResource", b =>
                {
                    b.HasOne("GeeksChallenge.Domain.Models.Infrastructure", "Infrastructure")
                        .WithMany("InfrastructureResources")
                        .HasForeignKey("InfrastructureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeeksChallenge.Domain.Models.Service", "Service")
                        .WithMany("InfrastructureResources")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Infrastructure");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.InfrastructureResourceOption", b =>
                {
                    b.HasOne("GeeksChallenge.Domain.Models.InfrastructureResource", "InfrastructureResource")
                        .WithMany("InfrastructureResourceOptions")
                        .HasForeignKey("InfrastructureResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeeksChallenge.Domain.Models.ServiceOption", "ServiceOption")
                        .WithMany("InfrastructureResourceOptions")
                        .HasForeignKey("ServiceOptionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("InfrastructureResource");

                    b.Navigation("ServiceOption");
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.OptionDefaultValue", b =>
                {
                    b.HasOne("GeeksChallenge.Domain.Models.ServiceOption", "ServiceOption")
                        .WithMany("OptionDefaultValues")
                        .HasForeignKey("ServiceOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceOption");
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.ServiceOption", b =>
                {
                    b.HasOne("GeeksChallenge.Domain.Models.Service", "Service")
                        .WithMany("ServiceOptions")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.CloudProvider", b =>
                {
                    b.Navigation("Infrastructures");
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.Infrastructure", b =>
                {
                    b.Navigation("InfrastructureResources");
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.InfrastructureResource", b =>
                {
                    b.Navigation("InfrastructureResourceOptions");
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.Service", b =>
                {
                    b.Navigation("InfrastructureResources");

                    b.Navigation("ServiceOptions");
                });

            modelBuilder.Entity("GeeksChallenge.Domain.Models.ServiceOption", b =>
                {
                    b.Navigation("InfrastructureResourceOptions");

                    b.Navigation("OptionDefaultValues");
                });
#pragma warning restore 612, 618
        }
    }
}