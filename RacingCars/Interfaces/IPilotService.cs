using RacingCars.VMs;

namespace RacingCars.Interfaces
{
    public interface IPilotService
    {
        List<PilotVM> GetPilots();
        void InsertPilot(PilotVM pilot);
        void UpdatePilot(long id, PilotVM pilot);
        PilotVM SinglePilot(long id);
        void DeletePilot(long id);
    }
}
