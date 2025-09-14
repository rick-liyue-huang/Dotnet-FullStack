using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    
    // explain the following codes 
    public DbSet<Genre> Genres => Set<Genre>();
}