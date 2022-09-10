using DoctorWho.Db.Entities;
namespace DoctorWho.Db.Repositories;
public class AuthorRepository : GenericRepository<Author>
{
    public AuthorRepository(DoctorWhoCoreDbContext context) : base(context)
    {
    }
}
