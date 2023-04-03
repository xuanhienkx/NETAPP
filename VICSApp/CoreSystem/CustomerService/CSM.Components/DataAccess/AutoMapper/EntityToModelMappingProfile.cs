using AutoMapper;
using CSM.Common.Models;
using CSM.Components.DataAccess.Models;

namespace CSM.Components.DataAccess.AutoMapper
{
    public class EntityToModelMappingProfile : Profile
    {
        public EntityToModelMappingProfile()
        {
            CreateMap<Customer, CustomerModel>()
                .ForMember(d=>d.Name, opt=>opt.MapFrom(s=>s.CustomerName));
        }
    }
    public class ToEntityMappingProfile : Profile
    {
        public ToEntityMappingProfile()
        {
            CreateMap<CustomerModel, Customer>()
                .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Name));
        }
    }
}