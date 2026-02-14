using Mission6_Whetten.Models;
using Microsoft.EntityFrameworkCore;

// Create the web application builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the dependency injection container
// This enables MVC (Model-View-Controller) functionality
builder.Services.AddControllersWithViews();

// Configure the database context to use SQLite
// The connection string is read from appsettings.json
builder.Services.AddDbContext<MovieRecordContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:RecordConnection"]);
});

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
// In production, use error handling and HTTPS enforcement
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware configuration
app.UseHttpsRedirection();  // Redirect HTTP requests to HTTPS
app.UseRouting();            // Enable routing for controllers and actions
app.UseAuthorization();      // Enable authorization middleware

// Map static files (CSS, JavaScript, images) to be served
app.MapStaticAssets();

// Configure the default routing pattern
// Format: /Controller/Action/Id (e.g., /Home/Index or /Home/MovieDatabase)
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Start the application and begin listening for requests
app.Run();