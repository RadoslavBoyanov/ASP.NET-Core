﻿// <auto-generated />
using System;
using BookManufacturingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookManufacturingApp.Data.Migrations
{
    [DbContext(typeof(ManufacturingBooksDbContext))]
    [Migration("20240126133449_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookManufacturingApp.Data.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biography = "Dan Brown is the author of numerous #1 bestselling novels. Brown’s novels are published in 56 languages around the world with over 200 million copies in print.",
                            BirthDate = new DateTime(1964, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "danBrown@gmail.com",
                            Name = "Dan Brown",
                            Nationality = "American",
                            PhoneNumber = "0883332351"
                        },
                        new
                        {
                            Id = 2,
                            Biography = " He has been popularly identified as the \"father\" of modern fantasy literature—or, more precisely, of high fantasy, and is widely regarded as one of the most influential authors of all time.",
                            BirthDate = new DateTime(1982, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "j.r.r.tolkien@yahoo.com",
                            Name = "J. R. R. Tolkien",
                            Nationality = "British",
                            PhoneNumber = "0999283911"
                        },
                        new
                        {
                            Id = 3,
                            Biography = "American novelist, screenwriter, television producer, and short story writer. He is the author of the series of epic fantasy novels A Song of Ice and Fire.",
                            BirthDate = new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "g.r.r.Martin@gmail.com",
                            Name = "George R. R. Martin",
                            Nationality = "American",
                            PhoneNumber = "8889106871"
                        });
                });

            modelBuilder.Entity("BookManufacturingApp.Data.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PrintingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Genre = "Thriller",
                            Information = "The Da Vinci Code follows symbologist Robert Langdon and cryptologist Sophie Neveu after a murder in the Louvre Museum in Paris causes them to become involved in a battle between the Priory of Sion and Opus Dei over the possibility of Jesus Christ and Mary Magdalene having had a child together.",
                            Pages = 689,
                            Price = 24m,
                            PrintingDate = new DateTime(2003, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Da Vinci Code"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Genre = "Fantasy",
                            Information = "The book is recognized as a classic in children's literature and is one of the best-selling books of all time, with over 100 million copies sold.",
                            Pages = 310,
                            Price = 18m,
                            PrintingDate = new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Hobbit"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Genre = "Fantasy",
                            Information = "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin.",
                            Pages = 694,
                            Price = 32m,
                            PrintingDate = new DateTime(1996, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "A Game of Thrones"
                        });
                });

            modelBuilder.Entity("BookManufacturingApp.Data.Models.Book", b =>
                {
                    b.HasOne("BookManufacturingApp.Data.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BookManufacturingApp.Data.Models.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
