﻿// <auto-generated />
using System;
using Heroes_3_Creatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Heroes_3_Creatures.Migrations
{
    [DbContext(typeof(CreaturesContext))]
    partial class CreaturesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Heroes_3_Creatures.Models.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AbilityText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("Heroes_3_Creatures.Models.Creature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("BaseGrowth")
                        .HasColumnType("int");

                    b.Property<int>("DamageMaximum")
                        .HasColumnType("int");

                    b.Property<int>("DamageMinimum")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("FractionId")
                        .HasColumnType("int");

                    b.Property<int>("GoldCost")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Shots")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Tier")
                        .HasColumnType("int");

                    b.Property<int?>("UpgradedFromId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FractionId");

                    b.HasIndex("UpgradedFromId");

                    b.ToTable("Creatures");
                });

            modelBuilder.Entity("Heroes_3_Creatures.Models.CreatureAbility", b =>
                {
                    b.Property<int>("CreatureId")
                        .HasColumnType("int");

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.HasKey("CreatureId", "AbilityId");

                    b.HasIndex("AbilityId");

                    b.ToTable("CreatureAbilities");
                });

            modelBuilder.Entity("Heroes_3_Creatures.Models.Fraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fractions");
                });

            modelBuilder.Entity("Heroes_3_Creatures.Models.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Heroes_3_Creatures.Models.ResourceCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CreatureID")
                        .HasColumnType("int");

                    b.Property<int>("ResourceID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatureID");

                    b.HasIndex("ResourceID");

                    b.ToTable("ResourceCosts");
                });

            modelBuilder.Entity("Heroes_3_Creatures.Models.Creature", b =>
                {
                    b.HasOne("Heroes_3_Creatures.Models.Fraction", "Fraction")
                        .WithMany()
                        .HasForeignKey("FractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Heroes_3_Creatures.Models.Creature", "UpgradedFrom")
                        .WithMany()
                        .HasForeignKey("UpgradedFromId");
                });

            modelBuilder.Entity("Heroes_3_Creatures.Models.CreatureAbility", b =>
                {
                    b.HasOne("Heroes_3_Creatures.Models.Ability", "Ability")
                        .WithMany("CreatureAbilities")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Heroes_3_Creatures.Models.Creature", "Creature")
                        .WithMany("CreatureAbilities")
                        .HasForeignKey("CreatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Heroes_3_Creatures.Models.ResourceCost", b =>
                {
                    b.HasOne("Heroes_3_Creatures.Models.Creature", "Creature")
                        .WithMany("ResourceCosts")
                        .HasForeignKey("CreatureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Heroes_3_Creatures.Models.Resource", "Resource")
                        .WithMany("ResourceCost")
                        .HasForeignKey("ResourceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
