using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Entities
{

    [Table("EmailConfiguration")]
    public class EmailConfiguration : Entity
    {
        public  string SmtpServer { get; set; }

        public  int SmtpPort { get; set; }

        public  string FromAddress { get; set; }

        public  string NetworkUserEmail { get; set; }

        public  string NetworkUserPass { get; set; }
    }
}
