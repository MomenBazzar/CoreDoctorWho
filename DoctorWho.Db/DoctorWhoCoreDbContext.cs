using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class DoctorWhoCoreDbContext : DbContext
    {
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
}