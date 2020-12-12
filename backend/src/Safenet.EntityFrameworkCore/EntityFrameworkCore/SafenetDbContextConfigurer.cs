using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Safenet.EntityFrameworkCore
{
    public static class SafenetDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SafenetDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SafenetDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
