using System.Collections.Generic;

using Api.Data.Models;

namespace Api.Interfaces
{
    public interface ICheckListService
    {
        IEnumerable<CheckListView> GetCheckLists();
        CheckListView GetCheckList(int id);
    }

}
