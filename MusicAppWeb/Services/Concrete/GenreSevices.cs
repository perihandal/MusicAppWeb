using Microsoft.EntityFrameworkCore;
using MusicAppWeb.AppContext;
using MusicAppWeb.Models;
using MusicAppWeb.Services.Abstract;

namespace MusicAppWeb.Services.Concrete
{
    public class GenreSevices : IGenreServices
    {
        private readonly AppDbContext _appDbContext;

        public GenreSevices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

         public async Task<List<Genre>> GetGenreList()
         {
            var val = await _appDbContext.Genres.ToListAsync();
             return val;
         }

    }
}
