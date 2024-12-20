﻿// <auto-generated />
using System;
using CombatGame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CombatGame.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241211114441_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CombatGame.Models.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BattleDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Team1Id")
                        .HasColumnType("int");

                    b.Property<int>("Team2Id")
                        .HasColumnType("int");

                    b.Property<string>("Winner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.ToTable("Battles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BattleDate = new DateTime(2024, 12, 11, 5, 44, 41, 244, DateTimeKind.Local).AddTicks(9297),
                            Team1Id = 1,
                            Team2Id = 2,
                            Winner = "Warriors"
                        });
                });

            modelBuilder.Entity("CombatGame.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Defense = 70,
                            Intelligence = 60,
                            Name = "Knight",
                            Speed = 50,
                            Strength = 80
                        },
                        new
                        {
                            Id = 2,
                            Defense = 50,
                            Intelligence = 70,
                            Name = "Archer",
                            Speed = 90,
                            Strength = 60
                        },
                        new
                        {
                            Id = 3,
                            Defense = 80,
                            Intelligence = 30,
                            Name = "Orc",
                            Speed = 40,
                            Strength = 90
                        },
                        new
                        {
                            Id = 4,
                            Defense = 40,
                            Intelligence = 60,
                            Name = "Goblin",
                            Speed = 80,
                            Strength = 50
                        });
                });

            modelBuilder.Entity("CombatGame.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"), 1L, 1);

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            TeamName = "Warriors",
                            UserId = 1
                        },
                        new
                        {
                            TeamId = 2,
                            TeamName = "Monsters",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("CombatGame.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "password1",
                            Username = "player1"
                        },
                        new
                        {
                            Id = 2,
                            Password = "password2",
                            Username = "player2"
                        });
                });

            modelBuilder.Entity("CombatGame.Models.Battle", b =>
                {
                    b.HasOne("CombatGame.Models.Team", "Team1")
                        .WithMany()
                        .HasForeignKey("Team1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CombatGame.Models.Team", "Team2")
                        .WithMany()
                        .HasForeignKey("Team2Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Team1");

                    b.Navigation("Team2");
                });

            modelBuilder.Entity("CombatGame.Models.Character", b =>
                {
                    b.HasOne("CombatGame.Models.Team", null)
                        .WithMany("Characters")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("CombatGame.Models.Team", b =>
                {
                    b.HasOne("CombatGame.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CombatGame.Models.Team", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
