using System.Collections.Generic;
using System.Linq;
using Api.Data.Models;
using Api.Interfaces;
using Api.Data.Contexts;
using Api.Data.Access;

namespace Api.Services
{
    public class CheckListService : ICheckListService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CheckListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CheckListView GetCheckList(int id)
        {
            var checkList =  _unitOfWork.CheckLists.Get(id);

            return new CheckListView {
                    Name = checkList.Name,
                    Description = checkList.Description,
                    Items = GetItemViews(id).ToList()
                };
        }

        public IEnumerable<CheckListView> GetCheckLists()
        {
            var items =
                   (from checkLists in _unitOfWork.CheckLists.GetAll()
                    select new CheckListView {
                        Name = checkLists.Name,
                        Description = checkLists.Description,
                        Items = (from checklistItemDetail in _unitOfWork.CheckListToItemDetails.GetAll()
                            where checklistItemDetail.CheckListId == checkLists.Id
                            join itemDetail in _unitOfWork.ItemDetails.GetAll()
                            on checklistItemDetail.ItemDetailId equals itemDetail.Id
                            join item in _unitOfWork.Items.GetAll()
                            on itemDetail.ItemId equals item.Id
                            select new ItemView {
                                Name = item.Name,
                                Description = item.Description,
                                Quantity = itemDetail.Quantity,
                                IsReady = itemDetail.Ready,
                            }).ToList()
                    }
                    );
            return items.ToList();
        }

        private IEnumerable<ItemView> GetItemViews(int id)
        {
            var itemViews = from checklistItemDetail in _unitOfWork.CheckListToItemDetails.GetAll()
                            where checklistItemDetail.CheckListId == id
                            join itemDetail in _unitOfWork.ItemDetails.GetAll()
                            on checklistItemDetail.ItemDetailId equals itemDetail.Id
                            join item in _unitOfWork.Items.GetAll()
                            on itemDetail.ItemId equals item.Id
                            select new ItemView {
                                Name = item.Name,
                                Description = item.Description,
                                Quantity = itemDetail.Quantity,
                                IsReady = itemDetail.Ready,
                            };
            return itemViews.AsEnumerable();
        }
    }
}
