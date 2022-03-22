using CurrencyConverter.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Model;
using System.Collections.Generic;
using CurrencyConverter.Helpers.Extentions;
using CurrencyConverter.Interfaces;
using System;
using System.Linq;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CurrencyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            var models = _unitOfWork.ExchangeRateRepo
                .Find(x => x.BaseCurrencyName == baseName).ToList();

            if (models.Count() < 1)
            {
                return BadRequest($"There are not currencies with base {baseName}");
            }

            var dto = new CurrencyDto();

            if (dto.MapFromExchangeRate(models))
            {
                return Ok(dto);
            }

            return BadRequest("Unable to map models");
        }
    }
}