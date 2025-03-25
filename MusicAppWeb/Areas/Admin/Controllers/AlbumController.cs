using Microsoft.AspNetCore.Mvc;
using MusicAppWeb.CrudModels;
using MusicAppWeb.Services.Abstract;
using MusicAppWeb.Services.Concrete;

namespace MusicAppWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AlbumController : Controller
    {
        private readonly IAlbumsService _albumsService;

        public AlbumController(IAlbumsService albumsService)
        {
            _albumsService = albumsService;
        }
        public async Task< IActionResult >Index()
        {
            var val= await _albumsService.GetAlbumList();
            return View(val);
        }

        [HttpGet]
        public async Task<PartialViewResult> AlbumSongParital(int id)
        {
            var albumsongs= await _albumsService.GetAlbumSongs(id);
            return PartialView("AlbumSongParital", albumsongs);
        }


        [HttpGet]
        public async Task<IActionResult> AddAlbum()
        {
            ViewBag.AlbumName = await _albumsService.GetAlbumList();
            ViewBag.AlbumReleaseDate = await _albumsService.GetAlbumList();
            ViewBag.Artist = await _albumsService.GetAlbumList();

            return View();
        }
        [HttpPost]      
        public async Task<IActionResult> AddAlbum(AlbumModelForAdding albumModelForAdding)
        {
            ViewBag.AlbumName = await _albumsService.GetAlbumList();
            ViewBag.AlbumReleaseDate = await _albumsService.GetAlbumList();
            ViewBag.Artist = await _albumsService.GetAlbumList();

            bool isAdded = await _albumsService.AddAlbumAsync(albumModelForAdding);
            if (isAdded)
            {
                TempData["success"] = "Başarılı!";
            }
            else
            {
                TempData["error"] = "Albüm eklenirken bir hata oluştu.";
            }

            return View(); 
        }            
        




    }
}
