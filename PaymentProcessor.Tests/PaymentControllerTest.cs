using System;
using Xunit;
using PaymentProcessor.API.Controllers;
using PaymentProcessor.Domain.DTOs;
using PaymentProcessor.Domain.Services.ProcessPaymentService;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PaymentProcessor.Tests
{
    public class PaymentControllerTest
    {
        private readonly IProcessPaymentService _processPaymentService;
        private readonly ILogger _logger;
        public PaymentControllerTest()
        {
            _processPaymentService = new Mock<IProcessPaymentService>().Object;
            _logger = new Mock<ILogger>().Object;
        }

        [Fact]
        public async Task ProcessPayment_WhenCalledWithInvalidPayload_ReturnBadRequest()
        {
            //Arrange
            var controller = new PaymentController(_processPaymentService, _logger);
            controller.ModelState.AddModelError("Input", "Required");

            //Act
            var response = await controller.ProcessPayment(GetCardInfoDTO()) as BadRequestObjectResult;

            //Assert

            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async Task ProcessPayment_WhenCalledWithInvalidNull_ReturnBadRequest()
        {
            //Arrange
            var controller = new PaymentController(_processPaymentService, _logger);
            controller.ModelState.AddModelError("Input", "Required");

            //Act
            var response = await controller.ProcessPayment(null) as BadRequestObjectResult;

            //Assert

            Assert.Equal(400, response.StatusCode);
        }
        [Fact]
        public async Task ProcessPayment_ReturnType_ToBeAssignableToIActionResult()
        {
            //Arrange
            var controller = new PaymentController(_processPaymentService, _logger);
           

            //Act
            var response = await controller.ProcessPayment(GetCardInfoDTO());


            //Assert

            Assert.IsAssignableFrom<IActionResult>(response);

        }
        [Fact]
        public async Task ProcessPayment_WhenCalledWithValidPayload_ReturnOk()
        {
            //Arrange
            var controller = new PaymentController(_processPaymentService, _logger);
           

            //Act
            var response = await controller.ProcessPayment(GetCardInfoDTO()) as OkObjectResult;

            //Assert

            Assert.Equal(200, response.StatusCode);
        }
        CardInfoDTO GetCardInfoDTO()
        {
            return new CardInfoDTO
            {
                Amount = 20,
                CardHolder = "Name",
                CreditCardNumber = "123456789",
                ExpiryDate = DateTime.Now,
                SecurityCode = "12234"
            };
        }
    }
}
