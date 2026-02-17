using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Whetten.Models;

/// <summary>
/// Model representing a movie record in Joel's film collection database.
/// Contains all information about a movie including category, title, director, rating, etc.
/// </summary>
public class Record
{
    // Primary key - unique identifier for each movie record
    [Key]
    public int MovieId { get; set; }
    
    // Required field: The category/genre of the movie
    [ForeignKey("CategoryId")]
    public string CategoryId { get; set; }
    
    // Required field: The title of the movie
    [Required]
    public string Title { get; set; }
    
    // Required field: The year the movie was released
    [Required][Range(1888, int.MaxValue, ErrorMessage="Enter a year greater than 1888.")]
    public int Year { get; set; }
    
    // Optional field: The director of the movie
    public string? Director { get; set; }
    
    // Optional field: The MPAA rating (G, PG, PG-13, R)
    public string? Rating { get; set; }
    
    // Required field: Whether the movie has been edited (true/false)
    [Required]
    public bool Edited { get; set; }
    
    // Optional field: Name of the person the movie was lent to
    public string? LentTo { get; set; }
    
    // Required field: Whether the movie has been copied to Plex
    
    [Required]
    public bool CopiedToPlex { get; set; }
    
    // Optional field: Additional notes about the movie (limited to 25 characters)
    [MaxLength(25, ErrorMessage="Your note must be 25 or less characters")]
    public string? Notes { get; set; }
}