using MusicAppWeb.AppContext;
using MusicAppWeb.CrudModels;
using MusicAppWeb.Models;
using MusicAppWeb.Services.Abstract;

namespace MusicAppWeb.Services.Concrete
{
    public class SongServices : ISongServices
    {
        private readonly AppDbContext _appDbContext;
        public SongServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public bool AddSong(SongModelForAdding model)
        {
            try
            {

                Song song = new Song()
                {
                    AlbumId = model.AlbumId,
                    RelaseDate = model.RelaseDate,
                    SongFilePath = model.SongFilePath,
                    Name = model.Name,
                    GenreId = model.GenreId,
                };
                _appDbContext.Songs.Add(song);
                _appDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }


        }
    }
}
