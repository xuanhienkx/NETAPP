using AutoMapper;
using BO.Core.DataCommon.Entities;
using DO.Common.Contract.Models;

namespace BO.Core.DataCommon.AutoMapper;

public class ModelToEntityMappingProfile : Profile
{
    public ModelToEntityMappingProfile()
    {
        CreateMap<MarketInfoRequestModel, MarketInfoRequest>();
        CreateMap<UserModel, User>();
    }
}
