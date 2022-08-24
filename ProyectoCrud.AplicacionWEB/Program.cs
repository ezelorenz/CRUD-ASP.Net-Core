using Microsoft.EntityFrameworkCore;
using ProyectoCrud.BLL.Services;
using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.DAL.Repositories;
using ProyectoCrud.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbCRUDcapasContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));

//Inyeccion de dependencias

builder.Services.AddScoped<IGenericRepository<Contacto>, ContactRepository>();
builder.Services.AddScoped<IContactoService, ContactoService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
