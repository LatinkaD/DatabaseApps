namespace ShowData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    public class ShowDataFromRelatedTables
    {
        static void Main()
        {
            //WithoutInclude();
            WithInclude();
        }

        //private static void WithoutInclude()
        //{
        //    // Using Entity Framework write a SQL query to select all ads from the database and later print their title,
        //    // status, category, town and user

        //    var context = new AdsEntities();
        //    var startTime = DateTime.Now;
        //    var ads = context.Ads;

        //    foreach (var ad in ads)
        //    {
        //        Console.WriteLine("Ad: Title: {0}, Status: {1}, Category: {2}, Town: {3}, User: {4}",
        //            ad.Title,
        //            ad.AdStatus.Status,
        //            ad.Category == null ? ("No Category") : ad.Category.Name,
        //            ad.Town == null ? ("No Town Aveliable") : ad.Town.Name,
        //            ad.AspNetUser.UserName);
        //    }

        //    var time = startTime - DateTime.Now;
        //    Console.WriteLine("Time without include: {0}", time);
        //}

        private static void WithInclude()
        {
            // Add Include(…) to select statuses, categories, towns and users along with all ads. 
            // Compare the number of executed SQL statements and the performance before and after adding Include(…)

            var context = new AdsEntities();
            var startTime = DateTime.Now;
            var ads = context.Ads;

            foreach (var ad in ads
                .Include(a => a.AdStatus)
                .Include(a => a.Category)
                .Include(a => a.Town)
                .Include(a => a.AspNetUser))
            {
                Console.WriteLine("Ad: Title: {0}, Status: {1}, Category: {2}, Town: {3}, User: {4}",
                       ad.Title,
                       ad.AdStatus.Status,
                       ad.Category == null ? ("No Category") : ad.Category.Name,
                       ad.Town == null ? ("No Town Aveliable") : ad.Town.Name,
                       ad.AspNetUser.UserName);
            }

            var time = startTime - DateTime.Now;
            Console.WriteLine("Time with include: {0}", time);


        }
    }
}
