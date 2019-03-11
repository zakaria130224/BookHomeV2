using EnterpriseSolution.Core;
using EnterpriseSolution.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using EnterpriseSolution.Infrastructure.Helpers;
using System.Data.Entity;
using NHibernate;

namespace EnterpriseSolution.Infrastructure.Repository
{
    public class Repository<TEntity> : RepositoryBase, IRepository<TEntity> where TEntity : Entity
    {
        readonly SessionHelper connection;
       

        public Repository(string pConnectionString) : base(pConnectionString)
        {
            connection = new SessionHelper(connectionString);
        }
              
        public TEntity Get(object id)
        {
            using (var con = connection.OpenSession())
            {
                return con.Get<TEntity>(id);
            }
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            using (var con = connection.OpenSession())
            {
                return con.QueryOver<TEntity>().Where(predicate).List();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var con = connection.OpenSession())
            {
                return con.QueryOver<TEntity>().List();
            }
        }

        public TEntity Insert(TEntity model, bool persist = false)
        {
            try
            {
                using (var con = connection.OpenSession())
                {
                    using (var transaction = con.BeginTransaction())
                    {
                        con.Save(model);
                        transaction.Commit();
                    }
                }
                return model;
            }
            catch (Exception)
            {
                 throw;
            }
        }
        
        public TEntity Update(TEntity model, bool persist = false)
        {
            try
            {
                using (var con = connection.OpenSession())
                {
                    using (var transaction = con.BeginTransaction())
                    {
                        con.Update(model);
                        transaction.Commit();
                    }
                }
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id, bool persist = false)
        {
            using (var con = connection.OpenSession())
            {
                TEntity model = con.Get<TEntity>(id);
                Delete(model, persist);
            }
        }

        public void Delete(TEntity model, bool persist = false)
        {
            if (model != null)
            {
                using (var con = connection.OpenSession())
                {
                    var transaction = con.BeginTransaction();
                    try
                    {
                        con.Delete(model);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
