using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace my_app_0.API.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<RepositoryContext>().UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("my-app-0.API"));

            return new RepositoryContext(builder.Options);
        }
    }
}
