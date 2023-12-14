using Application.Features.LessonTags.Commands.Create;
using Application.Features.LessonTags.Commands.Delete;
using Application.Features.LessonTags.Commands.Update;
using Application.Features.LessonTags.Queries.GetById;
using Application.Features.LessonTags.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonTagsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLessonTagCommand createLessonTagCommand)
    {
        CreatedLessonTagResponse response = await Mediator.Send(createLessonTagCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLessonTagCommand updateLessonTagCommand)
    {
        UpdatedLessonTagResponse response = await Mediator.Send(updateLessonTagCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedLessonTagResponse response = await Mediator.Send(new DeleteLessonTagCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdLessonTagResponse response = await Mediator.Send(new GetByIdLessonTagQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLessonTagQuery getListLessonTagQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLessonTagListItemDto> response = await Mediator.Send(getListLessonTagQuery);
        return Ok(response);
    }
}