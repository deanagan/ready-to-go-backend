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
            var checkListWithItemDetails = _unitOfWork.CheckLists.GetAll()
                            .Join(
                                _unitOfWork.CheckListToItemDetails.GetAll(),
                                checklist => checklist.Id,
                                checklistToItem => checklistToItem.CheckListId,
                                (checklist, checklistToItem) => new
                                {
                                    checkListId = checklist.Id,
                                    checkListItemDetailId = checklistToItem.ItemDetailId,
                                    checkListName = checklist.Name,
                                    checklistDescription = checklist.Description
                                }
                            )
                            .Where(
                                queryResult => queryResult.checkListId == id
                            );

            var items = checkListWithItemDetails
                        .Join(
                            _unitOfWork.Items.GetAll(),
                            checklistWithItemId => checklistWithItemId.checkListItemDetailId,
                            items => items.Id,
                            (checkListWithItemIds, items) => new
                            {
                                itemId = items.Id,
                                itemDetailId = checkListWithItemIds.checkListItemDetailId,
                                itemDescription = items.Description,
                                itemName = items.Name
                            }
                        );

            var itemDetails = items
                              .Join(
                                _unitOfWork.ItemDetails.GetAll(),
                                item => item.itemDetailId,
                                itemDetail => itemDetail.Id,
                                (item, itemDetail) => new
                                {
                                    itemName = item.itemName,
                                    itemDescription = item.itemDescription,
                                    itemReadyState = itemDetail.Ready,
                                    itemQuantity = itemDetail.Quantity
                                }
                              );
            var checkList =  _unitOfWork.CheckLists.Get(id);


            return new CheckListView {
                    Name = checkList.Name,
                    Description = checkList.Description,
                    Items = (from Item in itemDetails
                            select new ItemView
                            {
                                Name = Item.itemName,
                                Description = Item.itemDescription,
                                IsReady = Item.itemReadyState,
                                Quantity = Item.itemQuantity
                            }).ToList()
                };
        }

        public IEnumerable<CheckListView> GetCheckLists()
        {
            return new List<CheckListView> {
                new CheckListView {
                    Name = "Marathon",
                    Description = "A checklist on what I need to do tomorrow",
                    Items =  new List<ItemView> {
                        new ItemView {
                            Name = "Water Bottle",
                            Description = "Something to drink from",
                            IsReady = true,
                            Quantity = 1
                        },
                        new ItemView {
                            Name = "Singlet",
                            Description = "This is required for the race",
                            IsReady = true,
                            Quantity = 1
                        },
                        new ItemView {
                            Name = "Fitbit",
                            Description = "Don't forget to bring this so we have a tracker.",
                            IsReady = true,
                            Quantity = 1
                        }
                    }
                },
                new CheckListView {
                    Name = "Basketball Game",
                    Description = "A checklist for when I play basketball",
                    Items =  new List<ItemView> {
                        new ItemView {
                            Name = "Water Bottle",
                            Description = "Something to drink from",
                            IsReady = true,
                            Quantity = 1
                        },
                        new ItemView {
                            Name = "Mouth guard",
                            Description = "Need this to avoid breaking my teeth",
                            IsReady = true,
                            Quantity = 1
                        },
                        new ItemView {
                            Name = "Headband",
                            Description = "Bring black head band.",
                            IsReady = true,
                            Quantity = 1
                        }
                    }
                },
            };
        }
    }
}
