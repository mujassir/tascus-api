using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Tascus.Api.Controllers;
using Tascus.Core.Dtos;
using Tascus.Service.Interfaces;
using Tascus.Service.Services;

namespace Tascus.Test
{
    public class ProductStatusControllerTests
    {
        private ProductStatusController CreateControllerWithMockService(OperationDataService service)
        {
            return new ProductStatusController(service);
        }

        [Fact]
        public async Task Get_ValidPayload_ReturnsOkResult()
        {
            // Arrange
            var payload = new Product_Payload 
            {
                Part_Number = "G090L",
                Serial_Number = "0021116",
                Operation_ID = 1000
            };
            var mockData = new List<ProductStatus_Response>
            {
                new ProductStatus_Response
                {
                    Status = "EXECUTING",
                    Result = "FAIL"
                }
            };

            // Arrange
            var mockService = new Mock<IOperationDataService>();
            mockService.Setup(repo => repo.getOperationData(payload))
                .ReturnsAsync(mockData);
            var controller = new ProductStatusController(mockService.Object);

            // Act
            var result = await controller.Get(payload);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseData = Assert.IsAssignableFrom<List<ProductStatus_Response>>(okResult.Value);
            Assert.Single(responseData); // Ensure that only one item is returned

            var productStatusResponse = responseData[0]; // Get the first item
            Assert.Equal("EXECUTING", productStatusResponse.Status);
            Assert.Equal("FAIL", productStatusResponse.Result);
        }
        [Fact]
        public async Task Get_InvalidPayload_ReturnsBadRequest()
        {
            // Arrange
            var payload = new Product_Payload
            {
                Part_Number = "G090L",
                Serial_Number = "0021116"
            };
            var mockData = new List<ProductStatus_Response>
            {
                new ProductStatus_Response
                {
                    Status = "EXECUTING",
                    Result = "FAIL"
                }
            };

            // Arrange
            var mockService = new Mock<IOperationDataService>();
            mockService.Setup(repo => repo.getOperationData(payload))
                .ThrowsAsync(new Exception("Invalid Operation Id value!"));

            var controller = new ProductStatusController(mockService.Object);

            // Act
            var result = await controller.Get(payload);

            // Assert
            var okResult = Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
