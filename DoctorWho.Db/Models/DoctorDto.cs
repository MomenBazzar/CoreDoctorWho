namespace DoctorWho.Db.Models
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }
        public string DoctorNumber { get; set; }
        public string DoctorName { get; set; }
        public int Age { get; set; }
        public DateTime FirstEpisodeDate { get; set; }
        public DateTime LastEpisodeDate { get; set; }
    }
}
