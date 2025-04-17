using Microsoft.Extensions.DependencyInjection;
using HumanHabit.Application.Common.Interfaces;
using HumanHabit.Infrastructure.Habits;

namespace HumanHabit.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IHabitRepository, HabitRepository>();
        
        return services;
    }
}