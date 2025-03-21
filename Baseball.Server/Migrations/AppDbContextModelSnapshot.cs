﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Baseball.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BaseballPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AVG")
                        .HasColumnType("float");

                    b.Property<int>("AtBats")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "At-bat");

                    b.Property<string>("CaughtStealing")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("0")
                        .HasAnnotation("Relational:JsonPropertyName", "Caught stealing");

                    b.Property<int>("Doubles")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "Double (2B)");

                    b.Property<int>("Games")
                        .HasColumnType("int");

                    b.Property<int>("Hits")
                        .HasColumnType("int");

                    b.Property<int>("HomeRuns")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "home run");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "Player name");

                    b.Property<double>("OPS")
                        .HasColumnType("float")
                        .HasAnnotation("Relational:JsonPropertyName", "On-base Plus Slugging");

                    b.Property<double>("OnBasePercentage")
                        .HasColumnType("float")
                        .HasAnnotation("Relational:JsonPropertyName", "On-base Percentage");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "position");

                    b.Property<int>("RBIs")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "run batted in");

                    b.Property<int>("Runs")
                        .HasColumnType("int");

                    b.Property<double>("SluggingPercentage")
                        .HasColumnType("float")
                        .HasAnnotation("Relational:JsonPropertyName", "Slugging Percentage");

                    b.Property<int>("StolenBases")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "stolen base");

                    b.Property<int>("Strikeouts")
                        .HasColumnType("int");

                    b.Property<int>("Triples")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "third baseman");

                    b.Property<int>("Walks")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "a walk");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
