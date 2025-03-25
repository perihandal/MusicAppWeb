using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MusicAppWeb.AppContext;
using MusicAppWeb.CrudModels;
using MusicAppWeb.Models;
using MusicAppWeb.Services.Abstract;

namespace MusicAppWeb.Services.Concrete
{
    public class SongServices : ISongServices
    {
        private readonly AppDbContext _appDbContext;
        public SongServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task<List<SongModelForList>> GetSongList()
        {
            var list = await _appDbContext.Songs
                .Include(song => song.Album) // Şarkının albüm bilgilerini çekiyoruz.
                .ThenInclude(album => album.Singer) // Albümün şarkıcısını da çekiyoruz.
                .Select(song => new SongModelForList
                {
                    Id = song.Id,
                    Name = song.Name,
                    AlbumName = song.Album.Name,
                    Picture = song.Album.PictureBase64,
                    FilePath = song.SongFilePath,
                    ReleaseDate = song.Album.RelaseDate,
                    SingerName = song.Album.Singer.Name, // Singer nesnesinin dolu olduğundan emin olmak için ThenInclude ekledik.
                })
                .ToListAsync();

            return list;
        }

        public async Task<int[]> GetRates()
        {
            var songcount = await _appDbContext.Songs.CountAsync();
            var albumcount = await _appDbContext.Albums.CountAsync();
            var singercount = await _appDbContext.Singers.CountAsync();


            var counts = new int[3];
            counts[0] = songcount;
            counts[1] = albumcount;
            counts[2] = singercount;

            return (counts);
        }

        public async Task<SongModelForList> Update(UpdateSongModel updateSongModel)
        {

            var hasSong = await _appDbContext.Songs.AnyAsync(x => x.Id == updateSongModel.Id);
            SongModelForList songModelForList;
            SongModelForList songModelNUll = new SongModelForList();
            if (hasSong)
            {
                var song = await _appDbContext.Songs.Include(x => x.Album).ThenInclude(album => album.Singer).FirstOrDefaultAsync(x => x.Id == updateSongModel.Id);
            

                song.GenreId = updateSongModel.GenreId;
                song.AlbumId = updateSongModel.AlbumId;
                song.Name = updateSongModel.Name;
                song.RelaseDate = updateSongModel.ReleaseDate;
                song.IsActive = updateSongModel.IsActive;
                song.SongFilePath = updateSongModel.SongFilePath;

                _appDbContext.Songs.Update(song);
                await _appDbContext.SaveChangesAsync();

                songModelForList = new SongModelForList()
                {
                    Id = updateSongModel.Id,
                    AlbumName = song.Album.Name,
                    Name = song.Name,
                    SingerName = song.Album.Singer.Name
                };
                return songModelForList;
            }

            return songModelNUll;
        }
        public async Task<Song> FindSong(int Id)
        {
            var song = await _appDbContext.Songs.FirstOrDefaultAsync(x => x.Id == Id);
            return song;
        }




        public bool AddSong(SongModelForAdding model)
        {
            try
            {

                Song song = new Song()
                {
                    AlbumId = model.AlbumId,
                    RelaseDate = model.ReleaseDate,

                    SongFilePath = model.SongFilePath,
                    Name = model.Name,
                    GenreId = model.GenreId,
                };
                _appDbContext.Songs.Add(song);
                _appDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public async Task<Song?> RemoveSong(int Id)
        {
            var deletessong = await _appDbContext.Songs.FirstOrDefaultAsync(x => x.Id == Id);

            if (deletessong == null)
            {
                return null; 
            }

            _appDbContext.Songs.Remove(deletessong);
            await _appDbContext.SaveChangesAsync();

            return deletessong;
        }

    }
}
