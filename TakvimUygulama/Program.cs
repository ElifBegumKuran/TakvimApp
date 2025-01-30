using Microsoft.EntityFrameworkCore;
using TakvimUygulama.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
builder.Services.AddControllersWithViews();

// 2. UygulamaContext'i DI Container'a kaydediyoruz
builder.Services.AddDbContext<UygulamaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // DefaultConnection ba�lant� dizesini kullan�yoruz

var app = builder.Build();

// 3. Configure the HTTP request pipeline.
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

builder.Services.AddHttpClient();
