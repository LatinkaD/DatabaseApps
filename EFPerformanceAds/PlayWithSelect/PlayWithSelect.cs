using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithSelect
{
    class PlayWithSelect
    {
        // Write a program to compare the execution speed between these two scenarios:
        // •	Select everything from the Ads table and print the ad title.
        // •	Select the ad title from Ads table.

        static void Main()
        {
            var context = new AdsEntities();
            var startTime = DateTime.Now;

            // Slow Select
            //var ads = context.Ads;
            //foreach (var ad in ads)
            //{
            //    Console.WriteLine("Title: ", ad.Title);            
            //}

            // Fast Select
            var ads = context.Ads.Select(a => a.Title);
            foreach (var ad in ads)
            {
                Console.WriteLine();
            }

            var endTime = DateTime.Now;
            Console.WriteLine(endTime - startTime);
        }
    }
}
