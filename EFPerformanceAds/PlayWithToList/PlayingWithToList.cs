namespace PlayWithToList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    public class PlayingWithToList
    {
        // Using Entity Framework select all ads from the database, then invoke ToList(),
        // then filter the categories by status "Published", then select ad title, category
        // and town, then invoke ToList() and finally order the ads by publish date. Rewrite
        // the same in more optimized way and compare the performance

        static void Main()
        {
            var context = new AdsEntities();
            var startTime = DateTime.Now;
            var ads = context.Ads;

            var publishedAdsSlow =
                ads
                .ToList()
                .Where(a => a.AdStatuses.Status == "Published")
                .ToList()
                .OrderBy(a => a.Date)
                .Select(a => new
                {
                    Title = a.Title,
                    Category = a.Categories,
                    Town = a.Towns
                })
                .ToList();

            foreach (var ad in ads)
            {
                Console.WriteLine("Status: {0}, Title: {1}, Category: {2}, Town: {3}",
                    ad.AdStatuses.Status,
                    ad.Title,
                    ad.Categories == null ? ("No category") : ad.Categories.Name,
                    ad.Towns == null ? ("No town") : ad.Towns.Name);
            }

            var time = startTime - DateTime.Now;
            Console.WriteLine("Time with include: {0}", time);

            //var publishedAdsFast =
            //    ads
            //    .Where(a => a.AdStatuses.Status == "Published")
            //    .OrderBy(a => a.Date)
            //    .Select(a => new
            //    {
            //        Title = a.Title,
            //        Category = a.Categories.Name,
            //        Town = a.Towns.Name
            //    }).ToList();

            //foreach (var ad in ads)
            //{
            //    Console.WriteLine("Status: {0}, Title: {1}, Category: {2}, Town: {3}",
            //        ad.AdStatuses.Status,
            //        ad.Title,
            //        ad.Categories == null ? ("No category") : ad.Categories.Name,
            //        ad.Towns == null ? ("No town") : ad.Towns.Name);
                
            //}

            //var time = startTime - DateTime.Now;
            //Console.WriteLine("Time without include: {0}", time);

        }
    }
}
