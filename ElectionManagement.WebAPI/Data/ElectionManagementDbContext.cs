
using ElectionManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectionManagement.WebAPI
{
    public class ElectionManagementDbContext : DbContext
    {
        public ElectionManagementDbContext() : base()
        {
            Database.EnsureCreated();
        }
        public ElectionManagementDbContext(DbContextOptions<ElectionManagementDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Party> Party { get; set; }
        public DbSet<SymbolsMaster> SymbolsMaster { get; set; }
        public DbSet<Constituency> Constituency { get; set; }
        public DbSet<State> State { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<State>().ToTable("State");
            modelBuilder.Entity<Constituency>().ToTable("Constituency");

        }
    }
}