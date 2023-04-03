namespace DO.Common.Contract
{

    public interface IResource<TIdentity>
    {
        TIdentity Id { get; set; }
    }

    public interface ICommonResource<TIdentity> : IResource<TIdentity>
    {

    }

    public interface IReversionResource<TIdentity> : IResource<TIdentity>
    {
        int Version { get; set; }
    }
}
