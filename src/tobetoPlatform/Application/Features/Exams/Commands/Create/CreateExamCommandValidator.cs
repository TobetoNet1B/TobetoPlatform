using FluentValidation;

namespace Application.Features.Exams.Commands.Create;

public class CreateExamCommandValidator : AbstractValidator<CreateExamCommand>
{
    public CreateExamCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        //RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Time).NotEmpty();
        RuleFor(c => c.QuestionCount).NotEmpty();
        RuleFor(c => c.QuestionType).NotEmpty();
    }
}