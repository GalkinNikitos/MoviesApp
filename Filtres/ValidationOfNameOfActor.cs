using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Filtres;

public class ValidationOfNameOfActor : ValidationAttribute
{

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value.ToString().Length < 4) 
            return new ValidationResult(this.ErrorMessage);

        return ValidationResult.Success;
    }
}