using AutoMapper;
using CS.Domain.Data.AutoMapper;

namespace CS.Core.Service
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToModelMappingProfile());
                cfg.AddProfile(new ModelToEntityMappingProfile());
                cfg.AddProfile(new Domain.Audit.AutoMapper.ModelToEntityMappingProfile());
            });
        }
    }
}
