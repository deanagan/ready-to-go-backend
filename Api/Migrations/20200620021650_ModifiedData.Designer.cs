﻿// <auto-generated />
using Api.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Migrations
{
    [DbContext(typeof(ReadyToGoContext))]
    [Migration("20200620021650_ModifiedData")]
    partial class ModifiedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Data.Models.CheckList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CheckLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This is a checklist for my full marathon!",
                            Name = "Full Marathon"
                        });
                });

            modelBuilder.Entity("Api.Data.Models.CheckListToItem", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("CheckListId")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "CheckListId");

                    b.HasIndex("CheckListId");

                    b.ToTable("CheckListToItems");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            CheckListId = 1
                        },
                        new
                        {
                            ItemId = 2,
                            CheckListId = 1
                        },
                        new
                        {
                            ItemId = 3,
                            CheckListId = 1
                        },
                        new
                        {
                            ItemId = 4,
                            CheckListId = 1
                        });
                });

            modelBuilder.Entity("Api.Data.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemDetailId = 1,
                            Name = "T-shirt"
                        },
                        new
                        {
                            Id = 2,
                            ItemDetailId = 2,
                            Name = "Pants"
                        },
                        new
                        {
                            Id = 3,
                            ItemDetailId = 3,
                            Name = "Water Bottle"
                        },
                        new
                        {
                            Id = 4,
                            ItemDetailId = 4,
                            Name = "Toothbrush"
                        });
                });

            modelBuilder.Entity("Api.Data.Models.ItemDetail", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Ready")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ItemDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Extra T-shirts",
                            Quantity = 3,
                            Ready = false
                        },
                        new
                        {
                            Id = 2,
                            Description = "Extra Pants",
                            Quantity = 1,
                            Ready = false
                        },
                        new
                        {
                            Id = 3,
                            Description = "Empty Bottle",
                            Quantity = 1,
                            Ready = false
                        },
                        new
                        {
                            Id = 4,
                            Description = "Bring the electric one!",
                            Quantity = 1,
                            Ready = false
                        });
                });

            modelBuilder.Entity("Api.Data.Models.CheckListToItem", b =>
                {
                    b.HasOne("Api.Data.Models.CheckList", "CheckList")
                        .WithMany("CheckListToItems")
                        .HasForeignKey("CheckListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Data.Models.Item", "Item")
                        .WithMany("CheckListToItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Data.Models.ItemDetail", b =>
                {
                    b.HasOne("Api.Data.Models.Item", "Item")
                        .WithOne("ItemDetail")
                        .HasForeignKey("Api.Data.Models.ItemDetail", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
