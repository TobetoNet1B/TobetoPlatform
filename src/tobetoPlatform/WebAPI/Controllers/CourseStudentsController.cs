using Application.Features.CourseStudents.Commands.Create;
using Application.Features.CourseStudents.Commands.Delete;
using Application.Features.CourseStudents.Commands.Update;
using Application.Features.CourseStudents.Queries.GetById;
using Application.Features.CourseStudents.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseStudentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCourseStudentCommand createCourseStudentCommand)
    {
        CreatedCourseStudentResponse response = await Mediator.Send(createCourseStudentCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCourseStudentCommand updateCourseStudentCommand)
    {
        UpdatedCourseStudentResponse response = await Mediator.Send(updateCourseStudentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedCourseStudentResponse response = await Mediator.Send(new DeleteCourseStudentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCourseStudentResponse response = await Mediator.Send(new GetByIdCourseStudentQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCourseStudentQuery getListCourseStudentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCourseStudentListItemDto> response = await Mediator.Send(getListCourseStudentQuery);
        return Ok(response);
    }
}