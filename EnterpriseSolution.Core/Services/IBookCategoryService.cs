using EnterpriseSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Services
{
    public interface IBookCategoryService
    {
        IEnumerable<BookCategory> GetAll();

        BookCategory Insert(BookCategory BookCategory);

        BookCategory Update(BookCategory BookCategory);

        BookCategory GetById(long Id);
    }
}
