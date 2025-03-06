using MusicAppWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace MusicAppWeb.CrudModels
{
    public class SongModelForAdding
    {
        [StringLength(60)]
        [Required]
        public string Name { get; set; }
        public string RelaseDate { get; set; }
        [Required]
        public int AlbumId { get; set; }
        [Required]
        public int GenreId { get; set; }
       
        public string SongFilePath { get; set; }

    }
}
