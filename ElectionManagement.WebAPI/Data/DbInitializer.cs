using System.Diagnostics.CodeAnalysis;

namespace ElectionManagement.WebAPI
{
    public static class DbInitializer
    {
        [ExcludeFromCodeCoverage]
        public static void Initialize(ElectionManagementDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}