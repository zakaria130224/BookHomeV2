using EnterpriseSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Repositories
{
    public interface IBulkUploadRepository
    {
        IEnumerable<DataTable> GetFileData(string sourceDirectory, string dbTableName);
        
        string WriteChunkData(DataTable table, IList<KeyValuePair<string, string>> mapList, string destinationTableName);
    }
}
