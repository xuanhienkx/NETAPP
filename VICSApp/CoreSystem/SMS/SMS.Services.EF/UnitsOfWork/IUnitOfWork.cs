namespace SMS.Data.Services.EF.UnitsOfWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}