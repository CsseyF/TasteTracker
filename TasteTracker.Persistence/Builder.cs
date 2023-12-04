using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TasteTracker.Application.Dtos;
using TasteTracker.Application.Repositories;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Application.Services;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core.Entities.Interfaces;

namespace TasteTracker.Persistence
{
    public class Builder
    {
        public static void DbContextBuilder(IServiceCollection services)
        {
            services.AddDbContext<DbContext>(options =>
                options.UseSqlServer("Server=localhost,1433;Database=TasteTrackerDb;User=sa;Password=tastetracker", 
                b => b.MigrationsAssembly("TasteTracker.API")));
        }

        public static void RepositoryBuilder(IServiceCollection services)
        {
            services.AddScoped<IRepository<IEntity, FilterableRequest>,
                Repository<IEntity, FilterableRequest>>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();
        }

        public static void ServiceBuilder(IServiceCollection services)
        {
            services.AddScoped<IService<IEntity, FilterableRequest>,
                Service<IEntity, FilterableRequest>>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IRestauranteService, RestauranteService>();
        }
    }

}
