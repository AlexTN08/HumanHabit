using MediatR;
using Microsoft.AspNetCore.Mvc;
using HumanHabit.Application.DTOs.Habits;
using HumanHabit.Application.Habits.Commands;
using HumanHabit.Application.Habits.Queries;

namespace HumanHabit.Api.Controllers;

[ApiController]
[Route("api/{controller}")]
public class HabitsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HabitDto>>> GetAsync()
    {
        var dtos =  await sender.Send(new GetAllHabitQuery());
        return Ok(dtos);
    }
    
    [HttpPost]
    public async Task<ActionResult<HabitDto>> AddAsync(CreateHabitDto createHabitDto)
    {
        var habitDto = await sender.Send(new CreateHabitCommand(createHabitDto));
        return CreatedAtAction(null, habitDto);
    }
}