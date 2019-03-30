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
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> authorRepository;
        public AuthorService(IRepository<Author> authorRepository)
        {
            this.authorRepository = authorRepository;

        }
        public Author Delete(Author author)
        {
            return authorRepository.Delete(author);
        }

        public Author Get(long Id)
        {
            return authorRepository.Get(Id);
        }

        public IEnumerable<Author> GetAll()
        {
            return authorRepository.GetAll();
        }

        public Author Insert(Author author)
        {
            return authorRepository.Insert(author);
        }

        public Author Update(Author author)
        {
            return authorRepository.Update(author);
        }
    }
}
