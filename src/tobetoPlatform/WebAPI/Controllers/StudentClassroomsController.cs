using Application.Features.StudentClassrooms.Commands.Create;
using Application.Features.StudentClassrooms.Commands.Delete;
using Application.Features.StudentClassrooms.Commands.Update;
using Application.Features.StudentClassrooms.Queries.GetById;
using Application.Features.StudentClassrooms.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentClassroomsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentClassroomCommand createStudentClassroomCommand)
    {
        CreatedStudentClassroomResponse response = await Mediator.Send(createStudentClassroomCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStudentClassroomCommand updateStudentClassroomCommand)
    {
        UpdatedStudentClassroomResponse response = await Mediator.Send(updateStudentClassroomCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStudentClassroomResponse response = await Mediator.Send(new DeleteStudentClassroomCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStudentClassroomResponse response = await Mediator.Send(new GetByIdStudentClassroomQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentClassroomQuery getListStudentClassroomQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentClassroomListItemDto> response = await Mediator.Send(getListStudentClassroomQuery);
        return Ok(response);
    }
}