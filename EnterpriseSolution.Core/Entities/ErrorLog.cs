using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Entities
{
    [Table("ErrorLog")]
    public class ErrorLog : Entity
    {
        public  string Operations { get; set; }

        public  string ErrorMessage { get; set; }

        public  DateTime OccuredOn { get; set; }
    }
}
