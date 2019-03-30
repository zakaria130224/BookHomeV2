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
    public class BookService : IBookService
    {
        private readonly IRepository<Book> bookRepository;
        public BookService(IRepository<Book> bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public Book Delete(Book book)
        {
          return  bookRepository.Delete(book);
        }

        public Book Get(long Id)
        {
            return bookRepository.Get(Id);
        }

        public IEnumerable<Book> GetAll()
        {
            return bookRepository.GetAll();
        }

        public Book Insert(Book book)
        {
            return bookRepository.Insert(book);
        }

        public Book Update(Book book)
        {
            return bookRepository.Update(book);
        }
    }
}
