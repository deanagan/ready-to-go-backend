using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Api.Interfaces;
using Api.Data.Models;
using Api.Data.Contexts;

namespace Api.Data.Access
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private readonly ReadyToGoContext _context;
        private readonly DbSet<T> _dbSet;
        public DataRepository(ReadyToGoContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;


            // var checklists = from CheckLists in _context.CheckLists
            //                  join CheckListToItems in _context.CheckListToItems
            //                  on CheckLists.Id equals CheckListToItems.CheckListId
            //                  join Items in _context.Items
            //                  on  CheckListToItems.CheckListId equals Items.Id
            //                  join ItemDetails in _context.ItemDetails
            //                  on Items.ItemDetailId equals ItemDetails.Id
            //                  select new CheckListView {
            //                      Name = CheckLists.Name,
            //                      Description = CheckLists.Description,
            //                      Items = new ItemView {
            //                         Name = Items.Name,
            //                         Description = ItemDetails.Description,
            //                         IsReady = ItemDetails.Ready,
            //                         Quantity = ItemDetails.Quantity
            //                      }
            //                  };

            return null;//new List<CheckListView> {
                // new CheckListView {
                //     Name = "Marathon",
                //     Description = "A checklist on what I need to do tomorrow",
                //     Items =  new List<ItemView> {
                //         new ItemView {
                //             Name = "Water Bottle",
                //             Description = "Something to drink from",
                //             IsReady = true,
                //             Quantity = 1
                //         },
                //         new ItemView {
                //             Name = "Singlet",
                //             Description = "This is required for the race",
                //             IsReady = true,
                //             Quantity = 1
                //         },
                //         new ItemView {
                //             Name = "Fitbit",
                //             Description = "Don't forget to bring this so we have a tracker.",
                //             IsReady = true,
                //             Quantity = 1
                //         }
                //     }
                // },
                // new CheckListView {
                //     Name = "Basketball Game",
                //     Description = "A checklist for when I play basketball",
                //     Items =  new List<ItemView> {
                //         new ItemView {
                //             Name = "Water Bottle",
                //             Description = "Something to drink from",
                //             IsReady = true,
                //             Quantity = 1
                //         },
                //         new ItemView {
                //             Name = "Mouth guard",
                //             Description = "Need this to avoid breaking my teeth",
                //             IsReady = true,
                //             Quantity = 1
                //         },
                //         new ItemView {
                //             Name = "Headband",
                //             Description = "Bring black head band.",
                //             IsReady = true,
                //             Quantity = 1
                //         }
                //     }
                // },
           // };
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

    }
}
