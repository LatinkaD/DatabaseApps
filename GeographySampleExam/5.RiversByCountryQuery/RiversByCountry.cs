namespace _5.RiversByCountryQuery
{
    using _1.RiverMapping;
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    class RiversByCountry
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var doc = XDocument.Load("../../rivers-query.xml");
            var queryNodes = doc.XPathSelectElements("/queries/query");
            var queryResults = new XElement("results");

            foreach (var queryNode in queryNodes)
            {
                var countryElements = queryNode.XPathSelectElements("country");

                IQueryable<River> riversQuery = context.Rivers.AsQueryable();
                foreach (var countryElement in countryElements)
                {
                    var countryName = countryElement.Value;
                    riversQuery = riversQuery.Where(
                        r => r.Countries.Any(c => c.CountryName == countryName));
                }

                riversQuery = riversQuery.OrderBy(r => r.RiverName);
                var maxResultsAttribute = queryNode.Attribute("max-results");
                var riversElement = new XElement("rivers");
                riversElement.Add(new XAttribute("total-count", riversQuery.Count().ToString()));

                if (maxResultsAttribute != null)
                {
                    int maxResult = int.Parse(maxResultsAttribute.Value);
                    riversQuery = riversQuery.Take(maxResult);
                }

                var riverNames = riversQuery.Select(r => r.RiverName);
                foreach (var riverName in riverNames)
                {
                    riversElement.Add(new XElement("river", riverName));
                }
                riversElement.Add(new XAttribute("listed-count", riversQuery.Count().ToString()));
                queryResults.Add(riversElement);
            }

            Console.WriteLine(queryResults);
        }
    }
}
