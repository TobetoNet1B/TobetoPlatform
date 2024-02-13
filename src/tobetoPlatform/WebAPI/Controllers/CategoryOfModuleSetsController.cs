using Application.Features.CategoryOfModuleSets.Commands.Create;
using Application.Features.CategoryOfModuleSets.Commands.Delete;
using Application.Features.CategoryOfModuleSets.Commands.Update;
using Application.Features.CategoryOfModuleSets.Queries.GetById;
using Application.Features.CategoryOfModuleSets.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryOfModuleSetsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryOfModuleSetCommand createCategoryOfModuleSetCommand)
    {
        CreatedCategoryOfModuleSetResponse response = await Mediator.Send(createCategoryOfModuleSetCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryOfModuleSetCommand updateCategoryOfModuleSetCommand)
    {
        UpdatedCategoryOfModuleSetResponse response = await Mediator.Send(updateCategoryOfModuleSetCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedCategoryOfModuleSetResponse response = await Mediator.Send(new DeleteCategoryOfModuleSetCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCategoryOfModuleSetResponse response = await Mediator.Send(new GetByIdCategoryOfModuleSetQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryOfModuleSetQuery getListCategoryOfModuleSetQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCategoryOfModuleSetListItemDto> response = await Mediator.Send(getListCategoryOfModuleSetQuery);
        return Ok(response);
    }
}