using ElectionManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectionManagement.WebAPI
{
    public class PartyRepository : IPartyRepository
    {
        private readonly ElectionManagementDbContext dbContext;

        public PartyRepository(ElectionManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        async Task<IEnumerable<Party>> IRepository<Party>.GetAll()
        {
            var party = await dbContext.Party
                            .Include(e => e.SymbolsMaster)
                            .ToListAsync();

            return await Task.FromResult(party);
        }

        async Task<Party> IRepository<Party>.GetById(int id)
        {
            return await dbContext.Party.FindAsync(id);
        }

        public async Task<int> InsertRecord(Party party)
        {
            dbContext.Party.Add(party);
            return await Task.FromResult(dbContext.SaveChanges());

        }
    }
}
