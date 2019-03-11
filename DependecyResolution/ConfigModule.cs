using EnterpriseSolution.Core.Services;
using EnterpriseSolution.Infrastructure.Services;
using Ninject.Modules;

namespace DependecyResolution
{
    public class ConfigModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigService>().To<ConfigService>();
        }
    }
}
