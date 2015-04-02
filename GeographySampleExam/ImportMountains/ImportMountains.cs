namespace ImportMountains
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using MountainsCodeFirst;
    using Newtonsoft.Json.Linq;

    class ImportMountains
    {
        static void Main()
        {
            string json = File.ReadAllText("../../mountains.json");
            var mountains = JArray.Parse(json);

            foreach (var mountain in mountains)
            {
                try
                {
                    ImportMountain(mountain);
                    Console.WriteLine("Mountain {0} imported.", mountain["mountainName"]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            
        }

        private static void ImportMountain(JToken mountainObj)
        {
            var context = new MountainContext();
            var mountain = new Mountain();

            if (mountainObj["mountainName"] == null)
            {
                throw new Exception("Missing mountain name");
            }

            mountain.Name = mountainObj["mountainName"].Value<string>();

            var peaks = mountainObj["peaks"];
            if (peaks != null)
            {
                foreach (var peak in peaks)
                {
                    if (peak["peakName"] == null)
                    {
                        throw new Exception("Missing peak name");
                    }
                    string peakName = peak["peakName"].Value<string>();

                    if (peak["elevation"] == null)
                    {
                        throw new Exception("Missing elevation");
                    }
                    int elevation = peak["elevation"].Value<int>();

                    mountain.Peaks.Add(new Peak() { Name = peakName, Elevation = elevation });
                }
            }

            var countryNames = mountainObj["countries"];
            if (countryNames != null)
            {
                foreach (var countryName in countryNames)
                {
                    var countryCode = new string(countryName.Value<string>().ToUpper().Take(2).ToArray());
                    var country = context.Countries.Find(countryCode);
                    if (country == null)
                    {
                        country = new Country() { Code = countryCode, Name = countryName.Value<string>() };
                    }

                    mountain.Countries.Add(country);
                }
            }

            context.Mountains.Add(mountain);
            context.SaveChanges();
        }
    }
}
