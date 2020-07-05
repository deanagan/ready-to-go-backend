using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;
using FluentAssertions;

namespace Api.Tests
{
    public class CheckListControllerIntegrationShould
    {
        private WebApplicationFactory<Startup> _factory = new WebApplicationFactory<Startup>();

        [Fact]
        public async void ReturnOk_WhenDoingGetAllLists()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var result = await client.GetAsync("/v1/readytogo/api/checklists");

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
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
