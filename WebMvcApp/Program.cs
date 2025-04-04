using DAL;

using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services pour les contr�leurs avec vues (MVC)
builder.Services.AddControllersWithViews();

// Configuration du DbContext en utilisant la cha�ne de connexion dans appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enregistrer AutoMapper (avec le profil d�fini dans le projet Service)
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Enregistrer le repository et le service dans le conteneur DI
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

var app = builder.Build();

// Configuration du pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Route par d�faut : le contr�leur "Restaurants", action "Index", avec param�tre optionnel id
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Restaurants}/{action=Index}/{id?}");

app.Run();
