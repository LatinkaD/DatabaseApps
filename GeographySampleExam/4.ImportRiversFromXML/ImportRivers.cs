namespace _4.ImportRiversFromXML
{
    using _1.RiverMapping;
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    class ImportRivers
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var doc = XDocument.Load("../../rivers.xml");
            var riverNodes = doc.XPathSelectElements("/rivers/river");
            int i = 1;

            foreach (var riverNode in riverNodes)
            {
                Console.WriteLine("Precessing league #{0}", i++);
                string riverName = riverNode.Element("name").Value;
                int lenght = int.Parse(riverNode.Element("length").Value);
                string outflow = riverNode.Element("outflow").Value;

                int? drainageArea = null;
                if (riverNode.Element("drainage-area") != null)
                {
                    drainageArea = int.Parse(riverNode.Element("drainage-area").Value);
                }

                int? averageDischarge = null;
                if (riverNode.Element("average-discharge") != null)
                {
                    averageDischarge = int.Parse(riverNode.Element("average-discharge").Value);
                }

                var countryNodes = riverNode.XPathSelectElements("countries");
                var countryNames = countryNodes.Select(c => c.Value);
                foreach (var countryName in countryNames)
                {
                    var country = context.Countries
                        .FirstOrDefault(c => c.CountryName == countryName);
                    if (countryName == null)
                    {
                        throw new Exception("Can not find country: " + countryName);
                    }
                }

                var river = new River()
                {
                    RiverName = riverName,
                    Length = lenght,
                    Outflow = outflow,
                    DrainageArea = drainageArea,
                    AverageDischarge = averageDischarge
                };

                context.Rivers.Add(river);
                context.SaveChanges();
            }
        }
    }
}
