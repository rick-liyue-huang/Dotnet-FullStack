using System.ComponentModel.DataAnnotations;

namespace API.Features.Games.CreateGame;

public record CreateGameDto(
    [Required]
    [StringLength(50)]
    string Name, 
    
    [Required]
    [StringLength(500)]
    string Description, 
    Guid GenreId, 
    
    [Required]
    [Range(1, 200)]
    decimal Price, 
    DateOnly ReleaseDate);
    
    
public record GameDetailsDto(
    Guid Id,
    string Name,
    string Description,
    Guid GenreId,
    decimal Price,
    DateOnly ReleaseDate);