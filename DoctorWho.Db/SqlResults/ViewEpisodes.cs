using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.SqlResults
{
    [Keyless]
    public class ViewEpisodes
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string DoctorName { get; set; }
        public string Companions { get; set; }
        public string Enemies { get; set; }
    }
}
