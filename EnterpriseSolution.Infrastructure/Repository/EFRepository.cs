using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core;
using EnterpriseSolution.Core.Entities;
using EnterpriseSolution.Core.Repositories;
using EnterpriseSolution.Infrastructure.EnterpriseDbContext;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;

namespace EnterpriseSolution.Infrastructure.Repository
{
    public class EFRepository<TEntity> : RepositoryBase, IRepository<TEntity> where TEntity : Entity
    {

        public DatabaseContext db { get; private set; }

        public DbSet<TEntity> Table
        {
            get
            {
                //testing
                var context = ((IObjectContextAdapter)db).ObjectContext;
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, db.Set<TEntity>());

                return db.Set<TEntity>();
            }
        }

        public EFRepository(string pConnectionString) : base(pConnectionString)
        {
            db = new DatabaseContext();
        }

        public void Delete(long id, bool persist = false)
        {
            var entity = this.Get(id);
            Table.Attach(entity);
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();

        }

        public void Delete(TEntity model, bool persist = false)
        {
            db.Entry(model).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public TEntity Get(object id)
        {
            return Table.Find(id);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            //testing
            //var context = ((IObjectContextAdapter)db).ObjectContext;
            //context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, db.Set<TEntity>());

            return Table.ToList();
        }

        public TEntity Insert(TEntity model, bool persist = false)
        {
            Table.Add(model);
            db.SaveChanges();
            return model;
        }

        public TEntity Update(TEntity model, bool persist = false)
        {
            db.Set<TEntity>().AddOrUpdate(model);
            db.SaveChanges();
            return model;
        }
    }
}
