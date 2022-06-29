namespace DoctorWho.Db.Entities
{
    class Companion
    {
        public int CompanionId { get; set; }
        public string CompanionName { get; set; }
        public string WhoPlayed { get; set; }
        public List<EpisodeCompanion> EpisodeCompanions { get; set; }
    }
}
