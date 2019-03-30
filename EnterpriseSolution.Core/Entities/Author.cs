using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Entities
{
    public class Author:Entity
    {
        public string AuthorName { get; set; }
        public string AuthorShortCode { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public bool IsActive { get; set; }
       // ICollection<Book> Books { get; set; }
    }
}
