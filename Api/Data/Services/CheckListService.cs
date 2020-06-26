using System.Collections.Generic;
using Api.Data.Models;
using Api.Interfaces;
using Api.Data.Contexts;
using Api.Data.Access;

namespace Api.Data.Services
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
            var t = _unitOfWork.Items;

            return new CheckListView {
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
