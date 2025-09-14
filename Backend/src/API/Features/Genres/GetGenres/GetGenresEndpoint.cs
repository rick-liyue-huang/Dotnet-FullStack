using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Genres.GetGenres;

public static class GetGenresEndpoint
{
    public static void MapGetGenres(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", (
                // GameStoreData data
                GameStoreContext dbContext
            ) =>
            // data.GetGenres().Select(g => new GenreDto(g.Id, g.Name)));
            dbContext.Genres.Select(g => new GenreDto(g.Id, g.Name)).AsNoTracking());
    }
}