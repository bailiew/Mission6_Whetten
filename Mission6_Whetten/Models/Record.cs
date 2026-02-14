using System.ComponentModel.DataAnnotations;

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
    [Required]
    public string Category { get; set; }
    
    // Required field: The title of the movie
    [Required]
    public string Title { get; set; }
    
    // Required field: The year the movie was released
    [Required]
    public int Year { get; set; }
    
    // Required field: The director of the movie
    [Required]
    public string Director { get; set; }
    
    // Required field: The MPAA rating (G, PG, PG-13, R)
    [Required]
    public string Rating { get; set; }
    
    // Optional field: Whether the movie has been edited (true/false)
    public bool? Edited { get; set; }
    
    // Optional field: Name of the person the movie was lent to
    public string? LentTo { get; set; }
    
    // Optional field: Additional notes about the movie (limited to 25 characters)
    [MaxLength(25)]
    public string? Notes { get; set; }
}