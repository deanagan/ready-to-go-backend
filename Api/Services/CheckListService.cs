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
            if (checkList == null)
            {
                return null;
            }

            return new CheckListView {
                    Name = checkList.Name,
                    Description = checkList.Description,
                    ItemViews = (from checklistItemDetail in _unitOfWork.CheckListToItemDetails.GetAll()
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
                                Notes = itemDetail.Notes
                            }).ToList()
                };
        }

        public IEnumerable<CheckListView> GetCheckLists()
        {
            var items =
                   (from checkList in _unitOfWork.CheckLists.GetAll()
                    select new CheckListView {
                        Name = checkList.Name,
                        Description = checkList.Description,
                        ItemViews = (from checklistItemDetail in _unitOfWork.CheckListToItemDetails.GetAll()
                            where checklistItemDetail.CheckListId == checkList.Id
                            join itemDetail in _unitOfWork.ItemDetails.GetAll()
                            on checklistItemDetail.ItemDetailId equals itemDetail.Id
                            join item in _unitOfWork.Items.GetAll()
                            on itemDetail.ItemId equals item.Id
                            select new ItemView {
                                Name = item.Name,
                                Description = item.Description,
                                Quantity = itemDetail.Quantity,
                                IsReady = itemDetail.Ready,
                                Notes = itemDetail.Notes
                            }).ToList()
                    }
                    );
            return items.ToList();
        }

        public void CreateCheckList(CheckListView checkListView)
        {
            var checkList = new CheckList {
                Name = checkListView.Name,
                Description = checkListView.Description
            };

            _unitOfWork.CheckLists.Add(checkList);

            var itemDetails = checkListView.ItemViews.Select(itemView =>
                    new ItemDetail {
                        Ready = itemView.IsReady,
                        Quantity = itemView.Quantity,
                        Notes = itemView.Notes
                    });

            _unitOfWork.ItemDetails.AddRange(itemDetails);

            _unitOfWork.CheckListToItemDetails.AddRange(itemDetails.Select(itemDetail =>
                    new CheckListToItemDetail {
                        ItemDetailId = itemDetail.Id,
                        CheckListId = checkList.Id
                    }));

            _unitOfWork.Items.AddRange(
                itemDetails.Zip(checkListView.ItemViews, (itemDetail, itemView) =>
                    new Item {
                        Name = itemView.Name,
                        Description = itemView.Description,
                        ItemDetail = itemDetail
                    }
            ));

        }
    }
}
