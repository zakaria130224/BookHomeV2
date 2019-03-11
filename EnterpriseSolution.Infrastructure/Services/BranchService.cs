using EnterpriseSolution.Core.Entities;
using EnterpriseSolution.Core.Repositories;
using EnterpriseSolution.Core.Services;
using EnterpriseSolution.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Services
{
    public class BranchService : IBranchService
    {
        private IRepository<Branches> branchRepository;
        private IPrefixesService prefixesService;
        public BranchService(IRepository<Branches> branchRepository, IPrefixesService prefixesService)
        {
            this.branchRepository = branchRepository;
            this.prefixesService = prefixesService;
        }
        public IEnumerable<Branches> GetAllBranches()
        {
            return branchRepository.GetAll();
        }

        public Branches GetBrancheById(long Id)
        {
            return branchRepository.Get(Id);
        }

        public Branches InsertBranches(Branches branche)
        {
            ///TODO: branch code should be genarate 
            branche.Code = prefixesService.GetPrefixes(Constants.Prefix.BranchCode).Prefix;
            branchRepository.Insert(branche);
            return branchRepository.Get(branche.Id);
        }

        public Branches UpdateBranches(Branches branches)
        {
            branchRepository.Update(branches);
            return branchRepository.Get(branches.Id);
        }
    }
}
