using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Game
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(50)] 
    public required string Name { get; set; }

    [Required]
    [StringLength(500)]
    public required string Description { get; set; }
    
    public required Genre Genre { get; set; }
    
    [Required]
    [Range(1, 200)]
    public decimal Price { get; set; }
    
    public DateOnly ReleaseDate { get; set; }
}