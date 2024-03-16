using Application.Features.TobetoContacts.Commands.Create;
using Application.Features.TobetoContacts.Commands.Delete;
using Application.Features.TobetoContacts.Commands.Update;
using Application.Features.TobetoContacts.Queries.GetById;
using Application.Features.TobetoContacts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TobetoContactsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTobetoContactCommand createTobetoContactCommand)
    {
        CreatedTobetoContactResponse response = await Mediator.Send(createTobetoContactCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTobetoContactCommand updateTobetoContactCommand)
    {
        UpdatedTobetoContactResponse response = await Mediator.Send(updateTobetoContactCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedTobetoContactResponse response = await Mediator.Send(new DeleteTobetoContactCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdTobetoContactResponse response = await Mediator.Send(new GetByIdTobetoContactQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTobetoContactQuery getListTobetoContactQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTobetoContactListItemDto> response = await Mediator.Send(getListTobetoContactQuery);
        return Ok(response);
    }
}