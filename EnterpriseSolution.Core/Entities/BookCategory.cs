using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Entities
{
   public class BookCategory : Entity
    {
        public string CategoryName { get; set; }
        public string CategoryShortCode { get; set; }
        public bool IsActive { get; set; }
        //ICollection<Book> Books { get; set; }

    }
}
