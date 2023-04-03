namespace CS.Common.Contract.VsdModels
{
    public class VsdMember  
    {
        public string Code { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string BicCode => $"VSD{ShortName}".PadRight(8, 'X');
        public bool IsActive { get; set; } 
    }
}