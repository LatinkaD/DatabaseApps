using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected IStudentSystemDbContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }
       
        public GenericRepository(IStudentSystemDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expresion)
        {
            return this.DbSet.Where(expresion);
        }

        public T Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
            return entity;
        }

        public T Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            return entity;
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Delete(object id)
        {
            var entity = this.DbSet.Find(id);
            this.Delete(entity);
        }

        private T ChangeState(T entity, EntityState state)
        {
            var entry = this.Context.Entry(entity);
            entry.State = state;
            return entity;
        }

        private void AttachIfDetached(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached) 
            {
                entry.State = EntityState.Added;
            }
        }
    }
}
