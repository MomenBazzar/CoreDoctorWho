using DoctorWho.Db.Entities;
namespace DoctorWho.Db.Repositories;
public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(DoctorWhoCoreDbContext context) : base(context)
    {
    }
}
