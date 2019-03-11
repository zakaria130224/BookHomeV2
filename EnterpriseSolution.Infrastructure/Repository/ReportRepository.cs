using EnterpriseSolution.Core.Repositories;
using EnterpriseSolution.Infrastructure.EnterpriseDbContext;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Repository
{
    public class ReportRepository : IReportRepository
    {
        private string connectionString;
        public ReportRepository()
        {
            var cnSettings = ConfigurationManager.ConnectionStrings["DatabaseContext"];
            if (cnSettings != null)
            {
                connectionString = cnSettings.ConnectionString;
            }
        }

        public DataSet GetStoredProcedureRecords(string storeProcedureName, IEnumerable<SqlParameter> parameters)
        {
            var dataSet = new DataSet();
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = storeProcedureName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataSet);
                    }
                }
            }

            return dataSet;
        }
    }
}
