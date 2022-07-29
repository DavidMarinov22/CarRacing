using RacingCars.Models;
using RacingCars.VMs;

namespace RacingCars.Interfaces
{
    public interface IRaceService
    {
        List<Race> GetRaces();
        void InsertRace(RaceVM race);
        void UpdateRace(long id, RaceVM race);
        RaceVM SingleRace(long id);
        void DeleteRace(long id);
    }
}
