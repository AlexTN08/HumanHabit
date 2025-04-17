using Microsoft.EntityFrameworkCore;
using HumanHabit.Application.Common.Interfaces;
using HumanHabit.Domain.Entities;
using HumanHabit.Infrastructure.Common;

namespace HumanHabit.Infrastructure.Habits;

public class HabitRepository(AppDbContext dbContext) : IHabitRepository
{
    public async Task<IEnumerable<Habit>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Habits.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Habit habit, CancellationToken cancellationToken = default)
    {
        dbContext.Habits.Add(habit);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> AnyByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await dbContext.Habits.AnyAsync(habit => habit.Name == name, cancellationToken);
    }
}