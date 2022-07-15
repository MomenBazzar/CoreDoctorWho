using DoctorWho.Db.Entities;
using DoctorWho.Db;
namespace DoctorWho;

internal class Program
{
    static void Main(string[] args)
    {
        var context = new DoctorWhoCoreDbContext();

        var authors = new List<Author> {
            new Author { AuthorName = "Anand East" },
            new Author { AuthorName = "Kelsea Frye" },
            new Author { AuthorName = "Rohaan Mcgill" },
            new Author { AuthorName = "Eden Hines" },
            new Author { AuthorName = "Belle Daugherty" }
        };
    }
}
