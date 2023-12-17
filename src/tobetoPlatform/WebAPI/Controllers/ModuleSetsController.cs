using Application.Features.ModuleSets.Commands.Create;
using Application.Features.ModuleSets.Commands.Delete;
using Application.Features.ModuleSets.Commands.Update;
using Application.Features.ModuleSets.Queries.GetById;
using Application.Features.ModuleSets.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModuleSetsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateModuleSetCommand createModuleSetCommand)
    {
        CreatedModuleSetResponse response = await Mediator.Send(createModuleSetCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateModuleSetCommand updateModuleSetCommand)
    {
        UpdatedModuleSetResponse response = await Mediator.Send(updateModuleSetCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedModuleSetResponse response = await Mediator.Send(new DeleteModuleSetCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdModuleSetResponse response = await Mediator.Send(new GetByIdModuleSetQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListModuleSetQuery getListModuleSetQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListModuleSetListItemDto> response = await Mediator.Send(getListModuleSetQuery);
        return Ok(response);
    }
}