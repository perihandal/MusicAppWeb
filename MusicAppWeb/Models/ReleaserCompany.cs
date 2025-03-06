namespace MusicAppWeb.Models
{
    public class ReleaserCompany:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Album>Albums { get; set; }
    }
}
