using System.ComponentModel.DataAnnotations;

namespace MusicAppWeb.CrudModels
{
    public class UpdateSongModel
    {
        public int Id { get; set; }
   
        [Required]
        public int AlbumId { get; set; }
        public string? FilePath { get; set; }
        [Required]
        public int GenreId { get; set; }
       
        public string ReleaseDate { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string? SongFilePath { get; set; }
    }
}
