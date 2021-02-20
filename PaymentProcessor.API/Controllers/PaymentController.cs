using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentProcessor.Domain.DTOs;
using PaymentProcessor.Domain.Services.ProcessPaymentService;
using Microsoft.Extensions.Logging;

namespace PaymentProcessor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IProcessPaymentService _processPaymentService;
        private readonly ILogger _logger;
        public PaymentController(IProcessPaymentService processPaymentService, ILogger logger)
        {
            _processPaymentService = processPaymentService;
            _logger = logger;
        }

        [HttpPost("process-payment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ProcessPayment(CardInfoDTO cardInfo)
        {
            try
            {
                if (cardInfo == null)
                {
                    _logger.LogError("CardInfo object sent from client is null.");
                    return BadRequest("CardInfo object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var response =  await _processPaymentService.ProcessPayment(cardInfo);
                
                return Ok(response);
                
               

            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside ProcessPayment action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }            
        }
    }
}
