using EnterpriseSolution.Core;
//using EnterpriseSolution.Infrastructure.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Entities;

namespace EnterpriseSolution.Infrastructure.Helpers
{
    public class SessionHelper
    {
        private ISessionFactory sessionFactory;

        private readonly string connectionString;

        public SessionHelper(string pConnectionString)
        {
            connectionString = pConnectionString;
        }

        private ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                    InitializeSessionFactory();

                return sessionFactory;
            }
        }

        private void InitializeSessionFactory()
        {
            sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(connectionString)
                    .ShowSql()
                )

                // Use class mappings
                .Mappings(m =>
                {
                    ///TODO:need to add Foreign Key Convention later
                    m.FluentMappings.AddFromAssemblyOf<Entity>();
                })

                // Will drop and re-create tables
                //.ExposeConfiguration(cfg => new SchemaExport(cfg)
                //    .Create(true, true))

                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
