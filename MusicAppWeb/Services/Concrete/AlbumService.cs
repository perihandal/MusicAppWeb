using Microsoft.EntityFrameworkCore;
using MusicAppWeb.AppContext;
using MusicAppWeb.Models;
using MusicAppWeb.Services.Abstract;

namespace MusicAppWeb.Services.Concrete
{
    public class AlbumService : IAlbumsService
    {
        private readonly AppDbContext _appDbContext;
        public AlbumService(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;

        }


        public async Task<List<Album>> GetAlbumList()
        {
            var val = await _appDbContext.Albums.ToListAsync();
            return val;
        }
    }
}
