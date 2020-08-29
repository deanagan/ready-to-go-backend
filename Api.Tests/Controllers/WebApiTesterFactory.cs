using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
// using Api.Tests;
// using Microsoft.NET.Test.Sdk;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Microsoft.AspNetCore.TestHost;

using System.Net.Http;

namespace Api.Tests
{

    public class WebApiTesterFactory : WebApplicationFactory<TestStartup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {

            return WebHost.CreateDefaultBuilder()
                .UseStartup<TestStartup>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
            .ConfigureServices((services) =>
            {
                services.RemoveAll<IHostedService>();
            });
            base.ConfigureWebHost(builder);
        }

    }
}