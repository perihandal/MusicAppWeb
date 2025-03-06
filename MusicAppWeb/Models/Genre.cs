namespace MusicAppWeb.Models
{
    public class Genre:BaseEntity
    {
        public  string Name { get; set; }
        public ICollection<Song>  Songs { get; set; }
    }
}
