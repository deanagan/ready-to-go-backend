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
    [Migration("20200702074802_ItemDetailNotes")]
    partial class ItemDetailNotes
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
                        },
                        new
                        {
                            Id = 2,
                            Description = "Trip to Jervis Bay!",
                            Name = "Jervis Bay Trip"
                        });
                });

            modelBuilder.Entity("Api.Data.Models.CheckListToItemDetail", b =>
                {
                    b.Property<int>("ItemDetailId")
                        .HasColumnType("int");

                    b.Property<int>("CheckListId")
                        .HasColumnType("int");

                    b.HasKey("ItemDetailId", "CheckListId");

                    b.HasIndex("CheckListId");

                    b.ToTable("CheckListToItemDetails");

                    b.HasData(
                        new
                        {
                            ItemDetailId = 1,
                            CheckListId = 1
                        },
                        new
                        {
                            ItemDetailId = 2,
                            CheckListId = 1
                        },
                        new
                        {
                            ItemDetailId = 3,
                            CheckListId = 1
                        },
                        new
                        {
                            ItemDetailId = 2,
                            CheckListId = 2
                        },
                        new
                        {
                            ItemDetailId = 4,
                            CheckListId = 2
                        },
                        new
                        {
                            ItemDetailId = 5,
                            CheckListId = 2
                        },
                        new
                        {
                            ItemDetailId = 6,
                            CheckListId = 2
                        },
                        new
                        {
                            ItemDetailId = 7,
                            CheckListId = 2
                        });
                });

            modelBuilder.Entity("Api.Data.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Extra T-shirts",
                            Name = "T-shirt"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Extra Pants",
                            Name = "Pants"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Empty Bottle",
                            Name = "Water Bottle"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Bring the electric one!",
                            Name = "Toothbrush"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Speedo Green Snorkel",
                            Name = "Snorkel"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Banana Shaped Floatie",
                            Name = "Floaties"
                        });
                });

            modelBuilder.Entity("Api.Data.Models.ItemDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Notes")
                        .HasColumnType("int");

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
                            ItemId = 1,
                            Notes = 0,
                            Quantity = 3,
                            Ready = false
                        },
                        new
                        {
                            Id = 2,
                            ItemId = 2,
                            Notes = 0,
                            Quantity = 1,
                            Ready = false
                        },
                        new
                        {
                            Id = 3,
                            ItemId = 3,
                            Notes = 0,
                            Quantity = 1,
                            Ready = false
                        },
                        new
                        {
                            Id = 4,
                            ItemId = 4,
                            Notes = 0,
                            Quantity = 1,
                            Ready = false
                        },
                        new
                        {
                            Id = 5,
                            ItemId = 5,
                            Notes = 0,
                            Quantity = 1,
                            Ready = false
                        },
                        new
                        {
                            Id = 6,
                            ItemId = 6,
                            Notes = 0,
                            Quantity = 1,
                            Ready = false
                        },
                        new
                        {
                            Id = 7,
                            ItemId = 1,
                            Notes = 0,
                            Quantity = 6,
                            Ready = false
                        });
                });

            modelBuilder.Entity("Api.Data.Models.CheckListToItemDetail", b =>
                {
                    b.HasOne("Api.Data.Models.CheckList", "CheckList")
                        .WithMany("CheckListToItems")
                        .HasForeignKey("CheckListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Data.Models.ItemDetail", "ItemDetail")
                        .WithMany()
                        .HasForeignKey("ItemDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Data.Models.Item", b =>
                {
                    b.HasOne("Api.Data.Models.ItemDetail", "ItemDetail")
                        .WithOne("Item")
                        .HasForeignKey("Api.Data.Models.Item", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
