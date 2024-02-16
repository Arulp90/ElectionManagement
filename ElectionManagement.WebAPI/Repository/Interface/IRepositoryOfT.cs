
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectionManagement.WebAPI
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> InsertRecord(T recordToAdd);
    }
}