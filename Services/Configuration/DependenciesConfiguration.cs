using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces.Providers;
using Services.Interfaces.Services;
using Services.Mapping;
using Services.Providers;
using Services.Services;
using Snippet.BLL.Interfaces.Providers;


namespace Services.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection RegisterMappingConfig(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(
                 c => c.AddProfile<MappingConfiguration>(),
                 typeof(MappingConfiguration));

            return serviceCollection;
        }

        public static IServiceCollection RegisterProviders(this IServiceCollection serviceCollection)
        {
            

            serviceCollection.AddScoped<IPostProvider, PostProvider>();
            serviceCollection.AddScoped<ICommentProvider, CommentProvider>();
            serviceCollection.AddScoped<ITagProvider, TagProvider>();
            serviceCollection.AddScoped<ILanguageProvider, LanguageProvider>();
            serviceCollection.AddScoped<ILikeProvider, LikeProvider>();
            serviceCollection.AddScoped<IUserProvider, UserProvider>();
           

           

            return serviceCollection;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPostService, PostService>();
            serviceCollection.AddTransient<IPaginationService, PaginationService>();
            serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
            return serviceCollection;
        }

        public static IServiceCollection AddAuth0Authentication(this IServiceCollection services, string authority, string audience)
        {
            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = authority;
                options.Audience = audience;
            });
            return services;
        }
    }
}
