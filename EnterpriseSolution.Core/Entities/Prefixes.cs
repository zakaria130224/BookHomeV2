using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Entities
{
    [Table("Prefixes")]
    public class Prefixes : Entity
    {
        public  string PrefixFor { get; set; }

        public  string Prefix { get; set; }

        public  long SerialNo { get; set; }

        public int PrefixLength { get; set; }
    }
}
