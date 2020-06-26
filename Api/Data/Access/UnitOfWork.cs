using Api.Data.Models;
using Api.Interfaces;
using Api.Data.Contexts;

namespace Api.Data.Access
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReadyToGoContext _context;
        private DataRepository<CheckList> _checklists;
        private DataRepository<Item> _items;
        private DataRepository<ItemDetail> _itemDetails;

        public UnitOfWork(ReadyToGoContext context)
        {
            _context = context;
        }
        public IDataRepository<CheckList> CheckLists
        {
            get { return _checklists ?? (_checklists = new DataRepository<CheckList>(_context));}
        }

        public IDataRepository<Item> Items
        {
            get { return _items ?? (_items = new DataRepository<Item>(_context));}
        }

        public IDataRepository<ItemDetail> ItemDetails
        {
            get { return _itemDetails ?? (_itemDetails = new DataRepository<ItemDetail>(_context));}
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
