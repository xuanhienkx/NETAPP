namespace CS.Common.Contract.Enums
{
    public enum AccessType : byte
    {
        //access type for Y/N
        Deny = 0,
        Allow = 1 ,
        // access type for CRUD
        View = 2,
        Add = 3,
        Override = 4,
        Delete = 5,
    }
}
