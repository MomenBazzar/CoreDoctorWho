using DoctorWho.Db.Entities;
namespace DoctorWho.Db.Repositories;
public class CompanionRepository : GenericRepository<Companion>
{
    public CompanionRepository(DoctorWhoCoreDbContext context) : base(context)
    {
    }
}