using EnterpriseSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Services
{
   public  interface IAuthorService
    {
        IEnumerable<Author> GetAll();

        Author Insert(Author author);

        Author Update(Author author);

        Author Get(long Id);

        Author Delete(Author author);
    }
}
