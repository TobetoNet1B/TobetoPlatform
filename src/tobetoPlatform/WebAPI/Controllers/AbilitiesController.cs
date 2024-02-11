using Application.Features.Abilities.Commands.Create;
using Application.Features.Abilities.Commands.Delete;
using Application.Features.Abilities.Commands.Update;
using Application.Features.Abilities.Queries.GetById;
using Application.Features.Abilities.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AbilitiesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAbilityCommand createAbilityCommand)
    {
        CreatedAbilityResponse response = await Mediator.Send(createAbilityCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAbilityCommand updateAbilityCommand)
    {
        UpdatedAbilityResponse response = await Mediator.Send(updateAbilityCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedAbilityResponse response = await Mediator.Send(new DeleteAbilityCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        List<GetByIdAbilityResponse> response = await Mediator.Send(new GetByIdAbilityQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAbilityQuery getListAbilityQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAbilityListItemDto> response = await Mediator.Send(getListAbilityQuery);
        return Ok(response);
    }
}