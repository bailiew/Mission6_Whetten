using Microsoft.EntityFrameworkCore;

namespace Mission6_Whetten.Models;

public class MovieRecordContext : DbContext
{

    public MovieRecordContext(DbContextOptions<MovieRecordContext> options) : base(options)
    {
        
    }
    
    public DbSet<Record> Records { get; set; }
}