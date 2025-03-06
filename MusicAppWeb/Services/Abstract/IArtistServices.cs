using MusicAppWeb.CrudModels;
using MusicAppWeb.Models;

namespace MusicAppWeb.Services.Abstract
{
    public interface IArtistServices
    {
        Task<ICollection<SingerModel>> GetSingerForAddSong();
    }
}
