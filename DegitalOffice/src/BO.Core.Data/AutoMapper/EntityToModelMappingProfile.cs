using AutoMapper;
using BO.Core.DataCommon.Entities;
using DO.Common.Contract.Models;

namespace BO.Core.DataCommon.AutoMapper;

public class EntityToModelMappingProfile : Profile
{
    public EntityToModelMappingProfile()
    {
        CreateMap<User, UserModel>();
        CreateMap<MarketInfoRequest, MarketInfoRequestModel>();

    }
}
