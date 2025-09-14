using Microsoft.EntityFrameworkCore;

namespace API.Data;

public static class DataExtensions
{
    // Create a service to migrate the database
    // this method will replace the old database update manual method:
    // 1. dotnet ef migrations add InitialCreate (not applied)
    // 2. dotnet ef database update (applied)
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        GameStoreContext dbContext = scope
            .ServiceProvider
            .GetRequiredService<GameStoreContext>();
        
        dbContext.Database.Migrate();
        
    }
}

/*
    A DbContext instance in Entity Framework Core represents a session with the database and is used primarily for querying and saving instances of your entities. 
   
   This makes it a central class in the Entity Framework API, acting as a bridge between your application's domain or entity classes and the database. 
   
   Its role encompasses the patterns of Unit Of Work and Repository, allowing for a simplified and abstracted approach to handling data access. 
   
   While it does offer features that could indirectly support tasks like data validation and direct SQL execution, its primary purpose is to manage entity objects during runtime, which includes retrieving and saving data to the database.
*/