using FluentValidation;

namespace Application.Features.Students.Commands.Create;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(c => c.IdentityNumber).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.About).NotEmpty();
        RuleFor(c => c.ImgUrl).NotEmpty();

        RuleFor(c => c.IdentityNumber).Must(BeValidIdentityNumber);

        RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarasý boþ olamaz.")
            .Matches(@"^+?\d{10,15}$").WithMessage("Geçerli bir telefon numarasý giriniz.");

        RuleFor(c => c.BirthDate)
            .LessThanOrEqualTo(DateTime.Today);


    }




    private bool BeValidIdentityNumber(string identityNumber)
    {
        if (string.IsNullOrEmpty(identityNumber) || identityNumber.Length != 11)
        {
            return false;
        }

        if (identityNumber[0] == '0')
        {
            return false;
        }

        int sumFirst = 0, sumSecond = 0;
        for (int i = 0; i < 9; i += 2)
        {
            sumFirst += int.Parse(identityNumber[i].ToString());
        }
        for (int i = 1; i < 8; i += 2)
        {
            sumSecond += int.Parse(identityNumber[i].ToString());
        }

        int sumTotal = sumFirst + sumSecond + int.Parse(identityNumber[9].ToString());
        int lastDigit = sumTotal % 10;
        if (lastDigit != int.Parse(identityNumber[10].ToString()))
        {
            return false;
        }

        return true;
    }
}
