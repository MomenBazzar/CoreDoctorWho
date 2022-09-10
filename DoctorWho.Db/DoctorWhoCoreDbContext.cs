using DoctorWho.Db.Entities;
using DoctorWho.Db.SqlResults;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db;

public class DoctorWhoCoreDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Companion> Companions { get; set; }
    public DbSet<Enemy> Enemies { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<EpisodeCompanion> EpisodeCompanions { get; set; }
    public DbSet<EpisodeEnemy> EpisodeEnemies { get; set; }
    public virtual DbSet<ViewEpisodes> ViewEpisodes { get; set; }
    public virtual DbSet<FnCompanionsResult> FnCompanions { get; set; }
    public virtual DbSet<FnEnemiesResult> FnEnemies { get; set; }

    public DoctorWhoCoreDbContext(DbContextOptions<DoctorWhoCoreDbContext> options)
   : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ViewEpisodes>(ve =>
            {
                ve.HasNoKey();
                ve.ToView("viewEpisodes");
            });

        modelBuilder.Entity<FnCompanionsResult>(ve => ve.HasNoKey());
        modelBuilder.Entity<FnEnemiesResult>(ve => ve.HasNoKey());
    }
}
