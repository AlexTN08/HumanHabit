using HumanHabit.Domain.Entities;

namespace HumanHabit.Application.Common.Interfaces;

public interface IHabitRepository
{
    Task<IEnumerable<Habit>> GetAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Habit habit, CancellationToken cancellationToken = default);
    Task<bool> AnyByNameAsync(string name, CancellationToken cancellationToken = default);
}