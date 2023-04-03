using AutoMapper;
using CS.Common.Contract.Models;
using CS.Domain.Audit.Entities;

namespace CS.Domain.Audit.AutoMapper
{
    public class ModelToEntityMappingProfile : Profile
    {
        public ModelToEntityMappingProfile()
        {
            CreateMap<CustomerModel, CustomerAudit>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<CustodyRequestModel, CustodyRequestHistory>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}