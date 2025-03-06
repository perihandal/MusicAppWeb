using Microsoft.EntityFrameworkCore;
using MusicAppWeb.AppContext;
using MusicAppWeb.CrudModels;
using MusicAppWeb.Services.Abstract;

namespace MusicAppWeb.Services.Concrete
{
    public class ArtistServices : IArtistServices
    {
        private readonly AppDbContext _context;

        public ArtistServices(AppDbContext appDbContext)
        {
            _context = appDbContext;
            
        }
        public async Task<ICollection<SingerModel>> GetSingerForAddSong( )
        {
            var value = await _context.Singers.ToListAsync();
            var result = value.Select(s => new SingerModel
            {
                Name = s.Name,
                 Id=s.Id,
                Surname = s.SurName
            }).ToList();
            return result;

        }
    }
}
