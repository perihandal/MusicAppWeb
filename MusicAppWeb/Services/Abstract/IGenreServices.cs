using MusicAppWeb.Models;

namespace MusicAppWeb.Services.Abstract
{
    public interface IGenreServices
    {
        Task<List<Genre>> GetGenreList();
    }
}
