﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsApp.Infrastructure.Data;

#nullable disable

namespace NewsApp.Infrastructure.Migrations
{
    [DbContext(typeof(NewsAppDbContext))]
    partial class NewsAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NewsApp.Infrastructure.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of article.");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the category of article.");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("Content of the article.");

                    b.Property<Guid>("JournalistId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the journalist writed the article.");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Publish Date")
                        .HasComment("Date of publish for the article.");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Title of the article.");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("JournalistId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("NewsApp.Infrastructure.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id for the news category.");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Content for the category.");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Name of the news category.");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("NewsApp.Infrastructure.Models.CategoryJournalist", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JournalistId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryId", "JournalistId");

                    b.HasIndex("JournalistId");

                    b.ToTable("CategoriesJournalists");
                });

            modelBuilder.Entity("NewsApp.Infrastructure.Models.Journalist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Id of the journalist.");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasComment("Email of the journalist.");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name of the journalist.");

                    b.HasKey("Id");

                    b.ToTable("Journalists");
                });

            modelBuilder.Entity("NewsApp.Infrastructure.Models.Article", b =>
                {
                    b.HasOne("NewsApp.Infrastructure.Models.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NewsApp.Infrastructure.Models.Journalist", "Journalist")
                        .WithMany("Articles")
                        .HasForeignKey("JournalistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Journalist");
                });

            modelBuilder.Entity("NewsApp.Infrastructure.Models.CategoryJournalist", b =>
                {
                    b.HasOne("NewsApp.Infrastructure.Models.Category", "Category")
                        .WithMany("CategoryJournalists")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewsApp.Infrastructure.Models.Journalist", "Journalist")
                        .WithMany("CategoryJournalists")
                        .HasForeignKey("JournalistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Journalist");
                });

            modelBuilder.Entity("NewsApp.Infrastructure.Models.Category", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("CategoryJournalists");
                });

            modelBuilder.Entity("NewsApp.Infrastructure.Models.Journalist", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("CategoryJournalists");
                });
#pragma warning restore 612, 618
        }
    }
}
