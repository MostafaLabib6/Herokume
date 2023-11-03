
using Herokume.Application.Contracts.Persistance;
using Herokume.Persisitance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Herokume.Persisitance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<HerokumeDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("HerokumeConnectionString")));

            services.AddScoped(typeof(IGenaricRepository<>),typeof(GenaricRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
            services.AddScoped<ISeriesRepository, SeriesRepository>();


            return services;
        }
    }
}
