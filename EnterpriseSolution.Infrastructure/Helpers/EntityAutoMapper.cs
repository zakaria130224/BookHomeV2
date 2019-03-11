
using EnterpriseSolution.Core;
using EnterpriseSolution.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Helpers
{

    public class EntityAutoMapper<TEntity> where TEntity: Entity
    {
        //public List<TEntity> MapDataTableToEntity<TEntity>(this DataTable table) where TEntity : class, new()
        //{
        //    try
        //    {
        //        List<TEntity> list = new List<TEntity>();

        //        foreach (var row in table.AsEnumerable())
        //        {
        //            TEntity obj = new TEntity();

        //            foreach (var prop in obj.GetType().GetProperties())
        //            {
        //                try
        //                {
        //                    PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
        //                    propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
        //                }
        //                catch
        //                {
        //                    continue;
        //                }
        //            }

        //            list.Add(obj);
        //        }

        //        return list;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}


        /*public static List<TEntity> MapDataTableToEntity(DataTable dataTable)
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<DataTable, TEntity>();
                    cfg.ForAllMaps((map, exp) => exp.ForAllOtherMembers(opt => opt.Ignore()));
                });

                //IMapper mapper = config.CreateMapper();
                //List<TEntity> result = mapper.Map<IDataReader, List<TEntity>>(dataTable.CreateDataReader());

                //List<TEntity> result = Mapper.CreateMap<IDataReader, List<TEntity>>(dataTable.CreateDataReader());

                Mapper.Initialize(cfg => cfg.CreateMissingTypeMaps = true);
                var result = Mapper.Map<IDataReader, IEnumerable<TEntity>>(dataTable.CreateDataReader());

                return result.ToList();
            }
            catch (Exception ex)
            {
                string error = ex.GetBaseException().Message;
                throw;
            }
        }*/
    }
}
