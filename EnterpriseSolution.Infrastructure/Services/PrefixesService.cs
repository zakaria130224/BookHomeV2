using EnterpriseSolution.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSolution.Core.Entities;
using EnterpriseSolution.Core.Repositories;
using EnterpriseSolution.Core.Shared;

namespace EnterpriseSolution.Infrastructure.Services
{
    public class PrefixesService : IPrefixesService
    {
        private IRepository<Prefixes> prefixesRepository;

        public PrefixesService(IRepository<Prefixes> prefixesRepository)
        {
            this.prefixesRepository = prefixesRepository;
        }

        public Prefixes GetPrefixes(string prefixFor)
        {
            string prefix = string.Empty;

            var result = prefixesRepository.Get(x => x.PrefixFor.ToUpper() == prefixFor.ToUpper()).OrderByDescending(x => x.SerialNo).FirstOrDefault();

            long serialNo = result.SerialNo + 1;

            int prefixLenth = serialNo.ToString().Length > result.PrefixLength ? serialNo.ToString().Length : result.PrefixLength;

            if (prefixFor == Constants.Prefix.UserId || prefixFor == Constants.Prefix.BranchCode)
                prefix = serialNo.ToString().PadLeft(prefixLenth, '0');
            else
                prefix = result.Prefix.Substring(0, 2) + "" + serialNo.ToString().PadLeft(prefixLenth, '0');

            result.Prefix = prefix;

            result.SerialNo = serialNo;

            result.PrefixLength = prefixLenth;

            return prefixesRepository.Update(result);
        }
    }
}
