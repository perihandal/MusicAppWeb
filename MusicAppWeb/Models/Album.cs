namespace MusicAppWeb.Models
{
    public class Album:BaseEntity
    {
        public string Name { get; set; }
        public string RelaseDate { get; set; }
        public string Description { get; set; }
        public int SingerId { get; set; }
        public Singer Singer { get; set; } // Albüm şarkıcı bağlamsı

        public ICollection<Song> Songs { get; set; }
        public ReleaserCompany? ReleaserCompany { get; set; }
        public int? ReleaserCompanyId { get; set; }
        public string? PictureBase64 { get; set; }


    }
}
