using FluentValidation;

namespace Application.Features.Exams.Commands.Update;

public class UpdateExamCommandValidator : AbstractValidator<UpdateExamCommand>
{
    public UpdateExamCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Time).NotEmpty();
        RuleFor(c => c.QuestionNumber).NotEmpty();
        RuleFor(c => c.QuestionType).NotEmpty();
    }
}