namespace StudentSystem.Data
{
    using StudentSystem.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IStudentSystemDbContext
    {
        IDbSet<Students> Students { get; set; }

        IDbSet<Courses> Courses { get; set; }

        IDbSet<Resources> Resources { get; set; }

        IDbSet<Homeworks> Homeworks { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
