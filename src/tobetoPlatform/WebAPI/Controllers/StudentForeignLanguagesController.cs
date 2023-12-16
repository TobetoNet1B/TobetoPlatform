using Application.Features.StudentForeignLanguages.Commands.Create;
using Application.Features.StudentForeignLanguages.Commands.Delete;
using Application.Features.StudentForeignLanguages.Commands.Update;
using Application.Features.StudentForeignLanguages.Queries.GetById;
using Application.Features.StudentForeignLanguages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentForeignLanguagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentForeignLanguageCommand createStudentForeignLanguageCommand)
    {
        CreatedStudentForeignLanguageResponse response = await Mediator.Send(createStudentForeignLanguageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStudentForeignLanguageCommand updateStudentForeignLanguageCommand)
    {
        UpdatedStudentForeignLanguageResponse response = await Mediator.Send(updateStudentForeignLanguageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStudentForeignLanguageResponse response = await Mediator.Send(new DeleteStudentForeignLanguageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStudentForeignLanguageResponse response = await Mediator.Send(new GetByIdStudentForeignLanguageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentForeignLanguageQuery getListStudentForeignLanguageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentForeignLanguageListItemDto> response = await Mediator.Send(getListStudentForeignLanguageQuery);
        return Ok(response);
    }
}