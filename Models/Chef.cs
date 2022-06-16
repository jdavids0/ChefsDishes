#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsDishes.Models;

public class Chef
{
    [Key]
    public int ChefID {get; set;}
    [Required]
    [MinLength(2, ErrorMessage="First name must be at least 2 characters")]
    public string FirstName {get; set;}
    [Required]
    [MinLength(2, ErrorMessage="Last name must be at least 2 characters")]
    public string LastName {get; set;}
    [Required]
    public DateTime DateOfBirth {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    // navigation property for related Dish objects
    public List<Dish> CreatedDishes {get; set;} = new List<Dish>();

}

// .TryParse() or .TryParseExact()
/* public class DateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var today = "";
        if ()
        {

        }
        return base.IsValid(value, validationContext);
    }
} */