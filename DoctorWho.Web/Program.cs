using DoctorWho.Db;
using DoctorWho.Db.Repositories;
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
    options.UseSqlServer(
        "Data Source=MomenLab\\SQLEXPRESS;initial catalog=DoctorWhoCore;persist security info=True;Integrated Security=SSPI;");
});

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
