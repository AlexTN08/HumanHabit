using MediatR;
using HumanHabit.Application.Common.Interfaces;
using HumanHabit.Application.DTOs.Habits;

namespace HumanHabit.Application.Habits.Queries;

public sealed class GetAllHabitQuery : IRequest<IEnumerable<HabitDto>>;

public sealed class GetAllHabitQueryHandler(IHabitRepository repository) : IRequestHandler<GetAllHabitQuery, IEnumerable<HabitDto>>
{
    public async Task<IEnumerable<HabitDto>> Handle(GetAllHabitQuery request, CancellationToken cancellationToken)
    {
        var habits = await repository.GetAsync(cancellationToken);
        return habits.Select(habit => habit.ToDto());
    }
}