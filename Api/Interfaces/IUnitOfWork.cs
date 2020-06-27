using Api.Data.Models;

namespace Api.Interfaces
{
    public interface IUnitOfWork
    {
        IDataRepository<CheckList> CheckLists { get; }
        IDataRepository<Item> Items { get; }
        IDataRepository<ItemDetail> ItemDetails { get; }
        IDataRepository<CheckListToItem> CheckListToItems { get; }
        void Save();
    }
}
