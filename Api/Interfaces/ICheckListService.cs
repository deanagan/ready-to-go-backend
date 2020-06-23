using System.Collections.Generic;

using Api.Data.Models;

namespace Api.Interfaces
{
    public interface ICheckListService
    {
        IEnumerable<CheckList> GetCheckLists();
        CheckList GetCheckList(int id);
    }

}
