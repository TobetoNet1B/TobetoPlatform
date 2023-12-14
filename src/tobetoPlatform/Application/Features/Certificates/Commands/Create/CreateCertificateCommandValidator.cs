using FluentValidation;

namespace Application.Features.Certificates.Commands.Create;

public class CreateCertificateCommandValidator : AbstractValidator<CreateCertificateCommand>
{
    public CreateCertificateCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.FileType).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
    }
}