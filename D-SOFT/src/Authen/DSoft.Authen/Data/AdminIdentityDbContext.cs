using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DSoft.Authen.Data;

public class AdminIdentityDbContext : IdentityDbContext
{
    public AdminIdentityDbContext(DbContextOptions<AdminIdentityDbContext> options)
      : base(options)
    {
    }
}