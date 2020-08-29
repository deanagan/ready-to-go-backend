using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using System;


namespace Api.Tests
{
    public class CheckListControllerIntegrationShould : IClassFixture<WebApiTesterFactory>
    {
        private readonly WebApiTesterFactory _factory;
        public HttpClient HttpClient { get; }

        public CheckListControllerIntegrationShould(WebApiTesterFactory factory)
        {
            _factory = factory;
        }

        [Fact(Skip = "Doesn't work at the moment")]
        public async void ReturnOk_WhenDoingGetAllLists()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var result = await client.GetAsync("/v1/readytogo/api/checklists");

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
            }
            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(Skip = "Doesn't work at the moment")]
        public async void ReturnOk_WhenDoingGetList()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var result = await client.GetAsync("/v1/readytogo/api/checklists/1");

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
