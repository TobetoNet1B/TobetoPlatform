using FluentValidation;
using System.Security.Principal;

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

        /*RuleFor(c => c.IdentityNumber)
            .NotEmpty().WithMessage("TC kimlik numarasý boþ olamaz.")
            .Length(11).WithMessage("TC kimlik numarasý 11 haneli olmalýdýr.")
            .Must(BeNumeric).WithMessage("TC kimlik numarasý sadece rakamlardan oluþmalýdýr.")
            .Must(NotAllDigitsAreSame).WithMessage("TC kimlik numarasýnýn tüm rakamlarý ayný olamaz.")
            .Must(FirstDigitIsNotZero).WithMessage("TC kimlik numarasýnýn ilk hanesi 0 olamaz.")
            .Must(ValidateLastDigit).WithMessage("TC kimlik numarasýnýn son hanesi geçerli deðildir.");*/
    }
    /*
    private bool BeNumeric(string value)
    {
        return value.All(char.IsDigit);
    }

    private bool NotAllDigitsAreSame(string value)
    {
        return !value.Distinct().Count().Equals(1);
    }

    private bool FirstDigitIsNotZero(string value)
    {
        return value[0] != '0';
    }

    private bool ValidateLastDigit(string value)
    {
        int sum = value.Take(10).Sum(c => c - '0');
        int lastDigit = sum % 10;
        return lastDigit == (value[10] - '0');
    }*/


    
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