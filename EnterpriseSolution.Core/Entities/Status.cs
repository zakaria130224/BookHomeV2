using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Entities
{
    [Table("Status")]
    public class Status : Entity
    {
        public  string StatusKey { get; set; }

        public  string StatusName { get; set; }
    }
}
