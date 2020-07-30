using System.Linq;
using System.Reflection;
using DataAccess.Contracts;
using DataAccess.Contracts.DocumentTypes;
using DataAccess.Contracts.Pattern;
using DataAccess.Repositories.Pattern;
using EntityServices.Services.DocumentTypes;
using Framework.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace EntityServices.Installer
{
    public class RegisterServicesUsingAutoRegisterDiInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, AppSettings appSettings, Assembly startupProjectAssembly)
        {
            var dataAssembly = typeof(IDocumentsRepository).Assembly;
            var serviceAssembly = typeof(DocumentsService).Assembly;
            var configurationAssembly = Assembly.GetExecutingAssembly();
            var assembliesToScan = new[] { dataAssembly, serviceAssembly, configurationAssembly };

            #region Generic Type Dependencies
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            #endregion

            #region Scoped Dependency Interface
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.GetInterfaces().Contains(typeof(IScopedDependency)))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
            #endregion

            #region Singleton Dependency Interface
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.GetInterfaces().Contains(typeof(ISingletonDependency)))
                .AsPublicImplementedInterfaces(ServiceLifetime.Singleton);
            #endregion

            #region Transient Dependency Interface
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.GetInterfaces().Contains(typeof(ITransientDependency)))
                .AsPublicImplementedInterfaces(); // Default is Transient
            #endregion

            #region Register DIs By Name
            services.RegisterAssemblyPublicNonGenericClasses(dataAssembly)
                .Where(c => c.Name.EndsWith("Repository")
                            && !c.GetInterfaces().Contains(typeof(ITransientDependency))
                            && !c.GetInterfaces().Contains(typeof(IScopedDependency))
                            && !c.GetInterfaces().Contains(typeof(ISingletonDependency)))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            services.RegisterAssemblyPublicNonGenericClasses(serviceAssembly)
                .Where(c => c.Name.EndsWith("Service")
                            && !c.GetInterfaces().Contains(typeof(ITransientDependency))
                            && !c.GetInterfaces().Contains(typeof(IScopedDependency))
                            && !c.GetInterfaces().Contains(typeof(ISingletonDependency)))
                .AsPublicImplementedInterfaces();

            #endregion
        }
    }
}
