using Microsoft.EntityFrameworkCore.Design;

namespace CS.Domain.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CSoftDataContext>
    {
        public CSoftDataContext CreateDbContext(string[] args)
        {
            return new CSoftDataContext(null);
        }
    }
}
