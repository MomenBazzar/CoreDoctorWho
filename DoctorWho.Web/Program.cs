using DoctorWho.Db;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var services = builder.Services;
services.AddScoped<IDoctorRepository, DoctorRepository>();
services.AddScoped<IEpisodeRepository, EpisodeRepository>();
services.AddScoped<IAuthorRepository, AuthorRepository>();

services.AddDbContext<DoctorWhoCoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DoctorWhoCore"));
});

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddValidatorsFromAssemblyContaining<DoctorUpdateDtoValidator>();


var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
