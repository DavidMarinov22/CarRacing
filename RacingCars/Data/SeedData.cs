using Microsoft.EntityFrameworkCore;
using RacingCars.Models;
using RacingCars.VMs;

namespace RacingCars.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DBContext>>()))
            {
                // Look for any movies.
                if (context.Pilots.Any() && context.Cars.Any())
                {
                    return;   // DB has been seeded
                }
                string[] names = new[]
                {
                    "Liam",         "Olivia"
                    ,"Noah",        "Emma"
                    ,"Oliver",      "Charlotte"
                    ,"Elijah",      "Amelia"
                    ,"James",       "Ava"
                    ,"William",     "Sophia"
                    ,"Benjamin",    "Isabella"
                    ,"Lucas",       "Mia"
                    ,"Henry",       "Evelyn"
                    ,"Theodore",    "Harper"
                };
                if (!context.Cars.Any())
                {

                    context.AddRange(
                        new Car
                        {
                            Name = "Formula",
                            Brand = "F1",
                            Mileage = 100000,
                            DateOfService = DateTime.Now.ToShortDateString()
                        });

                }
                if (!context.Pilots.Any())
                {
                    int randomnum = new Random().Next(1, 10);
                    for (int j = 0; j <= randomnum; j++)
                    {

                        int randomIndex = new Random().Next(0, names.Length);
                        string name = names[randomIndex];

                        string randomName = new string(name);
                        int randomAge = new Random().Next(18, 60);
                        context.AddRange(
                            new PilotVM
                            {
                                Name = randomName,
                                Age = randomAge,
                                Nationality = randomName
                            });
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
