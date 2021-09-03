using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Projeto.AspNet.EntityFrameworkCore
{
    public static class AspNetDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AspNetDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AspNetDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
