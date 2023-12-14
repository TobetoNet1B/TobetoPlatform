using Application.Features.Modules.Commands.Create;
using Application.Features.Modules.Commands.Delete;
using Application.Features.Modules.Commands.Update;
using Application.Features.Modules.Queries.GetById;
using Application.Features.Modules.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModulesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateModuleCommand createModuleCommand)
    {
        CreatedModuleResponse response = await Mediator.Send(createModuleCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateModuleCommand updateModuleCommand)
    {
        UpdatedModuleResponse response = await Mediator.Send(updateModuleCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedModuleResponse response = await Mediator.Send(new DeleteModuleCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdModuleResponse response = await Mediator.Send(new GetByIdModuleQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListModuleQuery getListModuleQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListModuleListItemDto> response = await Mediator.Send(getListModuleQuery);
        return Ok(response);
    }
}