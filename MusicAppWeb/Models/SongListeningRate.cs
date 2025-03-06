namespace MusicAppWeb.Models
{
    public class SongListeningRate:BaseEntity
    {
        public Song Song { get; set; }
        public int SongId { get; set; }
        public int ListeningCount { get; set; }
    }
}
