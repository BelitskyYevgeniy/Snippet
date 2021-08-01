using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces.Providers;
using Services.Mapping;
using Services.Providers;
using Snippet.BLL.Interfaces.Providers;
using Snippet.BLL.Providers;
using Snippet.BLL.Services;

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

            return serviceCollection;
        }
    }
}
