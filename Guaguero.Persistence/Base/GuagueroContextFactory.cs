using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guaguero.Persistence.Base
{
    public class GuagueroContextFactory : IDesignTimeDbContextFactory<GuagueroContext>
    {
        public GuagueroContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<GuagueroContext>();
            var connectionString = configuration.GetConnectionString("DBGuaguero");

            optionsBuilder.UseSqlServer(connectionString);

            return new GuagueroContext(optionsBuilder.Options);
        }
    }
}
