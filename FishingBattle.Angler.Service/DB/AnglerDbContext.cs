using Microsoft.EntityFrameworkCore;
using FishingBattle.Anglers.Service.Models;

namespace FishingBattle.Anglers.Service.DB
{
    public class AnglerDbContext : DbContext
    {
        public AnglerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Angler> Anglers { get; set; } = null!;
    }
}
