using EnterpriseSolution.Core.Entities;
using EnterpriseSolution.Core.Repositories;
using EnterpriseSolution.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        public readonly IRepository<BookCategory> bookCategoryRepository;
        public BookCategoryService(IRepository<BookCategory> bookCategoryRepository)
        {
            this.bookCategoryRepository = bookCategoryRepository;
        }
        public IEnumerable<BookCategory> GetAll()
        {
            return bookCategoryRepository.GetAll();
        }

        public BookCategory GetById(long Id)
        {
            return bookCategoryRepository.Get(Id);
        }

        public BookCategory Insert(BookCategory BookCategory)
        {
            return bookCategoryRepository.Insert(BookCategory);
        }

        public BookCategory Update(BookCategory BookCategory)
        {
            return bookCategoryRepository.Update(BookCategory);
        }
    }
}
