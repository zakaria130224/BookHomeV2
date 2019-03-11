using EnterpriseSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Services
{
    public interface IBranchService
    {
        IEnumerable<Branches> GetAllBranches();

        Branches InsertBranches(Branches branche);

        Branches UpdateBranches(Branches branches);

        Branches GetBrancheById(long Id);
    }
}
