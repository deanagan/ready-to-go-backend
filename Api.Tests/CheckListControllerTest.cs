using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;
using FluentAssertions;

namespace Api.Tests
{
    public class CheckListControllerShould
    {
        private WebApplicationFactory<Startup> _factory = new WebApplicationFactory<Startup>();

        [Fact]
        public async void ReturnOk_WhenDoingGetAllLists()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var result = await client.GetAsync("/api/checklist/getalllists");

            // Act
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async void ReturnOk_WhenDoingGetList()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var result = await client.GetAsync("/api/checklist/getlist/1");

            // Act
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
