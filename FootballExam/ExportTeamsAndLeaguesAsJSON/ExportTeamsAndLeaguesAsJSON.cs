namespace ExportTeamsAndLeaguesAsJSON
{
    using EntityMapping;
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    class ExportTeamsAndLeaguesAsJSON
    {
        static void Main()
        {
            var context = new FootballEntities();
            var leagues = context.Leagues
                .OrderBy(l => l.LeagueName)
                .Select(l => new 
                {
                    leagueName = l.LeagueName,
                    teams = l.Teams
                        .OrderBy(t => t.TeamName)
                        .Select(t => t.TeamName)
                });

            var serializer = new JavaScriptSerializer();
            var leaguesJson = serializer.Serialize(leagues);
            File.WriteAllText("../../leagues-and-teams.json", leaguesJson);
        }
    }
}
