﻿namespace DoctorWho.Db.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}
