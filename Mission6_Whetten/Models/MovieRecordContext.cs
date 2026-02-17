using Microsoft.EntityFrameworkCore;

namespace Mission6_Whetten.Models;

/// <summary>
/// Database context for the movie collection application.
/// Manages the connection to the SQLite database and provides access to the Records table.
/// </summary>
public class MovieRecordContext : DbContext
{
    // Constructor that accepts database configuration options
    public MovieRecordContext(DbContextOptions<MovieRecordContext> options) : base(options)
    {
        
    }
    
    // DbSet representing the Records table in the database
    // This allows us to query and save Record objects
    public DbSet<Record> Records { get; set; }
    public DbSet<Category> Categories { get; set; }
}