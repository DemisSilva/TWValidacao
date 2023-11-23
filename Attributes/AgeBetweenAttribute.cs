using System.ComponentModel.DataAnnotations;

namespace TWValidacao.Attributes;

public class AgeBetweenAttribute : ValidationAttribute
{
    public int Min { get; set; }
    public int Max { get; set; }

        public AgeBetweenAttribute(int max,int min = 0)
    { 
        Max = max;
        Min = min;
    }

    public override bool IsValid(object? value)
    {
        if(value is null)
        {
            return true;
        }

        var birthDate = Convert.ToDateTime(value);
        var age = calculateAge(birthDate);

        return age >= Min && age <= Max;
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