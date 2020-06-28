using Microsoft.EntityFrameworkCore;
using Api.Data.Models;

namespace Api.Data.Contexts
{
    public class ReadyToGoContext : DbContext
    {
        public ReadyToGoContext(DbContextOptions<ReadyToGoContext> options)
        : base(options)
        {

        }

        public DbSet<CheckList> CheckLists {get; set;}
        public DbSet<CheckListToItemDetail> CheckListToItemDetails {get; set;}
        public DbSet<Item> Items {get; set;}
        public DbSet<ItemDetail> ItemDetails {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckListToItemDetail>().HasKey(
                cti => new { cti.ItemDetailId, cti.CheckListId }
            );

            modelBuilder.Entity<ItemDetail>()
                .HasOne<Item>(i => i.Item)
                .WithOne(itd => itd.ItemDetail)
                .HasForeignKey<Item>(itd => itd.Id);

            modelBuilder.Entity<Item>(
                i => {
                    i.HasKey(i => i.Id);
                }
            );

            modelBuilder.Entity<CheckList>().HasData(
                new CheckList {
                    Id = 1,
                    Name = "Full Marathon",
                    Description = "This is a checklist for my full marathon!"
                },
                new CheckList {
                    Id = 2,
                    Name = "Jervis Bay Trip",
                    Description = "Trip to Jervis Bay!"
                }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item {
                    Id = 1,
                    Name = "T-shirt",
                    Description = "Extra T-shirts"
                },
                new Item {
                    Id = 2,
                    Name = "Pants",
                    Description = "Extra Pants"
                },
                new Item {
                    Id = 3,
                    Name = "Water Bottle",
                    Description = "Empty Bottle"
                },
                new Item {
                    Id = 4,
                    Name = "Toothbrush",
                    Description = "Bring the electric one!"
                },
                new Item {
                    Id = 5,
                    Name = "Snorkel",
                    Description = "Speedo Green Snorkel",
                },
                new Item {
                    Id = 6,
                    Name = "Floaties",
                    Description = "Banana Shaped Floatie",
                }
            );

            modelBuilder.Entity<ItemDetail>().HasData(
                new ItemDetail {
                    Id = 1,
                    Ready = false,
                    Quantity = 3,
                    ItemId = 1
                },
                new ItemDetail {
                    Id = 2,
                    Ready = false,
                    Quantity = 1,
                    ItemId = 2
                },
                new ItemDetail {
                    Id = 3,
                    Ready = false,
                    Quantity = 1,
                    ItemId = 3
                },
                new ItemDetail {
                    Id = 4,
                    Ready = false,
                    Quantity = 1,
                    ItemId = 4
                },
                new ItemDetail {
                    Id = 5,
                    Ready = false,
                    Quantity = 1,
                    ItemId = 5
                },
                new ItemDetail {
                    Id = 6,
                    Ready = false,
                    Quantity = 1,
                    ItemId = 6
                },
                new ItemDetail {
                    Id = 7,
                    Ready = false,
                    Quantity = 6,
                    ItemId = 1
                }
            );


             modelBuilder.Entity<CheckListToItemDetail>().HasData(
                new CheckListToItemDetail { CheckListId = 1, ItemDetailId = 1 },
                new CheckListToItemDetail { CheckListId = 1, ItemDetailId = 2 },
                new CheckListToItemDetail { CheckListId = 1, ItemDetailId = 3 },
                new CheckListToItemDetail { CheckListId = 2, ItemDetailId = 2 },
                new CheckListToItemDetail { CheckListId = 2, ItemDetailId = 4 },
                new CheckListToItemDetail { CheckListId = 2, ItemDetailId = 5 },
                new CheckListToItemDetail { CheckListId = 2, ItemDetailId = 6 },
                new CheckListToItemDetail { CheckListId = 2, ItemDetailId = 7 }
            );
        }

    }
}
