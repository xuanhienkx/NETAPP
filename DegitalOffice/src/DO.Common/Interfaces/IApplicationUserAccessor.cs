namespace DO.Common.Interfaces
{
    public interface IApplicationUserAccessor
    {
        //  Task<IApplicationUser> GetUser();
        Guid? GetUserId();
    }
}