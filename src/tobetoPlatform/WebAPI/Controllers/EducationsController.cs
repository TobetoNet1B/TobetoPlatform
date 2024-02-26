using Application.Features.Educations.Commands.Create;
using Application.Features.Educations.Commands.Delete;
using Application.Features.Educations.Commands.Update;
using Application.Features.Educations.Queries.GetById;
using Application.Features.Educations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEducationCommand createEducationCommand)
    {
        CreatedEducationResponse response = await Mediator.Send(createEducationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEducationCommand updateEducationCommand)
    {
        UpdatedEducationResponse response = await Mediator.Send(updateEducationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedEducationResponse response = await Mediator.Send(new DeleteEducationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        List<GetByIdEducationResponse> response = await Mediator.Send(new GetByIdEducationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEducationQuery getListEducationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListEducationListItemDto> response = await Mediator.Send(getListEducationQuery);
        return Ok(response);
    }
}