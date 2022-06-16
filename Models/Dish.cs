#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsDishes.Models;

public class Dish
{
    [Key]
    public int DishID {get; set;}
    [Required]
    [MinLength(2, ErrorMessage="Name must be at least 2 characters")]
    public string DishName {get; set;}
    [Required]
    [Range(0, Int32.MaxValue)]
    public int Calories {get; set;}
    [Required]
    [Range(1, 6)]
    public int Tastiness {get; set;}
    [Required]
    [MinLength(5, ErrorMessage="Description must be at least 5 characters")]
    public string Description {get; set;}
    [Required]
    public int ChefID {get; set;}
    // navigation property for related Chef obj
    public Chef? Creator {get; set;}
}