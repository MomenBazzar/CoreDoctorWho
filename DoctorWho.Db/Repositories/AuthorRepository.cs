using DoctorWho.Db.Entities;
namespace DoctorWho.Db.Repositories;
public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(DoctorWhoCoreDbContext context) : base(context)
    {
    }
}
