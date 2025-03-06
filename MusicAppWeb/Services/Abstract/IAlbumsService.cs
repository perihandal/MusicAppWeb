using MusicAppWeb.Models;

namespace MusicAppWeb.Services.Abstract
{
    public interface IAlbumsService
    {
          Task<List<Album>> GetAlbumList();

    }
}
