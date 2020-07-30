using System;
using System.Linq;
using System.Reflection;
using DataAccess.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace EntityServices.Extensions
{
    public static class ReflectionExtensions
    {
        public static void InstallServicesInAssemblies(this IServiceCollection services, AppSettings appSettings)
        {
            var startupProjectAssembly = Assembly.GetCallingAssembly();
            var assemblies = new[] { startupProjectAssembly, Assembly.GetExecutingAssembly() };
            var installers = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(IInstaller).IsAssignableFrom(c))
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            installers.ForEach(i => i.InstallServices(services, appSettings, startupProjectAssembly));
        }
    }
}
