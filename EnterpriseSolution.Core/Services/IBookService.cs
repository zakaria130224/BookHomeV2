using EnterpriseSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();

        Book Insert(Book book);

        Book Update(Book book);

        Book Get(long Id);

        Book Delete(Book book);
    }
}
