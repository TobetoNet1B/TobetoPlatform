using Application.Features.CategoryOfCourses.Commands.Create;
using Application.Features.CategoryOfCourses.Commands.Delete;
using Application.Features.CategoryOfCourses.Commands.Update;
using Application.Features.CategoryOfCourses.Queries.GetById;
using Application.Features.CategoryOfCourses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryOfCoursesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryOfCourseCommand createCategoryOfCourseCommand)
    {
        CreatedCategoryOfCourseResponse response = await Mediator.Send(createCategoryOfCourseCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryOfCourseCommand updateCategoryOfCourseCommand)
    {
        UpdatedCategoryOfCourseResponse response = await Mediator.Send(updateCategoryOfCourseCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedCategoryOfCourseResponse response = await Mediator.Send(new DeleteCategoryOfCourseCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCategoryOfCourseResponse response = await Mediator.Send(new GetByIdCategoryOfCourseQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryOfCourseQuery getListCategoryOfCourseQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCategoryOfCourseListItemDto> response = await Mediator.Send(getListCategoryOfCourseQuery);
        return Ok(response);
    }
}