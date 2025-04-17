using HumanHabit.Domain.Entities;

namespace HumanHabit.Application.DTOs.Habits;

public static class HabitMapping
{
    public static HabitDto ToDto(this Habit habit)
    {
        return new HabitDto
        {
            Id = habit.Id,
            Name = habit.Name,
            Description = habit.Description,
            Status = habit.Status
        };
    }

    public static Habit ToEntity(this CreateHabitDto habitDto)
    {
        return new Habit
        {
            Id = Guid.NewGuid(),
            Name = habitDto.Name,
            Description = habitDto.Description,
            Status = Status.Active
        };
    }
}