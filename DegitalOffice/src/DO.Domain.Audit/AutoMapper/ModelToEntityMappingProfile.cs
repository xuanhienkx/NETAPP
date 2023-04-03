using AutoMapper;
using DO.Common.Contract.Models;
using DO.Domain.Audit.Entities;

namespace DO.Domain.Audit.AutoMapper
{
    public class ModelToEntityMappingProfile : Profile
    {
        public ModelToEntityMappingProfile()
        {
            CreateMap<MarketInfoRequestModel, MarketRequestHistory>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}