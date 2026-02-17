using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Whetten.Models;

namespace Mission6_Whetten.Controllers;

// Controller for handling all home page actions including the movie database form.
public class HomeController : Controller
{
    // Database context for accessing the movie records
    private MovieRecordContext _context { get; set; }

    // Constructor that injects the database context via dependency injection
    public HomeController(MovieRecordContext temp)
    {
        _context = temp;
    }
    
    // Displays the home page with Joel's headshot and introduction.
    public IActionResult Index()
    {
        return View();
    }
    
    // Displays the "Get To Know Joel" page with links to his comedy and podcast.
    public IActionResult GetToKnowJoel()
    {
        return View();
    }
    
    // GET action: Displays the movie database form for entering a new movie record.
    [HttpGet]
    public IActionResult MovieDatabase()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View(new Record());
    }


    // POST action: Handles form submission when a new movie record is submitted.
    // Validates the data and saves it to the database if valid.
    // <param name="response">The movie record data from the form</param>
    // <returns>Confirmation view if successful, or the form view with errors if validation fails</returns>
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