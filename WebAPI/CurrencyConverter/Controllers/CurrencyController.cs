using CurrencyConverter.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Model;
using System.Collections.Generic;
using CurrencyConverter.Helpers.Extentions;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        public CurrencyController()
        {

        }

        /// <summary>
        /// Sends CurrencyDto object
        /// </summary>
        /// <returns>CurrencyDto object</returns>
        /// <response code="200">Successfully returned DTO</response>
        /// <response code="400">If the item is null</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CurrencyDto>> GetExchangeRate()
        {

            var models = new List<ExchangeRate>
            {
                new ExchangeRate
                {
                    Id = 1,
                    BaseCurrencyName = "USD",
                    CurrencyName = "RUB",
                    Amount = 666D
                },
                new ExchangeRate
                {
                    Id = 2,
                    BaseCurrencyName = "USD",
                    CurrencyName = "UAH",
                    Amount = 32.64D
                }
            };

            var dto = new CurrencyDto();

            if (dto.MapFromExchangeRate(models))
            {
                return Ok(dto);
            }

            return BadRequest("Unable to map models");
        }
    }
}