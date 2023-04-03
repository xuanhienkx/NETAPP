namespace DO.Common.Domain.Interfaces;

public interface IIdentityEntity<TIdentity>
{
    TIdentity Id { get; set; }
}
public interface ICommonEntity<TIdentity> : IIdentityEntity<TIdentity>
{
}

public interface IReversionEntity<TIdentity> : IIdentityEntity<TIdentity>
{
    int Version { get; set; }
}

public interface IBranchBaseEntity
{
    long BranchId { get; set; }
}