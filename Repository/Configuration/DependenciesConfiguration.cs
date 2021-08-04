using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snippet.Data.Context;
using Snippet.Data.Interfaces.Repositories;
using Snippet.Data.Repositories;

namespace Snippet.Data.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, string connectionString)
        {
            AddRepositoryContext(services, connectionString);
            services.AddScoped<IUserRepositoryAsync, UserRepository>();
            services.AddScoped<ITagRepositoryAsync, TagRepository>();
            services.AddScoped<ILanguageRepositoryAsync, LanguageRepository>();
            services.AddScoped<IPostRepositoryAsync, PostRepository>();
            services.AddScoped<ICommentRepositoryAsync, CommentRepository>();
            services.AddScoped<ILikeRepositoryAsync, LikeRepository>();
            return services;
        }
        public static IServiceCollection AddRepositoryContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
