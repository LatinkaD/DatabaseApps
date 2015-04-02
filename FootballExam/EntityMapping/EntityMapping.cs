namespace EntityMapping
{
    using System;

    class EntityMapping
    {
        static void Main()
        {
            var context = new FootballEntities();
            var teamNames = context.Teams;

            foreach (var teamName in teamNames)
            {
                Console.WriteLine(teamName.TeamName);
            }
        }
    }
}
