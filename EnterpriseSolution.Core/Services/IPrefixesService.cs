using EnterpriseSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Services
{
    public interface IPrefixesService
    {
        Prefixes GetPrefixes(string prefixFor);
    }
}
