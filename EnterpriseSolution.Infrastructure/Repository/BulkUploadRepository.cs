using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Repositories;
using EnterpriseSolution.Core.Entities;
using EnterpriseSolution.Infrastructure.Helpers;
using EnterpriseSolution.Core.Shared;
using System.Reflection;
using System.ComponentModel;

namespace EnterpriseSolution.Infrastructure.Repository
{
    public class BulkUploadRepository : RepositoryBase, IBulkUploadRepository
    {
        private readonly int chunkRowLimit;

        public BulkUploadRepository(string pConnectionString) : base(pConnectionString)
        {
            chunkRowLimit = 3;
        }

        public IEnumerable<DataTable> GetFileData(string sourceDirectory, string dbTableName)
        {
            //variable declearation area
            bool firstLineOfChunk = true;
            int chunkRowCount = 0;
            DataTable chunkDataTable = null;
            string columnData = null;
            bool firstLineOfFile = true;

            //Chunk creating process starts
            using (var sr = new StreamReader(sourceDirectory))
            {
                string line = null;
                //Read lines from the file until the end of the file is reached.                
                while ((line = sr.ReadLine()) != null)
                {
                    //when reach first line it is column list need to create datatable based on that.
                    if (firstLineOfFile)
                    {
                        columnData = line;
                        firstLineOfFile = false;
                        continue;
                    }
                    if (firstLineOfChunk)
                    {
                        firstLineOfChunk = false;
                        chunkDataTable = CreateEmptyDataTable(columnData, dbTableName);
                    }
                    AddRow(chunkDataTable, line);
                    chunkRowCount++;

                    if (chunkRowCount == chunkRowLimit)
                    {
                        firstLineOfChunk = true;
                        chunkRowCount = 0;
                        yield return chunkDataTable;
                        chunkDataTable = null;
                    }
                }
            }
            //return last set of data which less then chunk size
            if (null != chunkDataTable)
                yield return chunkDataTable;
        }

        public string WriteChunkData(DataTable table, IList<KeyValuePair<string, string>> mapList, string destinationTableName)
        {
            using (var bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.Default))
            {
                bulkCopy.BulkCopyTimeout = 0;//unlimited
                bulkCopy.DestinationTableName = destinationTableName;
                foreach (KeyValuePair<string, string> map in mapList)
                {
                    bulkCopy.ColumnMappings.Add(map.Key, map.Value);
                }

                try
                {
                    bulkCopy.WriteToServer(table, DataRowState.Added);
                    bulkCopy.Close();
                    return "Success";
                }
                catch (Exception ex)
                {
                    bulkCopy.Close();
                    if (ex.GetBaseException().Message.Contains("does not match up with any column in data source"))
                        return "Invalid File";
                    else
                        return "Failed";
                }
            }
        }

        private DataTable CreateEmptyDataTable(string firstLine, string tableName)
        {
            try
            {
                IEnumerable<string> columnList = LineSplitter(firstLine);
                var dataTable = new DataTable(tableName);
                
                foreach (var item in columnList)
                {
                    var dataColumn = new DataColumn(item);
                    dataTable.Columns.Add(dataColumn);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void AddRow(DataTable dataTable, string line)
        {
            try
            {
                DataRow newRow = dataTable.NewRow();
                var fieldData = LineSplitter(line);
                for (int columnIndex = 0; columnIndex < dataTable.Columns.Count; columnIndex++)
                {
                    newRow[columnIndex] = fieldData.ElementAt(columnIndex);
                }
                dataTable.Rows.Add(newRow);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IEnumerable<string> LineSplitter(string line)
        {
            int fieldStart = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    yield return line.Substring(fieldStart, i - fieldStart);
                    fieldStart = i + 1;
                }
                if (line[i] == '"')
                    for (i++; line[i] != '"'; i++) { }

            }
            yield return line.Substring(fieldStart, (line.Length) - fieldStart);
        }
        
    }
}
