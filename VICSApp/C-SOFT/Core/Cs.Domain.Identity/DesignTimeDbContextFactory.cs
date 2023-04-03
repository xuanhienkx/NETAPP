using Microsoft.EntityFrameworkCore.Design;

namespace CS.Domain.Identity
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityLoginDbContext>
    {
        public IdentityLoginDbContext CreateDbContext(string[] args)
        {
            return new IdentityLoginDbContext(null);
        }
    }
}
