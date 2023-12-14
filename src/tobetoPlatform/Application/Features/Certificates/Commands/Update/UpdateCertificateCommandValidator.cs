using FluentValidation;

namespace Application.Features.Certificates.Commands.Update;

public class UpdateCertificateCommandValidator : AbstractValidator<UpdateCertificateCommand>
{
    public UpdateCertificateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.FileType).NotEmpty();
        RuleFor(c => c.FileUrl).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
    }
}