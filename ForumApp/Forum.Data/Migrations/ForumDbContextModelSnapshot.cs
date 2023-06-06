﻿// <auto-generated />
using System;
using ForumApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumApp.Data.Migrations
{
    [DbContext(typeof(Forum.Data.ForumDbContext))]
    partial class ForumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ForumApp.Data.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("24c12ad1-9635-4b8d-9db7-d27637e4febb"),
                            Content = "Discover the secrets of mindfulness and unlock inner peace in just 10 minutes a day. 🌸🧘‍♀️ #Mindfulness #InnerPeace",
                            Title = "My first post"
                        },
                        new
                        {
                            Id = new Guid("05ac22b6-fb4e-4a14-a3d6-b31a12b046d0"),
                            Content = "Calling all bookworms! 📚🐛 Dive into the enchanting world of fantasy with our top 5 must-read novels. #BookLovers #FantasyBooks",
                            Title = "My Second post"
                        },
                        new
                        {
                            Id = new Guid("6fc4fc5d-1de4-4c89-9fd0-070f4e13bea0"),
                            Content = "Boost your productivity and conquer your goals with these 5 powerful morning habits. 🌞💪 #ProductivityTips #MorningRoutine",
                            Title = "My third post"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
