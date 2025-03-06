using MusicAppWeb.CrudModels;

namespace MusicAppWeb.Services.Abstract
{
    public interface ISongServices
    {
        public bool AddSong(SongModelForAdding model);

    }
}
