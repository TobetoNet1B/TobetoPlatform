using Application.Features.CourseModules.Commands.Create;
using Application.Features.CourseModules.Commands.Delete;
using Application.Features.CourseModules.Commands.Update;
using Application.Features.CourseModules.Queries.GetById;
using Application.Features.CourseModules.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseModulesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCourseModuleCommand createCourseModuleCommand)
    {
        CreatedCourseModuleResponse response = await Mediator.Send(createCourseModuleCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCourseModuleCommand updateCourseModuleCommand)
    {
        UpdatedCourseModuleResponse response = await Mediator.Send(updateCourseModuleCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedCourseModuleResponse response = await Mediator.Send(new DeleteCourseModuleCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCourseModuleResponse response = await Mediator.Send(new GetByIdCourseModuleQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCourseModuleQuery getListCourseModuleQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCourseModuleListItemDto> response = await Mediator.Send(getListCourseModuleQuery);
        return Ok(response);
    }
}