﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TriWizardCup.DataService.Data;

#nullable disable

namespace TriWizardCup.DataService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240502133741_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("TriWizardCup.Entities.DbSet.Achievement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("DuelsWon")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PodiumPosition")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalEnemiesDefeated")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WizardId")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorldChampionship")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WizardId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("TriWizardCup.Entities.DbSet.Wizard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("WizardNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Wizards");
                });

            modelBuilder.Entity("TriWizardCup.Entities.DbSet.Achievement", b =>
                {
                    b.HasOne("TriWizardCup.Entities.DbSet.Wizard", "Wizard")
                        .WithMany("Achievements")
                        .HasForeignKey("WizardId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Achievements_Wizard");

                    b.Navigation("Wizard");
                });

            modelBuilder.Entity("TriWizardCup.Entities.DbSet.Wizard", b =>
                {
                    b.Navigation("Achievements");
                });
#pragma warning restore 612, 618
        }
    }
}