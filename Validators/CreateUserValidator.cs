using FluentValidation;
using TWValidacao.Models;

namespace TWValidacao.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserViewModel>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.FirstName)
            .NotNull().WithMessage("Campo obrigatorio")
            .NotEmpty()
            .MinimumLength(3).WithMessage("Deve ter pelo menos 3 caracteres")
            .MaximumLength(100);

        RuleFor(user => user.LastName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(user => user.Email)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255)
            .EmailAddress();

        RuleFor(user => user.BirthDay)
            .NotNull()
            .NotEmpty()
            .AgeBetween(100,18).WithMessage("Deve ter entre 18 e 100 anos");

        RuleFor(user => user.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .Matches("\\([0-9]{2}\\) [0-9]{1} [0-9]{4}-[0-9]{4}");

        RuleFor(user => user.ProfilePicture)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(user => user.Password)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255);
        
         RuleFor(user => user.PasswordConfirmation)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255)
            .Must((user, passwordConfirmation)=> string.Equals(passwordConfirmation, user.Password));

            
    }
  
}