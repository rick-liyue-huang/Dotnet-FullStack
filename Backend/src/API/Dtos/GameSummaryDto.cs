namespace API.Dtos;

public record GameSummaryDto(
    Guid Id,
    string Name,
    string Description,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate);