using Application.Features.Blogs.Commands.Create;
using Application.Features.Blogs.Commands.Delete;
using Application.Features.Blogs.Commands.Update;
using Application.Features.Blogs.Queries.GetById;
using Application.Features.Blogs.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBlogCommand createBlogCommand)
    {
        CreatedBlogResponse response = await Mediator.Send(createBlogCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBlogCommand updateBlogCommand)
    {
        UpdatedBlogResponse response = await Mediator.Send(updateBlogCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBlogResponse response = await Mediator.Send(new DeleteBlogCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBlogResponse response = await Mediator.Send(new GetByIdBlogQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBlogQuery getListBlogQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBlogListItemDto> response = await Mediator.Send(getListBlogQuery);
        return Ok(response);
    }
}