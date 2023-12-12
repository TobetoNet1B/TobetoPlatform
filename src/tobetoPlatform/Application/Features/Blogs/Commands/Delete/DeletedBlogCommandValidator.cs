using FluentValidation;

namespace Application.Features.Blogs.Commands.Delete;

public class DeleteBlogCommandValidator : AbstractValidator<DeleteBlogCommand>
{
    public DeleteBlogCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}