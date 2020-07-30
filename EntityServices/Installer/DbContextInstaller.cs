using System.Reflection;
using DataAccess.Contracts;
using DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EntityServices.Installer
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, AppSettings settings, Assembly startupProjectAssembly)
        {
            //if (settings.DataBaseProviderType== "SqlServer")
            //{
            // Sql DataBase
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    settings.ConnectionStrings.DocumentModelConnectionString, x => x.UseNetTopologySuite()));
            //}
            //else if (settings.DataBaseProviderType == "MongoDb")
            //{
            //    // MongoDb DataBase
            //}

            // ...
        }
    }
}