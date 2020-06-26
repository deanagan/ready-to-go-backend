using System.Collections.Generic;

namespace Api.Interfaces
{
    public interface IDataRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
