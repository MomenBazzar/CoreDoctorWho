using DoctorWho.Db.Entities;
namespace DoctorWho.Db.Repositories;
public class EpisodeRepository : GenericRepository<Episode>
{
    public EpisodeRepository(DoctorWhoCoreDbContext context) : base(context)
    {
    }
}
