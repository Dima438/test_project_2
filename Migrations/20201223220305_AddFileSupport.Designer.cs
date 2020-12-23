﻿// <auto-generated />
using System;
using DBStuff.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace db_stuff.Migrations
{
    [DbContext(typeof(RecordContext))]
    [Migration("20201223220305_AddFileSupport")]
    partial class AddFileSupport
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DBStuff.Models.MyFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ContentType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FileName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RecordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecordId")
                        .IsUnique();

                    b.ToTable("Files");
                });

            modelBuilder.Entity("DBStuff.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AnotherLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("DBStuff.Models.MyFile", b =>
                {
                    b.HasOne("DBStuff.Models.Record", "Record")
                        .WithOne("File")
                        .HasForeignKey("DBStuff.Models.MyFile", "RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Record");
                });

            modelBuilder.Entity("DBStuff.Models.Record", b =>
                {
                    b.Navigation("File");
                });
#pragma warning restore 612, 618
        }
    }
}
