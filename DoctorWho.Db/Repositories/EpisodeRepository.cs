using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;
public class EpisodeRepository : GenericRepository<Episode>, IEpisodeRepository
{
    public EpisodeRepository(DoctorWhoCoreDbContext context) : base(context)
    {
    }

    public void AddCompanionToEpisode(Companion companion, Episode episode)
    {
        _context.EpisodeCompanions.Add(new EpisodeCompanion { Companion = companion, Episode = episode });
        _context.SaveChanges();
    }

    public void AddEnemyToEpisode(Enemy enemy, Episode episode)
    {
        _context.EpisodeEnemies.Add(new EpisodeEnemy { Enemy = enemy, Episode = episode });
        _context.SaveChanges();
    }
}
