using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Tascus.Api.Controllers;
using Tascus.Core.Dtos;
using Tascus.Core.Model;
using Tascus.Service.Interfaces;
using Tascus.Service.Services;

namespace Tascus.Test
{
    public class ProductResultsControllerTests
    {
        private readonly Mock<IProductionDataServices> _mockService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ProductResultsController _controller;

        public ProductResultsControllerTests()
        {
            _mockService = new Mock<IProductionDataServices>();
            _mockMapper = new Mock<IMapper>();
            _controller = new ProductResultsController(_mockService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Get_ShouldReturnOk_WhenDataExists()
        {
            // Arrange
            var payload = new Production_Payload(); // Modify this based on its definition
            var returnData = new List<ProductionData>
            {
                new ProductionData
                {
                    // Assuming these are the correct properties, adjust if not.
                    Step_Name = "Work Instruction",
                    Step_Measurement = "Pick Parts Tray",
                    Step_Result = "Complete",
                    Step_Status = "PASS",
                    Operation_Name = "Picking",
                    Operation_ID = 1000,
                    // Add other properties as needed
                }
            };
            _mockService.Setup(x => x.GetProductionData(payload)).ReturnsAsync(returnData);
            var mappedData = new List<ProductionDto> { new ProductionDto() };
            _mockMapper.Setup(x => x.Map<List<ProductionDto>>(returnData)).Returns(mappedData);

            // Act
            var result = await _controller.Get(payload);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_ShouldReturnOk_WhenDataIsValid()
        {
            // Arrange
            var payload = new ProductionDto
            {
                Step_Name = "Test Step Name",
                Step_Measurement = "Test Step Measurement",
                Step_Result = "PASS",
                High_Limit = "Test High Limit",
                Low_Limit = "Test Low Limit",
                Step_Status = "EXECUTING",
                Unit = "Test Unit",
                Step_Run = 0,
                Operation_Name = "Test Operation Name",
                Operation_ID = 1000,
                Date = DateTime.Parse("2023-08-04T13:32:27.472Z")
            };

            var mappedData = new ProductionData(); // Adjust this based on the mapping.
            _mockMapper.Setup(x => x.Map<ProductionData>(payload)).Returns(mappedData);
            _mockService.Setup(x => x.InsertProductionData(mappedData)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Post(payload);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            // Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task Get_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("SomeField", "Some error"); // simulating model state error

            // Act
            var result = await _controller.Get(new Production_Payload());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Get_ShouldReturnBadRequest_WhenServiceThrowsException()
        {
            // Arrange
            _mockService.Setup(x => x.GetProductionData(It.IsAny<Production_Payload>())).ThrowsAsync(new Exception("Some error"));

            // Act
            var result = await _controller.Get(new Production_Payload());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.Equal("Some error", badRequestResult.Value);
        }

        [Fact]
        public async Task Post_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("SomeField", "Some error"); // simulating model state error

            // Act
            var result = await _controller.Post(new ProductionDto());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_ShouldReturnBadRequest_WhenServiceThrowsException()
        {
            // Arrange
            _mockService.Setup(x => x.InsertProductionData(It.IsAny<ProductionData>())).ThrowsAsync(new Exception("Some error"));

            // Act
            var result = await _controller.Post(new ProductionDto());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.Equal("Some error", badRequestResult.Value);
        }

    }
}
