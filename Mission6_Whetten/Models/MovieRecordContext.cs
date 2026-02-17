using Microsoft.EntityFrameworkCore;

namespace Mission6_Whetten.Models;

// Database context for the movie collection application.
// Manages the connection to the SQLite database and provides access to the Movies table.
public class MovieRecordContext : DbContext
{
    // Constructor that accepts database configuration options
    public MovieRecordContext(DbContextOptions<MovieRecordContext> options) : base(options)
    {
        
    }
    
    // DbSet representing the Movies table in the database
    // This allows us to query and save Movies objects
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }
}