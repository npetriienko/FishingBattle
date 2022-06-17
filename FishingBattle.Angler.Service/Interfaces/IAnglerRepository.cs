using FishingBattle.Anglers.Service.Models;

namespace FishingBattle.Anglers.Service.Interfaces
{
    public interface IAnglerRepository
    {
        Task<Angler?> GetAngler(int id);
        Task<IEnumerable<Angler>> GetAllAnglers();
        Task<Angler> CreateAngler(Angler angler);
        Task<bool> UpdateAngler(Angler angler);
        Task<bool> DeleteAngler(int id);
    }
}
