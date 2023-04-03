using Microsoft.EntityFrameworkCore.Design;

namespace CS.Domain.Audit
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AuditDbContext>
    {
        public AuditDbContext CreateDbContext(string[] args)
        {
            return new AuditDbContext(null);
        }
    }
}
