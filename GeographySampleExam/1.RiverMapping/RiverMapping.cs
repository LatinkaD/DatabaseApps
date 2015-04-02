namespace _1.RiverMapping
{
    using System;

    class RiverMapping
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var continents = context.Continents;

            foreach (var continent in continents)
            {
                Console.WriteLine(continent.ContinentName);
            }
        }
    }
}
