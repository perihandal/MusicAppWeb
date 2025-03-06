using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicAppWeb.AppContext;
using MusicAppWeb.Models.UserModels;
using MusicAppWeb.Services.Abstract;
using MusicAppWeb.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), sqlOptions =>
    {
        sqlOptions.MigrationsAssembly("MusicAppWeb");
    });
});

builder.Services.AddScoped<ISongServices,SongServices>();
builder.Services.AddScoped<IArtistServices,ArtistServices>();
builder.Services.AddScoped<IAlbumsService,AlbumService>();
builder.Services.AddScoped<IGenreServices,GenreSevices>();
builder.Services.AddIdentity<AppUser, AppRole>(Opt =>
{
    Opt.User.RequireUniqueEmail = true;
    Opt.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//	name: "default",
//	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Song}/{action=Index}/{id?}",
    defaults: new { area = "Admin" });

app.MapControllerRoute(
    name: "User",
    pattern: "{controller=Home}/{action=Index}/{id?}",
    defaults: new { area = "User" });
 
app.Run();
