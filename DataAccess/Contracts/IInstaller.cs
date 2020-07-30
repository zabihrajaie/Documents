using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Contracts
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, AppSettings appSettings, Assembly startupProjectAssembly);
    }
}