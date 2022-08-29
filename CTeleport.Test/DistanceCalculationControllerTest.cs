using CTeleport.Api.Controllers;
using CTeleport.Model.ApiResultModel;
using CTeleport.Model.Models;
using CTeleport.Service.Interfaces;
using CTeleport.Test.MockedObjects;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CTeleport.Test
{
    public class DistanceCalculationControllerTest
    {
        private readonly Mock<IDistanceCalculationService> _mockCase;
        private readonly ILogger<DistanceCalculationController> _logger;

        public DistanceCalculationControllerTest()
        {
            _mockCase = new Mock<IDistanceCalculationService>();
            _logger = Mock.Of<ILogger<DistanceCalculationController>>();
        }

        [Fact]
        public async Task Should_get_calculation_response_successfully()
        {
            //Arrange
            var request = new DistanceCalculationRequestModel
            {
                DepartureAirport = "ADB",
                ArrivalAirport = "AMS"
            };

            _mockCase.Setup(x => x.GetDistanceAsync(It.IsAny<DistanceCalculationRequestModel>())).ReturnsAsync(MockedAirportInfoResponse.GetResponseOk);

            var controller = new DistanceCalculationController(_mockCase.Object, _logger);

            //Act
            var result = await controller.Get(request);
            var response = result as OkObjectResult;

            //Assert
            response.StatusCode.Should().Be(200);
            response.Should().NotBeNull();
            response.Value.Should().BeAssignableTo<Result>();
        }

        [Fact]
        public async Task Should_give_error_therefore_injection_error_in_case_()
        {
            //Arrange
            var request = new DistanceCalculationRequestModel
            {
                DepartureAirport = "ADB",
                ArrivalAirport = "AMS"
            };
            var controller = new DistanceCalculationController(null, _logger);

            //Act
            var result = await controller.Get(request);
            var response = result as ObjectResult;

            //Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(500);
        }
    }
}