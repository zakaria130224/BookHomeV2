using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Entities
{
    public class Book : Entity
    {
        public string RefNo { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double  Price{ get; set; }
        public string ShortDescription{ get; set; }
        public bool IsActive { get; set; }

       
        public long AuthorId{ get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

       
        public long BookCategoryId { get; set; }
        [ForeignKey("BookCategoryId")]
        public virtual BookCategory BookCategory { get; set; }


    }
}
