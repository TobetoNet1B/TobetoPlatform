using FluentValidation;

namespace Application.Features.Certificates.Commands.Create;

public class CreateCertificateCommandValidator : AbstractValidator<CreateCertificateCommand>
{
    public CreateCertificateCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.FileType).NotEmpty();
        RuleFor(c => c.FileUrl).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c).Must(c => IsPdf(c.FileType));
    }
    private bool IsPdf(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
            return false;

        string extension = fileName.ToLower();
        return extension.EndsWith(".pdf") || extension.EndsWith(".jpg") || extension.EndsWith(".jpeg");
    }
}