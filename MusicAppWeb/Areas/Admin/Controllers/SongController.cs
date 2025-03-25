using Microsoft.AspNetCore.Mvc;
using MusicAppWeb.CrudModels;
using MusicAppWeb.Models;
using MusicAppWeb.Services.Abstract;

namespace MusicAppWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SongController : Controller
    {
        private readonly ISongServices _services;
        private readonly IArtistServices _artistservices;
        private readonly IAlbumsService _albumsService;
        private readonly IGenreServices _genreservices;

        public SongController(ISongServices services, IArtistServices artistServices, IAlbumsService albumsService, IGenreServices genreServices)
        {
            _albumsService = albumsService;
            _services = services;
            _artistservices = artistServices;
            _genreservices = genreServices;

        }



        public async Task<IActionResult> Index()
        {
            var value = await _services.GetSongList();
            var counts = await _services.GetRates();

            ViewBag.SongCount = counts[0].ToString();
            ViewBag.AlbumCount = counts[1].ToString();
            ViewBag.SingerCount = counts[2].ToString();

            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> AddSong()
        {

            ViewBag.Artists = await _artistservices.GetSingerForAddSong();
            ViewBag.Albums = await _albumsService.GetAlbumList();
            ViewBag.Genres = await _genreservices.GetGenreList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSong(SongModelForAdding songModelForAdding)
        {
            ViewBag.Artists = await _artistservices.GetSingerForAddSong();
            ViewBag.Albums = await _albumsService.GetAlbumList();
            ViewBag.Genres = await _genreservices.GetGenreList();
            _services.AddSong(songModelForAdding);
            TempData["success"] = "BAşarılı";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var song = await _services.FindSong(Id);

            if (song == null)
            {
                return NotFound();
            }

            var updateSongModel = new UpdateSongModel
            {
                Id = song.Id,
                Name = song.Name,
                AlbumId = song.AlbumId,
                GenreId = song.GenreId,
                ReleaseDate = song.RelaseDate,
                SongFilePath = song.SongFilePath
            };

            ViewBag.Artists = await _artistservices.GetSingerForAddSong();
            ViewBag.Albums = await _albumsService.GetAlbumList();
            ViewBag.Genres = await _genreservices.GetGenreList();

            return View(updateSongModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSongModel updateSongModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Artists = await _artistservices.GetSingerForAddSong();
                ViewBag.Albums = await _albumsService.GetAlbumList();
                ViewBag.Genres = await _genreservices.GetGenreList();
                return View(updateSongModel);
            }

            await _services.Update(updateSongModel);
            TempData["success"] = "Şarkı başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var deletedSong = await _services.RemoveSong(id);

            if (deletedSong == null)
            {
                return NotFound(new { message = "Şarkı bulunamadı." });
            }

            return RedirectToAction("Index");
        }


    }
}
