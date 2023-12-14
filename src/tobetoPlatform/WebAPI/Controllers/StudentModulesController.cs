using Application.Features.StudentModules.Commands.Create;
using Application.Features.StudentModules.Commands.Delete;
using Application.Features.StudentModules.Commands.Update;
using Application.Features.StudentModules.Queries.GetById;
using Application.Features.StudentModules.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentModulesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentModuleCommand createStudentModuleCommand)
    {
        CreatedStudentModuleResponse response = await Mediator.Send(createStudentModuleCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStudentModuleCommand updateStudentModuleCommand)
    {
        UpdatedStudentModuleResponse response = await Mediator.Send(updateStudentModuleCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStudentModuleResponse response = await Mediator.Send(new DeleteStudentModuleCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStudentModuleResponse response = await Mediator.Send(new GetByIdStudentModuleQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentModuleQuery getListStudentModuleQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentModuleListItemDto> response = await Mediator.Send(getListStudentModuleQuery);
        return Ok(response);
    }
}