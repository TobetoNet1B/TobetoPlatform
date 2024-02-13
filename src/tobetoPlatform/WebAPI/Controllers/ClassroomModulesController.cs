using Application.Features.ClassroomModules.Commands.Create;
using Application.Features.ClassroomModules.Commands.Delete;
using Application.Features.ClassroomModules.Commands.Update;
using Application.Features.ClassroomModules.Queries.GetById;
using Application.Features.ClassroomModules.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassroomModulesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateClassroomModuleCommand createClassroomModuleCommand)
    {
        CreatedClassroomModuleResponse response = await Mediator.Send(createClassroomModuleCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateClassroomModuleCommand updateClassroomModuleCommand)
    {
        UpdatedClassroomModuleResponse response = await Mediator.Send(updateClassroomModuleCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedClassroomModuleResponse response = await Mediator.Send(new DeleteClassroomModuleCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdClassroomModuleResponse response = await Mediator.Send(new GetByIdClassroomModuleQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListClassroomModuleQuery getListClassroomModuleQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListClassroomModuleListItemDto> response = await Mediator.Send(getListClassroomModuleQuery);
        return Ok(response);
    }
}