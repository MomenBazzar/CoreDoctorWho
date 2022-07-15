using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db;

public class DoctorWhoCoreDbContext : DbContext
{
    DbSet<Doctor> Doctors { get; set; }
    DbSet<Author> Authors { get; set; }
    DbSet<Companion> Companions { get; set; }
    DbSet<Enemy> Enemies { get; set; }
    DbSet<Episode> Episodes { get; set; }
    DbSet<EpisodeCompanion> EpisodeCompanions { get; set; }
    DbSet<EpisodeEnemy> EpisodeEnemies { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
          .UseSqlServer(
            "Data Source=MomenLab\\SQLEXPRESS;initial catalog=DoctorWhoCore;persist security info=True;Integrated Security=SSPI;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
