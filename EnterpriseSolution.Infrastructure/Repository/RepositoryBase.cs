using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Repository
{
    public class RepositoryBase
    {
        protected string connectionString;

        public RepositoryBase(string pConnectionString)
        {
            connectionString = pConnectionString;
        }
    }
}
