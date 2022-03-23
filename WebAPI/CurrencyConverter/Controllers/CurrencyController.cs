﻿using CurrencyConverter.DTO;
using CurrencyConverter.Helpers.Extentions;
using CurrencyConverter.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CurrencyController> _logger;
        public CurrencyController(IUnitOfWork unitOfWork, ILogger<CurrencyController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Sends CurrencyDto object
        /// </summary>
        /// <returns>CurrencyDto object</returns>
        /// <response code="200">Successfully returned DTO</response>
        /// <response code="400">If the item is null</response>
        [HttpGet("{baseName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CurrencyDto>> GetExchangeRate(string baseName)
        {
            _logger.LogInformation($"Getting CurrencyDto started");

            var models = await _unitOfWork.ExchangeRateRepo
                .FindAsync(x => x.BaseCurrencyName == baseName);

            if (models.Count() < 1)
            {
                _logger.LogInformation($"Getting CurrencyDto finished - no entities have been found");

                return BadRequest($"There are not currencies with base {baseName}");
            }

            var dto = new CurrencyDto();

            if (dto.MapFromExchangeRate(models))
            {
                _logger.LogInformation($"Getting CurrencyDto finished successfully");

                return Ok(dto);
            }

            _logger.LogInformation($"Getting CurrencyDto failed");

            return BadRequest("Unable to map models");
        }
    }
}