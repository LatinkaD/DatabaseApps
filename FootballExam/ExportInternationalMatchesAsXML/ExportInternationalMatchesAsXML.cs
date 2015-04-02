namespace ExportInternationalMatchesAsXML
{
    using EntityMapping;
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class ExportInternationalMatchesAsXML
    {
        static void Main()
        {
            var context = new FootballEntities();
            var xmlRoot = new XElement("matches");

            var matchesQuery = context.InternationalMatches
                .OrderBy(m => m.MatchDate)
                .Select(m => new
                {
                    HomeCountry = m.Country1.CountryName,
                    HomeCode = m.Country1.CountryCode,
                    AwayCountry = m.Country.CountryName,
                    AwayCode = m.Country.CountryCode,
                    m.MatchDate,
                    League = m.League.LeagueName,
                    m.HomeGoals,
                    m.AwayGoals
                });

            foreach (var matchQuery in matchesQuery)
            {
                var xmlMatch = new XElement("match");
                if (matchQuery.MatchDate != null)
                {
                    xmlMatch.Add(new XAttribute("date-time", string.Format("{0:dd-MMM-yyyy HH:mm}",
                        matchQuery.MatchDate)));
                }

                var homeCountryElement = new XElement("home-country", matchQuery.HomeCountry);
                homeCountryElement.Add(new XAttribute("code", matchQuery.HomeCode));
                xmlMatch.Add(homeCountryElement);

                var awayCountryElement = new XElement("away-country", matchQuery.AwayCountry);
                awayCountryElement.Add(new XAttribute("code", matchQuery.AwayCode));
                xmlMatch.Add(awayCountryElement);

                if (matchQuery.HomeGoals != null && matchQuery.AwayGoals != null)
                {
                    var scoreElement = new XElement("score", string.Format("{0}-{1}",
                        matchQuery.HomeGoals, matchQuery.AwayGoals));
                    xmlMatch.Add(scoreElement);
                }

                if (matchQuery.League != null)
                {
                    xmlRoot.Add(new XElement("league", matchQuery.League));
                }

                xmlRoot.Add(xmlMatch);
            }

            var xmlDoc = new XDocument(xmlRoot);
            xmlDoc.Save("../../international-matches.xml");
        }
    }
}
