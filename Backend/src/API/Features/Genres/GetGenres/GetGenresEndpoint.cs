using API.Data;

namespace API.Features.Genres.GetGenres;

public static class GetGenresEndpoint
{
    public static void MapGetGenres(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", (GameStoreData data) => data.GetGenres().Select(g => new GenreDto(g.Id, g.Name)));
    }
}