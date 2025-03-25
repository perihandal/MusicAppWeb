using MusicAppWeb.CrudModels;
using MusicAppWeb.Models;

namespace MusicAppWeb.Services.Abstract
{
    public interface IAlbumsService
    {
        Task<List<Album>> GetAlbumList();
        Task<List<Song>> GetAlbumSongs(int Id);
        Task<bool> AddAlbumAsync(AlbumModelForAdding model);


    }
}
