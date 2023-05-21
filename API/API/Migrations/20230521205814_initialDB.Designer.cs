﻿// <auto-generated />
using System;
using API.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230521205814_initialDB")]
    partial class initialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.DAL.Entities.Entrance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Entrances");
                });

            modelBuilder.Entity("API.DAL.Entities.StadiumTickets", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EntranceGate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("StadiumTicketss");
                });

            modelBuilder.Entity("EntranceStadiumTickets", b =>
                {
                    b.Property<Guid>("EntranceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StadiumTicketsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EntranceId", "StadiumTicketsId");

                    b.HasIndex("StadiumTicketsId");

                    b.ToTable("EntranceStadiumTickets");
                });

            modelBuilder.Entity("EntranceStadiumTickets", b =>
                {
                    b.HasOne("API.DAL.Entities.Entrance", null)
                        .WithMany()
                        .HasForeignKey("EntranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.DAL.Entities.StadiumTickets", null)
                        .WithMany()
                        .HasForeignKey("StadiumTicketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
