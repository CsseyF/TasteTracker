using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TasteTracker.Application.Repositories;
using TasteTracker.Application.Repositories.Interfaces;
using TasteTracker.Application.Services;
using TasteTracker.Application.Services.Interfaces;
using TasteTracker.Core;

namespace TasteTracker.Persistence
{
    public class Builder
    {
        public static void DbContextBuilder(IServiceCollection services)
        {
            services.AddDbContext<TasteTrackerContext>(options =>
                options.UseSqlServer("Server=localhost,1433;Database=TasteTrackerDb;User=sa;Password=tasteTracker2929;TrustServerCertificate=True",
                b => b.MigrationsAssembly("TasteTracker.Persistence")));
        }

        public static void RepositoryBuilder(IServiceCollection services)
        {  
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();
        }

        public static void ServiceBuilder(IServiceCollection services)
        {
            services.AddScoped(typeof(IService<,>), typeof(Service<,>));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IRestauranteService, RestauranteService>();
            services.AddScoped<IHashingService, HashingService>();
        }
    }

}
