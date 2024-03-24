using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _253505_Azarov.Persistense.Data;
using _253505_Azarov.Persistense.UnitOfWork;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistense(this IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
        return services;
    }
    public static IServiceCollection AddPersistense(this IServiceCollection services,
        DbContextOptions options)
    { 
        services.AddPersistense()
        .AddSingleton<AppDbContext>(
            new AppDbContext((DbContextOptions<AppDbContext>) options));
        return services;
    }
}