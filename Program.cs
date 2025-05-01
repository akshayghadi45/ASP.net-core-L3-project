using CoreSkillsApp.Interfaces;
using CoreSkillsApp.Models;
using CoreSkillsApp.Repositories;
using Microsoft.EntityFrameworkCore;
using Task = CoreSkillsApp.Models.Task;





var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 34)) // or match your version
    )
);

// Optional: Clear default providers and add Console logging explicitly
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddProvider(new DatabaseLoggerProvider(builder.Services.BuildServiceProvider()));

// Usual service registration
builder.Services.AddControllersWithViews();

// Add EF Core and your DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32))));
// Register repository
builder.Services.AddScoped<IRepository<Task>, TaskRepository>();

// Add MVC services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Set up MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tasks}/{action=Index}/{id?}");

app.Run();



//using CoreSkillsApp.Interfaces;
//using CoreSkillsApp.Models;
//using CoreSkillsApp.Repositories;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<MyDbContext>(options =>
//    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
//    new MySqlServerVersion(new Version(8, 0, 34))));
//builder.Services.AddScoped<IRepository<CoreSkillsApp.Models.Task>, TaskRepository>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Tasks}/{action=Index}");

//app.Run();