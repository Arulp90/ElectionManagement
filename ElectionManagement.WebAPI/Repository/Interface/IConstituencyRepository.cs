using ElectionManagement.Models;

namespace ElectionManagement.WebAPI.Repository.Interface
{
    public interface IConstituencyRepository : IRepository<Constituency>
    {
        Task<IEnumerable<State>> GetStates();
    }
}
