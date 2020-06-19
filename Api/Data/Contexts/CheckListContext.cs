using Microsoft.EntityFrameworkCore;
using Api.Data.Models;

namespace Api.Data.Contexts
{
    public class CheckListContext : DbContext
    {
        public CheckListContext(DbContextOptions<CheckListContext> options)
        : base(options)
        {

        }

        public DbSet<CheckList> CheckLists {get; set;}
        public DbSet<CheckListToItem> CheckListToItems {get; set;}
        public DbSet<Item> Items {get; set;}
        public DbSet<ItemDetail> ItemDetails {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckListToItem>()
                .HasKey(cti => new { cti.ItemId, cti.CheckListId }
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
                    Name = "T-shirt",
                    Description = "This is a checklist for my full marathon!"
                }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item {
                    Id = 1,
                    Name = "T-shirt",
                    ItemDetailId = 1
                },
                new Item {
                    Id = 2,
                    Name = "Pants",
                    ItemDetailId = 2
                },
                new Item {
                    Id = 3,
                    Name = "Water Bottle",
                    ItemDetailId = 3
                },
                new Item {
                    Id = 4,
                    Name = "Toothbrush",
                    ItemDetailId = 4
                }
            );

            modelBuilder.Entity<ItemDetail>().HasData(
                new ItemDetail {
                    Id = 1,
                    Description = "Extra T-shirts",
                    Ready = false,
                    Quantity = 3
                },
                new ItemDetail {
                    Id = 1,
                    Description = "Extra Pants",
                    Ready = false,
                    Quantity = 1
                },
                new ItemDetail {
                    Id = 1,
                    Description = "Empty Bottle",
                    Ready = false,
                    Quantity = 1
                },
                new ItemDetail {
                    Id = 1,
                    Description = "Bring the electric one!",
                    Ready = false,
                    Quantity = 1
                }
            );


             modelBuilder.Entity<CheckListToItem>().HasData(
                new CheckListToItem { CheckListId = 1, ItemId = 1 },
                new CheckListToItem { CheckListId = 1, ItemId = 2 },
                new CheckListToItem { CheckListId = 1, ItemId = 3 },
                new CheckListToItem { CheckListId = 1, ItemId = 4 },
            );
        }

    }
}
