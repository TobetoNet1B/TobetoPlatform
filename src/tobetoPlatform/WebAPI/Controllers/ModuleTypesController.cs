using Application.Features.ModuleTypes.Commands.Create;
using Application.Features.ModuleTypes.Commands.Delete;
using Application.Features.ModuleTypes.Commands.Update;
using Application.Features.ModuleTypes.Queries.GetById;
using Application.Features.ModuleTypes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModuleTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateModuleTypeCommand createModuleTypeCommand)
    {
        CreatedModuleTypeResponse response = await Mediator.Send(createModuleTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateModuleTypeCommand updateModuleTypeCommand)
    {
        UpdatedModuleTypeResponse response = await Mediator.Send(updateModuleTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedModuleTypeResponse response = await Mediator.Send(new DeleteModuleTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdModuleTypeResponse response = await Mediator.Send(new GetByIdModuleTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListModuleTypeQuery getListModuleTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListModuleTypeListItemDto> response = await Mediator.Send(getListModuleTypeQuery);
        return Ok(response);
    }
}