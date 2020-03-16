using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using csbc_server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace csbc_server.Repositories
{
    //Changes are being saved in this repository. Eventually, if we move to a Unit of Work model, we will remove and put the 
    //login in the UOM calls

    public class EFRepository<T> : IRepository<T> where T : class
    {
        public EFRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            Context = dbContext;
            DbSet = Context.Set<T>();
        }

        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual T Insert(T entity)
        {
            var dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
            Context.SaveChanges();
            return entity;
        }

        public virtual void Update(T entity)
        {
            var dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Modified;
            }
            dbEntityEntry.State = EntityState.Modified;
            Context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            var dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Deleted;
                
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
            Context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }


        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }

    }
}
