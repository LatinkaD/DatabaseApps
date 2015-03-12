namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Data.Migrations;

    class ConsoleClient
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
            var db = new StudentSystemDbContext();
            db.Students.Add(new Students
                {
                    Name = "LatinkaD",
                    PhoneNumber = "0897444111",
                    RegistrationDate = DateTime.Now,
                    Birthday = new DateTime(2015, 5, 5)
                });

            db.Students.Add(new Students
                {
                    Name = "GeorgeK",
                    PhoneNumber = "0987654321",
                    RegistrationDate = DateTime.Now,
                    Birthday = new DateTime(2015, 4, 5)
                });

            db.SaveChanges();
        }
    }
}
