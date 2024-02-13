using Application.Features.ModuleSetCategories.Commands.Create;
using Application.Features.ModuleSetCategories.Commands.Delete;
using Application.Features.ModuleSetCategories.Commands.Update;
using Application.Features.ModuleSetCategories.Queries.GetById;
using Application.Features.ModuleSetCategories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModuleSetCategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateModuleSetCategoryCommand createModuleSetCategoryCommand)
    {
        CreatedModuleSetCategoryResponse response = await Mediator.Send(createModuleSetCategoryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateModuleSetCategoryCommand updateModuleSetCategoryCommand)
    {
        UpdatedModuleSetCategoryResponse response = await Mediator.Send(updateModuleSetCategoryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedModuleSetCategoryResponse response = await Mediator.Send(new DeleteModuleSetCategoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdModuleSetCategoryResponse response = await Mediator.Send(new GetByIdModuleSetCategoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListModuleSetCategoryQuery getListModuleSetCategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListModuleSetCategoryListItemDto> response = await Mediator.Send(getListModuleSetCategoryQuery);
        return Ok(response);
    }
}