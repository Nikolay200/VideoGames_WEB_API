using Microsoft.EntityFrameworkCore;
using VideoGames.WebApi.Models;

namespace VideoGames.WebApi.Data
{
    public class VideoGameDbContext : DbContext
    {
        public VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : base(options)
        {

        }
        public DbSet<VideoGame> VideoGames { get; set; }
    }
}
