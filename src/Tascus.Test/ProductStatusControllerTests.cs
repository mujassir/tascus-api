using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tascus.Api.Controllers;
using Tascus.Core.Dtos;
using Tascus.Core.Model;
using Tascus.Service.Interfaces;
namespace Tascus.Test
{
    public class ProductStatusControllerTests
    {
        private Mock<IOperationDataService> _mockService;
        private Mock<IMapper> _mockMapper;
        private ProductStatusController _controller;

        public ProductStatusControllerTests()
        {
            _mockService = new Mock<IOperationDataService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new ProductStatusController(_mockService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Get_ShouldReturnData_WhenPayloadIsValid()
        {
            // Arrange
            var payload = new Production_Payload(); // Initialize accordingly
            var operationDataList = new List<OperationData> { /* Add some mock data */ };
            var operationDtoList = new List<OperationDto> { /* Add some mock data */ };

            _mockService.Setup(x => x.GetOperationData(payload)).ReturnsAsync(operationDataList);
            _mockMapper.Setup(x => x.Map<List<OperationDto>>(operationDataList)).Returns(operationDtoList);

            // Act
            var result = await _controller.Get(payload);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<OperationDto>>(okResult.Value);
            Assert.Equal(operationDtoList, returnValue);
        }

        [Fact]
        public async Task Get_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Error", "Mock ModelState Error");

            // Act
            var result = await _controller.Get(new Production_Payload());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Get_ShouldReturnBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            _mockService.Setup(x => x.GetOperationData(It.IsAny<Production_Payload>())).ThrowsAsync(new Exception("Mock exception message"));

            // Act
            var result = await _controller.Get(new Production_Payload());

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Mock exception message", badRequestResult.Value);
        }

        [Fact]
        public async Task Put_ShouldReturnOk_WhenDataIsValid()
        {
            // Arrange
            var payload = new Operation_Payload { /* Initialize accordingly */ };
            var mappedData = new OperationData();

            _mockMapper.Setup(x => x.Map<OperationData>(payload)).Returns(mappedData);
            _mockService.Setup(x => x.UpdateOperationData(mappedData)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Put(payload);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Put_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Error", "Mock ModelState Error");

            // Act
            var result = await _controller.Put(new Operation_Payload());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Put_ShouldReturnBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var payload = new Operation_Payload { /* Initialize accordingly */ };
            _mockMapper.Setup(x => x.Map<OperationData>(payload)).Returns(new OperationData());
            _mockService.Setup(x => x.UpdateOperationData(It.IsAny<OperationData>())).ThrowsAsync(new Exception("Mock exception message"));

            // Act
            var result = await _controller.Put(payload);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Mock exception message", badRequestResult.Value);
        }
    }
}