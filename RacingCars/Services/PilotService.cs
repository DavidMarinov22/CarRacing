using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RacingCars.Data;
using RacingCars.Interfaces;
using RacingCars.VMs;

namespace RacingCars.Services
{
    public class PilotService : Controller, IPilotService
    {
        private readonly DBContext _context;
        public PilotService(DBContext context)
        {
            _context = context;
        }

        public void DeletePilot(long id)
        {
            PilotVM pilot = _context.Pilots.FirstOrDefault(p => p.Id == id);
            if (pilot != null)
            {
                _context.Pilots.Remove(pilot);
                _context.SaveChanges();
            }
        }

        public List<PilotVM> GetPilots()
        {
            return _context.Pilots.ToList();
        }

        public void InsertPilot(PilotVM pilot)
        {
            var testPilot = _context.Pilots.FirstOrDefault(p => p.Name == pilot.Name);
            if (testPilot == null)
            {
                _context.Pilots.Add(pilot);
                _context.SaveChanges();
            }
        }

        public PilotVM SinglePilot(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePilot(long id, PilotVM pilot)
        {
            var local = _context.Set<PilotVM>().Local.FirstOrDefault(entry => entry.Id.Equals(pilot.Id));
            // check if local is not null
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(pilot).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
