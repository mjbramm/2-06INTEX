using Microsoft.EntityFrameworkCore;
using Mission11_Brammer.Controllers;
using Mission11_Brammer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookstoreContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:BookConnection"]);
}
);
builder.Services.AddScoped<IBookRepository, EFBookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("pagenumandcategory", "{bookCategory}/{pageNum}", new { Controller = "Home", action = "Index" });
app.MapControllerRoute("bookCategory", "{bookCategory}", new { Controller = "Home", action = "Index", pageNum = 1 });
app.MapControllerRoute("pagination", "Books/{pageNum}", new { Controller = "Home", action = "Index", pageNum = 1 });

app.MapDefaultControllerRoute();

app.Run();
