namespace MountainsCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    class MountainsCodeFirst
    {
        static void Main()
        {
            Database.SetInitializer(new MountainMigration());
            var context = new MountainContext();
            var countriesQuery = context.Countries
                .Select(c => new
                {
                    CountryName = c.Name,
                    Mountsains = c.Mountains.Select(m => new
                    {
                        m.Name,
                        m.Peaks
                    })
                });

            foreach (var country in countriesQuery)
            {
                Console.WriteLine("Country: " + country.CountryName);

                foreach (var mountain in country.Mountsains)
                {
                    Console.WriteLine(" Mountain: " + mountain.Name);

                    foreach (var peak in mountain.Peaks)
                    {
                        Console.WriteLine("\t {0} {1} " ,peak.Name, peak.Elevation);
                    }
                }
            }
        }
    }
}
