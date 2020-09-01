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
    public class CheckListControllerIntegrationShould : IntegrationTest
    {


        [Fact]
        public async Task ReturnOk_WhenDoingGetAllLists()
        {
            // Arrange

            // Act
            var result = await GetClient().GetAsync("/v1/readytogo/api/checklists");

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
            }
            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async void ReturnOk_WhenDoingGetList()
        {
            // Act
            var result = await GetClient().GetAsync("/v1/readytogo/api/checklists/1");

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
