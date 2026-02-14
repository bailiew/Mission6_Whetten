using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Whetten.Models;

namespace Mission6_Whetten.Controllers;

/// <summary>
/// Controller for handling all home page actions including the movie database form.
/// </summary>
public class HomeController : Controller
{
    // Database context for accessing the movie records
    private MovieRecordContext _context { get; set; }

    // Constructor that injects the database context via dependency injection
    public HomeController(MovieRecordContext temp)
    {
        _context = temp;
    }

    /// <summary>
    /// Displays the home page with Joel's headshot and introduction.
    /// </summary>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Displays the "Get To Know Joel" page with links to his comedy and podcast.
    /// </summary>
    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    /// <summary>
    /// GET action: Displays the movie database form for entering a new movie record.
    /// </summary>
    [HttpGet]
    public IActionResult MovieDatabase()
    {
        return View();
    }

    /// <summary>
    /// POST action: Handles form submission when a new movie record is submitted.
    /// Validates the data and saves it to the database if valid.
    /// </summary>
    /// <param name="response">The movie record data from the form</param>
    /// <returns>Confirmation view if successful, or the form view with errors if validation fails</returns>
    [HttpPost]
    public IActionResult MovieDatabase(Record response)
    {
        // Check if all required fields are valid
        if (ModelState.IsValid)
        {
            // Add the new record to the database context
            _context.Records.Add(response);
            // Save changes to the database
            _context.SaveChanges();
            // Display the confirmation page with the submitted record data
            return View("Confirmation", response);
        }
        // If validation failed, return the form view with error messages
        return View(response);
    }

}