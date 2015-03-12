namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystem.Data.StudentSystemDbContext context)
        {
            context.Students.AddOrUpdate(new Students
                {
                    Name = "MalinaD",
                    PhoneNumber = "0897563214",
                    Birthday = new DateTime(2015, 08, 14),
                    RegistrationDate = DateTime.Now
                });

            context.Courses.AddOrUpdate(new Courses
                {
                    Name = "Databases",
                    Description = "MSSQL, MySql, Oracle, etc."
                });

            context.Resources.AddOrUpdate(new Resources
                {
                    Name = "Entity Framework Code First",
                    Link = "https://softuni.bg/Trainings/Resources/Video/3565/Video-04-March-2015-Vladimir-Georgiev-Database-Applications-Mar-2015"
                });

            context.SaveChanges();
        }
    }
}
