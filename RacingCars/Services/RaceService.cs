using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RacingCars.Data;
using RacingCars.Interfaces;
using RacingCars.Models;
using RacingCars.VMs;

namespace RacingCars.Services
{
    public class RaceService : Controller, IRaceService
    {
        private readonly DBContext _context;
        public RaceService(DBContext context)
        {
            _context = context;
        }

        public void DeleteRace(long id)
        {
            Race race = _context.Races.FirstOrDefault(r => r.Id == id);
            if (race != null)
            {
                _context.Races.Remove(race);
                _context.SaveChanges();
            }
        }

        public List<Race> GetRaces()
        {
            return _context.Races.ToList();
        }

        public void InsertRace(RaceVM raceVM)
        {
            var testRace = _context.Races.FirstOrDefault(r => r.Track == raceVM.Track);
            if (testRace == null)
            {
                Race race = ToRace(raceVM);
                _context.Races.Add(race);
                _context.SaveChanges();
            }
        }

        public RaceVM SingleRace(long id)
        {
            Race race = _context.Races.FirstOrDefault((r) => (r.Id == id));
            return new RaceVM()
            {
                Id = race.Id,
                IdPilot = race.IdPilot,
                IdCar = race.IdCar,
                Track = race.Track,
                Mileage = race.Mileage,
                Pilot = race.Pilot,
                Car = race.Car,
                Points = race.Points,
                Duration = race.Duration,
                DateOfCompetition = Convert.ToDateTime(race.DateOfCompetition)
            };
        }
        public void UpdateRace(long id, RaceVM race)
        {
            Race data = ToRace(race);
            var local = _context.Set<Race>().Local.FirstOrDefault(entry => entry.Id.Equals(data.Id));
            // check if local is not null
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }
        private Race ToRace(RaceVM race)
        {
            return new Race()
            {
                Id = race.Id,
                IdPilot = race.IdPilot,
                IdCar = race.IdCar,
                Track = race.Track,
                Mileage = race.Mileage,
                Pilot = race.Pilot,
                Car = race.Car,
                Points = race.Points,
                Duration = race.Duration,
                DateOfCompetition = race.DateOfCompetition.ToShortDateString()
            };
        }
    }
}
