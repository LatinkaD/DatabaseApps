namespace _2.ExportRiversAsJson
{
    using _1.RiverMapping;
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    class ExportRiversAsJson
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var rivers = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                {
                    r.RiverName,
                    r.Length,
                    Countries = r.Countries
                        .OrderBy(c => c.CountryName)
                        .Select(c => c.CountryName)
                });

            var serializer = new JavaScriptSerializer();
            var riversJson = serializer.Serialize(rivers);

            File.WriteAllText("../../rivers.json", riversJson);
        }
    }
}
