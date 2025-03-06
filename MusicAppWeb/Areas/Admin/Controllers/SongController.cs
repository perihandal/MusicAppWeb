using Microsoft.AspNetCore.Mvc;
using MusicAppWeb.CrudModels;
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
        public SongController(ISongServices services,IArtistServices artistServices, IAlbumsService albumsService,IGenreServices genreServices)
        {
            _albumsService = albumsService;
            _services = services;
            _artistservices = artistServices;
            _genreservices = genreServices;
            
        }

       
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddSong()
        {
            
         ViewBag.Artists= await _artistservices.GetSingerForAddSong();
         ViewBag.Albums= await _albumsService.GetAlbumList();
         ViewBag.Genres = await _genreservices.GetGenreList();
            return View();
        }

        [HttpPost]
        public IActionResult AddSong(SongModelForAdding songModelForAdding)
        {
            _services.AddSong(songModelForAdding);
            TempData["Success"] = "BAşarılı";
            return View();
        }
    }
}
