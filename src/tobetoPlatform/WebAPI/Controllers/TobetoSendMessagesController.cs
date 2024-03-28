using Application.Features.TobetoSendMessages.Commands.Create;
using Application.Features.TobetoSendMessages.Commands.Delete;
using Application.Features.TobetoSendMessages.Commands.Update;
using Application.Features.TobetoSendMessages.Queries.GetById;
using Application.Features.TobetoSendMessages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TobetoSendMessagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTobetoSendMessageCommand createTobetoSendMessageCommand)
    {
        CreatedTobetoSendMessageResponse response = await Mediator.Send(createTobetoSendMessageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTobetoSendMessageCommand updateTobetoSendMessageCommand)
    {
        UpdatedTobetoSendMessageResponse response = await Mediator.Send(updateTobetoSendMessageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedTobetoSendMessageResponse response = await Mediator.Send(new DeleteTobetoSendMessageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdTobetoSendMessageResponse response = await Mediator.Send(new GetByIdTobetoSendMessageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTobetoSendMessageQuery getListTobetoSendMessageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTobetoSendMessageListItemDto> response = await Mediator.Send(getListTobetoSendMessageQuery);
        return Ok(response);
    }
}