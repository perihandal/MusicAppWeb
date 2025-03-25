using MusicAppWeb.CrudModels;
using MusicAppWeb.Models;

namespace MusicAppWeb.Services.Abstract
{
    public interface ISongServices
    {
        bool AddSong(SongModelForAdding model);
        Task<List<SongModelForList>> GetSongList();
         Task<int[]> GetRates();
        Task<SongModelForList> Update(UpdateSongModel updateSongModel);
        Task<Song> FindSong(int Id);

        Task<Song?> RemoveSong(int Id);


    }
}
