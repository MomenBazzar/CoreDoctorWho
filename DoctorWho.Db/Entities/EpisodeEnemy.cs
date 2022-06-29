namespace DoctorWho.Db.Entities
{
    class EpisodeEnemy
    {
        public int EpisodeEnemyId { get; set; }
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public int EnemyId { get; set; }
        public Enemy Enemy { get; set; }
    }
}
