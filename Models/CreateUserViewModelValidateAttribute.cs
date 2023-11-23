using System.ComponentModel.DataAnnotations;
using TWValidacao.Attributes;

namespace TWValidacao.Models;

public class CreateUserViewModelValidateAttribute : IValidatableObject
{
    [Required (ErrorMessage = " e obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "deve ter entre 3 e 100 caracteres")]
    public string FirstName { get; set; }  = string.Empty;

    [Required (ErrorMessage = " e obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "deve ter entre 3 e 100 caracteres")]
    public string LastName { get; set; }  = string.Empty;

    [Required (ErrorMessage = " e obrigatorio")]
    [StringLength(255, ErrorMessage = "dever ter no maximo 255")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required (ErrorMessage = " e obrigatorio")]
    // [AgeBetween(100,18, ErrorMessage = "deve ter entre 18 e 100 anos")]
    public DateTime BirthDay { get; set; }

    [Required (ErrorMessage = " e obrigatorio")]
    [Phone]
    [RegularExpression("\\([0-9]{2}\\) [0-9]{1} [0-9]{4}-[0-9]{4}", ErrorMessage = "não esta no formato correto Ex.:(99) 9 9999-9999")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Url]
    [Required (ErrorMessage = " e obrigatorio")]
    public string ProfilePicture { get; set; } = string.Empty;
    
    [Required (ErrorMessage = " e obrigatorio")]
    [StringLength(255, MinimumLength = 3, ErrorMessage = "deve ter entre 5 e 255 caracteres")]
    public string Password { get; set; } = string.Empty;

    [Required (ErrorMessage = " e obrigatorio")]
    [Compare(nameof(Password), ErrorMessage = "Senhas nao conferem")]
    [StringLength(255, MinimumLength = 3, ErrorMessage = "deve ter entre 5 e 255 caracteres")]
    public string PasswordConfirmation { get; set; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var age = calculateAge(BirthDay);

        if(age < 18  || age > 100) 
        {
            yield return new ValidationResult("deve ter entre 18 e 100 anos",new []{nameof(BirthDay)});
        }
    }

        private int calculateAge(DateTime birthDate )
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;

        if(birthDate.Date > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }
}