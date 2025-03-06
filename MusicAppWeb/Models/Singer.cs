namespace MusicAppWeb.Models
{
    public class Singer:BaseEntity
    {
        public string Name { get; set; }    
        public string SurName { get; set; }    
        public string Birthday { get; set; }

        public ICollection<Album> Albums { get; set; }
        public string? PictureBase64 { get; set; }
    }
}
