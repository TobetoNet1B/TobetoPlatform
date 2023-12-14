using FluentValidation;

namespace Application.Features.Educations.Commands.Delete;

public class DeleteEducationCommandValidator : AbstractValidator<DeleteEducationCommand>
{
    public DeleteEducationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}