
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Xunit;
using FluentAssertions;
using AutoFixture;
using Moq;
using Api.Interfaces;
using Api.Controllers;
using Api.Data.Models;

namespace Api.Tests
{
    public class CheckListControllerShould
    {
        private ICheckListService _checkListService = Mock.Of<ICheckListService>();
        private ILogger<CheckListController> _fakeLogger = Mock.Of<ILogger<CheckListController>>();
        private Fixture _fixture = new Fixture();

        [Fact]
        public void ReturnOk_WhenReturningEmptyList()
        {
            // Arrange
            var controller = new CheckListController(_fakeLogger, _checkListService);
            Mock.Get(_checkListService).Setup(svc => svc.GetCheckLists())
                    .Returns(new List<CheckListView>());

            // Act
            var result = controller.CheckLists() as ObjectResult;

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public void ReturnError_WhenServiceThrowsException()
        {
            // Arrange
            var controller = new CheckListController(_fakeLogger, _checkListService);
            Mock.Get(_checkListService).Setup(svc => svc.GetCheckLists())
                    .Throws(new Exception());

            // Act
            var result = controller.CheckLists() as ObjectResult;

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public void ReturnContentCreated_WhenValidCheckListViewPosted()
        {
            // Arrange
            var controller = new CheckListController(_fakeLogger, _checkListService);
            var checkListView = Mock.Of<CheckListView>(clv =>
                clv.Name == _fixture.Create<string>() &&
                clv.Description == _fixture.Create<string>() &&
                clv.ItemViews == _fixture.Create<List<ItemView>>());

            // Act
            var result = controller.CheckLists(checkListView) as ObjectResult;

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
        }


    }
}
