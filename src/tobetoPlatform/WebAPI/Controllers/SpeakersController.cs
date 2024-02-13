using Application.Features.Speakers.Commands.Create;
using Application.Features.Speakers.Commands.Delete;
using Application.Features.Speakers.Commands.Update;
using Application.Features.Speakers.Queries.GetById;
using Application.Features.Speakers.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpeakersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSpeakerCommand createSpeakerCommand)
    {
        CreatedSpeakerResponse response = await Mediator.Send(createSpeakerCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSpeakerCommand updateSpeakerCommand)
    {
        UpdatedSpeakerResponse response = await Mediator.Send(updateSpeakerCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSpeakerResponse response = await Mediator.Send(new DeleteSpeakerCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSpeakerResponse response = await Mediator.Send(new GetByIdSpeakerQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSpeakerQuery getListSpeakerQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSpeakerListItemDto> response = await Mediator.Send(getListSpeakerQuery);
        return Ok(response);
    }
}