namespace API.Features.Games.GetGames;

public record GameSummaryDto(
    Guid Id,
    string Name,
    string Description,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate);