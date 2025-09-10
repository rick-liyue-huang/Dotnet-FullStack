namespace API.Features.Games.GetGame;

public record GameDetailsDto(
    Guid Id,
    string Name,
    string Description,
    Guid GenreId,
    decimal Price,
    DateOnly ReleaseDate);