using Microsoft.EntityFrameworkCore;
using MusicAppWeb.AppContext;
using MusicAppWeb.CrudModels;
using MusicAppWeb.Models;
using MusicAppWeb.Services.Abstract;

namespace MusicAppWeb.Services.Concrete
{
    public class AlbumService : IAlbumsService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<AlbumService> _logger;
        //private readonly SongServices _songServices;

        public AlbumService(AppDbContext appDbContext, ILogger<AlbumService> logger)
        {

            _appDbContext = appDbContext;
            _logger = logger;
        }


        public async Task<List<Album>> GetAlbumList()
        {
            var val = await _appDbContext.Albums.Include(x=>x.Singer).ToListAsync();
            return val;
        }
        public async Task<List<Song>> GetAlbumSongs(int Id)
        {
            var val = await _appDbContext.Songs.Where(x => x.AlbumId == Id).Include(x=>x.Album).ThenInclude(x=>x.Singer).ToListAsync();
            return val;
        }

        public async Task<bool> AddAlbumAsync(AlbumModelForAdding model)
        {
            try
            {
                Album album = new Album()
                {
                    Name = model.Name,
                    RelaseDate = model.ReleaseDate,
                    SingerId = model.SingerId,
                    Description = model.Description,
                    
                };

                await _appDbContext.Albums.AddAsync(album); // Songs yerine Albums kullanıldı
                await _appDbContext.SaveChangesAsync(); // Asenkron versiyon kullanıldı

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Albüm eklenirken hata oluştu."); // Opsiyonel: Loglama yapabilirsiniz
                return false;
            }
        }

    }
}

