using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;

using Api.Data.Contexts;
using Api.Services;
using Api.Interfaces;
using Api.Data.Access;
using Api.Controllers;

using Microsoft.EntityFrameworkCore; // Add to invoke UseSqlServer

using Microsoft.Data.Sqlite;

namespace Api.Tests
{
    public class TestStartup : Startup, IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        public TestStartup(IConfiguration configuration)
            :base(configuration)
        {
            _connection = new SqliteConnection(InMemoryConnectionString);

             var webHostBuilder = new WebHostBuilder().UseStartup<TestStartup>();
        }

        public override void ConfigureDBContext(IServiceCollection services)
        {

			var connection = new SqliteConnection(InMemoryConnectionString);
			services
			  .AddEntityFrameworkSqlite()
			  .AddDbContext<ReadyToGoContext>(
				options => options.UseSqlite(connection)
			  );
        }

        public override void EnsureDatabaseCreated(ReadyToGoContext dbContext)
		{
			dbContext.Database.OpenConnection();
			dbContext.Database.EnsureCreated();
		}

        public void Dispose()
        {
            _connection.Close();
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
