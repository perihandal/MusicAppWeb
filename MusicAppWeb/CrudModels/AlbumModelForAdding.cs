using System.ComponentModel.DataAnnotations;

namespace MusicAppWeb.CrudModels
{
    public class AlbumModelForAdding
    {
        [StringLength(60)]
        [Required]
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        [Required]
        public int SongId { get; set; }
        [Required]
        public int SingerId { get; set; }
        public string? Description { get; set; }

    }
}
