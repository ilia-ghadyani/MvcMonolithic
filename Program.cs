using Microsoft.EntityFrameworkCore;
using MvcMonolithic.ApplicationServices;
using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.Models;
using MvcMonolithic.Models.Services.Contracts;
using MvcMonolithic.Models.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Add Conection ???
var connectionString = builder.Configuration.GetConnectionString("ProjectDbContext") ?? throw new InvalidOperationException("Connection string 'ProjectDbContext' not found.");

// Add ProjectDbContext Service
builder.Services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(connectionString));

//Add PersonRepository Service
builder.Services.AddScoped<IPersonRepository,PersonRepository>();

//Add PersonApplicationService Service
builder.Services.AddScoped<IPersonApplicationService,PersonApplicationService>();

//Add ProductRepository Service
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//Add ProductApplicationService Service
builder.Services.AddScoped<IProductApplicationService, ProductApplicationService>();


// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
