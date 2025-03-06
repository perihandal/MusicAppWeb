using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicAppWeb.Models;
using MusicAppWeb.Models.UserModels;

namespace MusicAppWeb.AppContext
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<ReleaserCompany> ReleaserCompanies { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<SongListeningRate> songListeningRates { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}


