using System.Net.Http.Json;
using HumanHabit.Application.DTOs.Habits;
using HumanHabit.Domain.Entities;

namespace HumanHabit.Test.IntegrationTests.Tests;

public class HabitsTest(WebAppFactory appFactory) : IClassFixture<WebAppFactory>
{
    [Fact]
    public async Task CreateHabit_Succeeds_WithValidParameters()
    {
        // Arrange
        var client = appFactory.CreateClient();
        var dto = new CreateHabitDto
        {
            Name = "Human Habit",
            Description = "Human Habit Description"
        };

        // Act
        var response = await client.PostAsJsonAsync(Routes.Habits.Create, dto);
        var habitDto = await response.Content.ReadFromJsonAsync<HabitDto>();

        // Assert
        Assert.NotNull(habitDto);
        Assert.Equal(dto.Name, habitDto.Name);
        Assert.Equal(dto.Description, habitDto.Description);
        Assert.Equal(Status.Active, habitDto.Status);
    }
}