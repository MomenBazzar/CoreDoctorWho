namespace DoctorWho.Db.Models
{
    public class EpisodeDto
    {
        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateTime EpisodeDate { get; set; }
        public AuthorDto Author { get; set; }
        public DoctorDto Doctor { get; set; }
        public string Notes { get; set; }
    }
}
