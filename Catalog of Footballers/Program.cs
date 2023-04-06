using Dal.EFCore;
using Dal.EFCore.Repositories;
using Dal.Repositories;
using Logic.AutoMapper;
using Logic.Implementations;
using Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddAuthorization();
services.AddControllersWithViews();
services.AddMvc();
services.AddDbContext<DataContext>();
services.AddAutoMapper(typeof(AutoMappingProfile));
services.TryAddScoped<ITeamRepository, TeamRepository>();
services.TryAddScoped<IFootballerRepository, FootballerRepository>();
services.TryAddScoped<ITeamManager, TeamManager>();
services.TryAddScoped<IFootballerManager, FootballerManager>();

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

app.MapControllers();
app.Map("/", () => Results.LocalRedirect("/home/about"));

app.Run();