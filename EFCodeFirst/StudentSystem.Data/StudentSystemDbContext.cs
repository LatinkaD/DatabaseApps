namespace StudentSystem.Data
{
    using StudentSystem.Models;
    using System.Data.Entity;
    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext()
            : base("StudentSystem")
        { 
        }

        public IDbSet<Students> Students { get; set; }

        public IDbSet<Courses> Courses { get; set; }

        public IDbSet<Resources> Resources { get; set; }

        public IDbSet<Homeworks> Homeworks { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>()
                .Property(x => x.Name)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
