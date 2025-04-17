using MediatR;
using HumanHabit.Application.Common.Interfaces;
using HumanHabit.Application.DTOs.Habits;
using HumanHabit.Domain.Exceptions.Habit;

namespace HumanHabit.Application.Habits.Commands;

public sealed class CreateHabitCommand(CreateHabitDto habitDto) : IRequest<HabitDto>
{
    public CreateHabitDto HabitDto { get; } = habitDto;
}

public sealed class CreateHabitCommandHandler(IHabitRepository repository) : IRequestHandler<CreateHabitCommand, HabitDto>
{
    public async Task<HabitDto> Handle(CreateHabitCommand request, CancellationToken cancellationToken)
    {
        var dto = request.HabitDto;
        
        // Any other business logic comes here in handler
        if (await repository.AnyByNameAsync(dto.Name, cancellationToken))
        {
            throw new HabitAlreadyExistsExceptions($"Habit with name {dto.Name} already exists");
        }
        
        var habit = dto.ToEntity();
        await repository.AddAsync(habit, cancellationToken);
        
        return habit.ToDto();
    }
}