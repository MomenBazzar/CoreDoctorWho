using DoctorWho.Db;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Repositories;
using Microsoft.EntityFrameworkCore;
namespace DoctorWho;

internal class Program
{
    private static DoctorWhoCoreDbContext _context;
    static void Main(string[] args)
    {
        _context = new DoctorWhoCoreDbContext();
        Console.WriteLine(CompanionNamesForEpisode(3));
        
    }

    public static string EnemeyNamesForEpisode(int episodeId)
    {
        return _context.FnEnemies.FromSqlInterpolated($"SELECT dbo.fnEnemies({episodeId}) as EnemiesNames").FirstOrDefault().EnemiesNames;
    }

    public static string CompanionNamesForEpisode(int episodeId)
    {
        return _context.FnCompanions.FromSqlInterpolated($"SELECT dbo.fnCompanions({episodeId}) as CompanionsNames").FirstOrDefault().CompanionsNames;
    }

    private static void SeedTheTables()
    {
        var authors = new List<Author> {
            new Author { AuthorName = "Anand East" },
            new Author { AuthorName = "Kelsea Frye" },
            new Author { AuthorName = "Rohaan Mcgill" },
            new Author { AuthorName = "Eden Hines" },
            new Author { AuthorName = "Belle Daugherty" }
        };
        _context.AddRange(authors);


        var doctors = new List<Doctor> {
            new Doctor { DoctorNumber = "+970 569-138-138", DoctorName = "Zidan Keller", BirthDate = new DateTime(1991, 5, 11),
                FirstEpisodeDate = new DateTime(2022, 4, 1), LastEpisodeDate = new DateTime(2022, 4, 29) },
            new Doctor { DoctorNumber = "+970 598-345-678", DoctorName = "Casper Redman", BirthDate = new DateTime(1990, 9, 25),
                FirstEpisodeDate = new DateTime(2019, 8, 5), LastEpisodeDate = new DateTime(2020, 5, 12) },
            new Doctor { DoctorNumber = "+970 569-876-543", DoctorName = "Juan Dunlop", BirthDate = new DateTime(1986, 2, 1),
                FirstEpisodeDate = new DateTime(2018, 9, 18), LastEpisodeDate = new DateTime(2021, 10, 20) },
            new Doctor { DoctorNumber = "+970 569-100-112", DoctorName = "Kaylem Barrett", BirthDate = new DateTime(1984, 12, 20),
                FirstEpisodeDate = new DateTime(2019, 2, 21), LastEpisodeDate = new DateTime(2021, 11, 15) },
            new Doctor { DoctorNumber = "+970 597-778-278", DoctorName = "Jeff Mcdonald", BirthDate = new DateTime(1996, 6, 10),
                FirstEpisodeDate = new DateTime(2016, 2, 7), LastEpisodeDate = new DateTime(2017, 11, 2) },

        };
        _context.AddRange(doctors);

        var episodes = new List<Episode> {
            new Episode { SeriesNumber = 1, EpisodeNumber = 1, EpisodeType = "Action", Title = "A mysterious enemy has appeared",
                EpisodeDate = new DateTime(2016, 2, 7), AuthorId = 2, DoctorId = 4, Notes = "something happend1" },
            new Episode { SeriesNumber = 1, EpisodeNumber = 5, EpisodeType = "Drama", Title = "Goodbye Linda",
                EpisodeDate = new DateTime(2017, 11, 2), AuthorId = 1, DoctorId = 5, Notes = "Randa keef 7alek?" },
            new Episode { SeriesNumber = 2, EpisodeNumber = 3, EpisodeType = "Drama", Title = "A new hope",
                EpisodeDate = new DateTime(2018, 9, 28), AuthorId = 4, DoctorId = 1, Notes = "a7la 7alqa" },
            new Episode { SeriesNumber = 2, EpisodeNumber = 8, EpisodeType = "Comedy", Title = "Lets take a break",
                EpisodeDate = new DateTime(2020, 12, 25), AuthorId = 3, DoctorId = 3, Notes = "important notes" },
            new Episode { SeriesNumber = 3, EpisodeNumber = 12, EpisodeType = "Action and Drama", Title = "Beginning of the End",
                EpisodeDate = new DateTime(2022, 2, 16), AuthorId = 5, DoctorId = 2, Notes = "important notes" },
            new Episode { SeriesNumber = 1, EpisodeNumber = 2, EpisodeType = "Action and Drama", Title = "Betrayal",
                EpisodeDate = new DateTime(2016, 5, 3), AuthorId = 2, DoctorId = 4, Notes = "la la la la la" },
            new Episode { SeriesNumber = 1, EpisodeNumber = 12, EpisodeType = "new Type", Title = "new Title",
                EpisodeDate = new DateTime(2018, 3, 12), AuthorId = 4, DoctorId = 5, Notes = "I am not sure what to say again" },
            new Episode { SeriesNumber = 2, EpisodeNumber = 1, EpisodeType = "Comedy", Title = "Miss me?",
                EpisodeDate = new DateTime(2018, 4, 19), AuthorId = 2, DoctorId = 1, Notes = "Randa keef 7alek? again" },
            new Episode { SeriesNumber = 3, EpisodeNumber = 4, EpisodeType = "Action", Title = "Fire all the way",
                EpisodeDate = new DateTime(2021, 1, 26), AuthorId = 3, DoctorId = 3, Notes = "7reeeeeqa" },
            new Episode { SeriesNumber = 3, EpisodeNumber = 5, EpisodeType = "Action", Title = "etfeelna alnaar ya walad",
                EpisodeDate = new DateTime(2021, 5, 27), AuthorId = 5, DoctorId = 2, Notes = "important notes akeed" },

        };
        _context.AddRange(episodes);

        var enemies = new List<Enemy> {
            new Enemy { EnemyName = "Lara Wells", Description = "crazy girl or something" },
            new Enemy { EnemyName = "Aviana White", Description = "Rich psycho girl" },
            new Enemy { EnemyName = "Jameel Moreno", Description = "random guy who is an enemy in the series" },
            new Enemy { EnemyName = "Georga Dawson", Description = "another random guy who is an enemy in the series" },
            new Enemy { EnemyName = "Clodagh Chapman", Description = "he knows the final boss" },
            new Enemy { EnemyName = "Rhodri Bravo", Description = "the final boss himself" },

        };
        _context.AddRange(enemies);

        var companions = new List<Companion> {
            new Companion { CompanionName = "Karl Davie", WhoPlayed = "I dont know what this column is" },
            new Companion { CompanionName = "Linda Somran", WhoPlayed = "The girl who died in episode 5" },
            new Companion { CompanionName = "Marvin Irving", WhoPlayed = "this guy comes from nowhere to help" },
            new Companion { CompanionName = "Zachariah Roberts", WhoPlayed = "german, but not a bad gu somehow" },
            new Companion { CompanionName = "Emmanuella Avalos", WhoPlayed = "I still dont know what this column is, but throwing data" },
        };
        _context.AddRange(companions);

        var episodeCompanions = new List<EpisodeCompanion> {
            new EpisodeCompanion { EpisodeId = 1, CompanionId = 2 },
            new EpisodeCompanion { EpisodeId = 3, CompanionId = 3 },
            new EpisodeCompanion { EpisodeId = 4, CompanionId = 1 },
            new EpisodeCompanion { EpisodeId = 9, CompanionId = 4 },
            new EpisodeCompanion { EpisodeId = 10, CompanionId = 5 },
            new EpisodeCompanion { EpisodeId = 7, CompanionId = 4 },
            new EpisodeCompanion { EpisodeId = 2, CompanionId = 1 },
        };
        _context.AddRange(episodeCompanions);

        var episodeEnemies = new List<EpisodeEnemy> {
            new EpisodeEnemy { EpisodeId = 1, EnemyId = 5 },
            new EpisodeEnemy { EpisodeId = 3, EnemyId = 6 },
            new EpisodeEnemy { EpisodeId = 4, EnemyId = 2 },
            new EpisodeEnemy { EpisodeId = 9, EnemyId = 4 },
            new EpisodeEnemy { EpisodeId = 10, EnemyId = 3 },
            new EpisodeEnemy { EpisodeId = 7, EnemyId = 1 },
            new EpisodeEnemy { EpisodeId = 2, EnemyId = 2 },
        };
        _context.AddRange(episodeEnemies);
        _context.SaveChanges();
    }
}
