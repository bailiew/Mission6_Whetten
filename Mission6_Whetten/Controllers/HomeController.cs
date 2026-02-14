using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Whetten.Models;

namespace Mission6_Whetten.Controllers;

public class HomeController : Controller
{
    private MovieRecordContext _context { get; set; }

    public HomeController(MovieRecordContext temp)
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult MovieDatabase()
    {
        return View();
    }

    [HttpPost] // information that comes out of the page
    public IActionResult MovieDatabase(Record response)
    {
        if (ModelState.IsValid)
        {
            _context.Records.Add(response); // add record to the database
            _context.SaveChanges();
            return View("Confirmation", response); // pass response so that information can be used by Confirmation page
        }
        return View(response); // Return view with errors if invalid
    }

}