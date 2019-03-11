using EnterpriseSolution.Core.Services;
using System.Configuration;

namespace EnterpriseSolution.Infrastructure.Services
{
    public class ConfigService : IConfigService
    {
        public string ConnectionString
        {
            get
            {
                string cnString = null;
                var cnSettings = ConfigurationManager.ConnectionStrings["DatabaseContext"];
                if (cnSettings != null)
                {
                    cnString = cnSettings.ConnectionString;
                }
                return cnString;
            }
        }
    }
}
