using Microsoft.EntityFrameworkCore;
using FishingBattle.Anglers.Service.DB;
using FishingBattle.Anglers.Service.Models;
using FishingBattle.Anglers.Service.Interfaces;

namespace FishingBattle.Anglers.Service.Repositories
{
    public class AnglerRepository : IAnglerRepository
    {
        private readonly AnglerDbContext _anglerDbContext;
        private readonly ILogger<AnglerRepository> _logger;

        public AnglerRepository(AnglerDbContext anglerDbContext, ILogger<AnglerRepository> loger)
        {
            _anglerDbContext = anglerDbContext;
            _logger = loger;
        }

        public async Task<Angler?> GetAngler(int id)
        {
            return await _anglerDbContext.Anglers.FindAsync(id);
        }

        public async Task<IEnumerable<Angler>> GetAllAnglers()
        { 
            return await _anglerDbContext.Anglers.ToListAsync();
        }

        public async Task<Angler> CreateAngler(Angler angler)
        { 
            var createdAngler = await _anglerDbContext.Anglers.AddAsync(angler);
            await _anglerDbContext.SaveChangesAsync();

            return createdAngler.Entity;
        }

        public async Task<bool> UpdateAngler(Angler angler)
        {
            var isSaved = false;

            _anglerDbContext.Anglers.Update(angler);

            try
            {
                isSaved = await _anglerDbContext.SaveChangesAsync() > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.Log(LogLevel.Trace, ex, $"Failed to update angler: {angler}");
                return isSaved;
            }

            return isSaved;
        }

        public async Task<bool> DeleteAngler(int id)
        {
            var isDeleted = false;
            var angler = await _anglerDbContext.Anglers.FindAsync(id);
            if (angler != null)
            {
                _anglerDbContext.Anglers.Remove(angler);
                isDeleted = await _anglerDbContext.SaveChangesAsync() > 0;
            }

            return isDeleted;
        }
    }
}
