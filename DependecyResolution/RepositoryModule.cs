using EnterpriseSolution.Core.Repositories;
using EnterpriseSolution.Core.Services;
using EnterpriseSolution.Infrastructure.Repository;
using EnterpriseSolution.Infrastructure.Services;
using Ninject;
using Ninject.Modules;


namespace DependecyResolution
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            // Get Config Service
            var configService = Kernel.Get<IConfigService>();

            // Bind generic repositories
            Bind(typeof(IRepository<>)).To(typeof(EFRepository<>)).InSingletonScope().WithConstructorArgument("pConnectionString", configService.ConnectionString);

           

            // Bind others repositories
            Bind<IUsersRepository>().To<UsersRepository>().WithConstructorArgument("pConnectionString", configService.ConnectionString);



            Bind<IUserDetailsService>().To<UserDetailsService>();

            Bind<INotificationService>().To<NotificationService>();

            Bind<IPrefixesService>().To<PrefixesService>();


            Bind<IUserRoleService>().To<UserRoleService>();

            Bind<IBranchService>().To<BranchService>();

        }
    }
}
