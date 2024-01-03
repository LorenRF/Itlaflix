// Using statements to import necessary namespaces
using Itlaflix.Infrastructure.Persistence;
using Itlaflix.Core.Application;
using Itlaflix.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

// Create a new instance of the web application builder
var builder = WebApplication.CreateBuilder(args);

// Retrieve the connection string for the database from configuration
var connectionString = builder.Configuration.GetConnectionString("DB");

// Add the DbContext to the dependency injection container, specifying SQL Server as the database provider
builder.Services.AddDbContext<ApplicationContext>(op => op.UseSqlServer(connectionString));

// Add controllers and views services to the dependency injection container
builder.Services.AddControllersWithViews();

// Register persistence infrastructure services using the configuration
builder.Services.AddPersistenceIntefrastructure(builder.Configuration);

// Register application layer services using the configuration
builder.Services.AddApplicationLayer(builder.Configuration);

// Add controllers and views services to the dependency injection container again (repeated line)
builder.Services.AddControllersWithViews();

// Build the web application
var app = builder.Build();

// Configure the HTTP request pipeline.

// Check if the application is not in development mode
if (!app.Environment.IsDevelopment())
{
    // Use exception handling middleware and set the default error path
    app.UseExceptionHandler("/Home/Error");

    // Use HTTP Strict Transport Security (HSTS) middleware
    app.UseHsts();
}

// Redirect HTTP traffic to HTTPS
app.UseHttpsRedirection();

// Serve static files like images, CSS, and JavaScript
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable authorization
app.UseAuthorization();

// Map the default controller route with optional parameters (controller, action, and id)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application
app.Run();
