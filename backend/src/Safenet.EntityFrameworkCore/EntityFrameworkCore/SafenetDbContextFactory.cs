using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Safenet.Configuration;
using Safenet.Web;

namespace Safenet.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SafenetDbContextFactory : IDesignTimeDbContextFactory<SafenetDbContext>
    {
        public SafenetDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SafenetDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SafenetDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SafenetConsts.ConnectionStringName));

            return new SafenetDbContext(builder.Options);
        }
    }
}
