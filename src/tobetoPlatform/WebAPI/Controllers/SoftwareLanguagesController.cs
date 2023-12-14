using Application.Features.SoftwareLanguages.Commands.Create;
using Application.Features.SoftwareLanguages.Commands.Delete;
using Application.Features.SoftwareLanguages.Commands.Update;
using Application.Features.SoftwareLanguages.Queries.GetById;
using Application.Features.SoftwareLanguages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SoftwareLanguagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSoftwareLanguageCommand createSoftwareLanguageCommand)
    {
        CreatedSoftwareLanguageResponse response = await Mediator.Send(createSoftwareLanguageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSoftwareLanguageCommand updateSoftwareLanguageCommand)
    {
        UpdatedSoftwareLanguageResponse response = await Mediator.Send(updateSoftwareLanguageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSoftwareLanguageResponse response = await Mediator.Send(new DeleteSoftwareLanguageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSoftwareLanguageResponse response = await Mediator.Send(new GetByIdSoftwareLanguageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSoftwareLanguageQuery getListSoftwareLanguageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSoftwareLanguageListItemDto> response = await Mediator.Send(getListSoftwareLanguageQuery);
        return Ok(response);
    }
}