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
    public IActionResult AddRecord()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
        
        return View(new Movie());
    }


    // POST action: Handles form submission when a new movie record is submitted.
    // Validates the data and saves it to the database if valid.
    // <param name="response">The movie record data from the form</param>
    // <returns>Confirmation view if successful, or the form view with errors if validation fails</returns>
    [HttpPost]
    public IActionResult AddRecord(Movie response)
    {
        // Check if all required fields are valid
        if (ModelState.IsValid)
        {
            // Add the new record to the database context
            _context.Movies.Add(response);
            // Save changes to the database
            _context.SaveChanges();
            // Display the confirmation page with the submitted record data
            return View("Confirmation", response);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
        }
        // If validation failed, return the form view with error messages
        return View(response);
    }

    [HttpGet]
    public IActionResult MovieList()
    {
        var records = _context.Movies
            .OrderBy(r => r.MovieId).ToList();
        
        return View(records);
    }

    [HttpGet]
    public IActionResult Edit(Movie updatedInfo) // passes in the updated record information
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();

        return RedirectToAction("MovieList"); // redirects to the MovieList Action
    }

    [HttpGet]

    public IActionResult Delete(int id) // takes in specified movie record id and passes it to delete confirmation view
    {
        var recordToDelete = _context.Movies
            .Single(m => m.MovieId == id);

        return View(recordToDelete);
    }

    [HttpPost]

    public IActionResult Delete(Movie recordToDelete) // takes in specified movie record id, matches and deletes the record 
    {
        _context.Movies.Remove(recordToDelete);
        _context.SaveChanges();

        return RedirectToAction("MovieList"); // returns user to main database viewing page
    }

}