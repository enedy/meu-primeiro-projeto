﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFirstProject.Data.Contexts;

namespace MyFirstProject.Data.Migrations
{
    [DbContext(typeof(MyFirstProjectContext))]
    [Migration("20210127001332_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("MyFirstProject.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Password")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Status")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasDatabaseName("idx_user_name");

                    b.HasIndex("Name", "Status")
                        .HasDatabaseName("idx_user_name_status");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MyFirstProject.Domain.Entities.User", b =>
                {
                    b.OwnsOne("MyFirstProject.Domain.ValueObjects.Document", "Document", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .HasColumnType("VARCHAR(14)")
                                .HasColumnName("Number");

                            b1.Property<int>("Type")
                                .HasColumnType("int")
                                .HasColumnName("DocumentType");

                            b1.HasKey("UserId");

                            b1.HasIndex("Number");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("MyFirstProject.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .HasColumnType("VARCHAR(50)")
                                .HasColumnName("EmailAdress");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Document");

                    b.Navigation("Email");
                });
#pragma warning restore 612, 618
        }
    }
}
