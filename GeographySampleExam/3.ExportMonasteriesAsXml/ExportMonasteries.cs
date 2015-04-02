namespace _3.ExportMonasteriesAsXml
{
    using System;
    using _1.RiverMapping;
    using System.Linq;
    using System.Xml.Linq;

    class ExportMonasteries
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var countries = context.Countries
                .OrderBy(c => c.CountryName)
                .Select(c => new
            {
                c.CountryName,
                Monasteries = c.Monasteries
                    .OrderBy(m => m.Name)
                    .Select(m => m.Name)
            });

            var xmlRoot = new XElement("monasteries");
            foreach (var country in countries)
            {
                if (country.Monasteries.Any())
                {
                    var xmlCountry = new XElement("country");
                    xmlCountry.Add(new XAttribute("name", country.CountryName));            

                    foreach (var monastery in country.Monasteries)
                    {
                        xmlCountry.Add(new XElement("monastery", monastery));
                    }

                    xmlRoot.Add(xmlCountry);
                }
            }

            var xmlDoc = new XDocument(xmlRoot);
            xmlDoc.Save("../../monasteries.xml");
        }
    }
}
