using ElectionManagement.Models;
using ElectionManagement.WebAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ElectionManagement.WebAPI.Repository
{
    public class ConstituencyRepository : IConstituencyRepository
    {
        private readonly ElectionManagementDbContext dbContext;

        public ConstituencyRepository(ElectionManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        async Task<IEnumerable<Constituency>> IRepository<Constituency>.GetAll()
        {
            var constituency = await dbContext.Constituency
                            .Include(e => e.State)
                            .ToListAsync();

            return await Task.FromResult(constituency);
        }

       public async Task<IEnumerable<State>> GetStates()
        {
            var states = await dbContext.State                            
                            .ToListAsync();

            return await Task.FromResult(states);
        }

        async Task<Constituency> IRepository<Constituency>.GetById(int id)
        {
            return await dbContext.Constituency.FindAsync(id);
        }

        public async Task<int> InsertRecord(Constituency constituency)
        {
            dbContext.Constituency.Add(constituency);
            return await Task.FromResult(dbContext.SaveChanges());

        }
    }
}
