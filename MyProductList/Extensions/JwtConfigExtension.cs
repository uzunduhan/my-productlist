using MyProductList.Base.Jwt;

namespace MyProductList.Extensions
{
    public static class JwtConfigExtension
    {
        public static JwtConfig JwtConfig { get; private set; }
        public static void AddJwtConfig(this IServiceCollection services, IConfiguration configuration)
        {
            JwtConfig = configuration.GetSection("JwtConfig").Get<JwtConfig>();
            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));
        }
    }
}
