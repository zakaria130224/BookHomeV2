using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Core.Services
{
    public interface INotificationService
    {
        void SendNotificationEmail(string toAddress, string emailNotificationFor, string dearConcerned);
    }
}
