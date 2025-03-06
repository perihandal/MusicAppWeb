namespace MusicAppWeb.Models
{
    public class Song:BaseEntity
    {
        public  string Name { get; set; }
        public string RelaseDate { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public string SongFilePath { get; set; }


    }
}
