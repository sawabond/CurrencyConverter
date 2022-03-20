using CurrencyConverter.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
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
            var dto = new CurrencyDto();
            return Ok(dto);
        }
    }
}