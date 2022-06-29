namespace DoctorWho.Db.Entities
{
    class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}
