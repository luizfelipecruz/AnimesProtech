using AnimesProtech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace AnimesProtech.Context
{
    public class AnimeProtech : DbContext
    {
        public AnimeProtech(DbContextOptions<AnimeProtech> options) : base(options)
        {

        }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<User> usuarios {  get; set; }   
        public DbSet<Log> logs { get; set; }

    }
}
