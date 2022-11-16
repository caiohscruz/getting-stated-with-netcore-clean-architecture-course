using CleanArch.Application.AutoMapper;

namespace CleanArch.MVC.Configurations
{
    public static class AutoMapperConfig
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CleanArch.Application.AutoMapper.AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMappings();
        }
    }
}
