using Domain.Entities;
using Models.UserModels;

namespace WebUI.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<UserRegisterModel, User>();
            });
        }
    }
}