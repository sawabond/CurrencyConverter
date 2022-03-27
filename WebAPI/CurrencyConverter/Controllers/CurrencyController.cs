using CurrencyConverter.DTO;
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

        /// <summary>
        /// Removes ExchangeRate
        /// </summary>
        /// <response code="204">Successfully removed ExchangeRate</response>
        /// <response code="400">If the item is null</response>
        [HttpDelete("{baseName}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteExchangeRate(string baseName)
        {
            _logger.LogInformation($"Deleting ExchangeRate started");

            var models = await _unitOfWork.ExchangeRateRepo.GetRangeByNameAsync(baseName);

            if (models.Count() < 1)
            {
                _logger.LogInformation($"Deleting ExchangeRate finished - no entities have been found");

                return BadRequest($"There are not currencies with base {baseName}");
            }

            _unitOfWork.ExchangeRateRepo.RemoveRange(models);
            await _unitOfWork.ConfirmAsync();

            _logger.LogInformation($"Deleting ExchangeRate finished successfully");

            return NoContent();
        }

        /// <summary>
        /// Updates ExchangeRate
        /// </summary>
        /// <response code="204">Successfully updated ExchangeRate</response>
        /// <response code="400">If the item is null</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateExchangeRate([FromBody]UpdateExchangeRateDto updateExchangeRateDto)
        {
            _logger.LogInformation($"Updating ExchangeRate started");

            var model = await _unitOfWork.ExchangeRateRepo.
                GetByNamesAsync(updateExchangeRateDto.BaseCurrencyName, updateExchangeRateDto.CurrencyName);

            if (model == null)
            {
                _logger.LogInformation($"Updating ExchangeRate finished - no entities have been found");

                return BadRequest($"There is not such rate");
            }

            _unitOfWork.ExchangeRateRepo.Update(model.MapFromDto(updateExchangeRateDto));
            await _unitOfWork.ConfirmAsync();

            _logger.LogInformation($"Updating ExchangeRate finished successfully");

            return NoContent();
        }

        /// <summary>
        /// Adds ExchangeRate
        /// </summary>
        /// <returns>addExchangeRateDto object</returns>
        /// <response code="200">Successfully added ExchangeRate</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CurrencyDto>> AddExchangeRate([FromBody]AddExchangeRateDto addExchangeRateDto)
        {
            _logger.LogInformation($"Adding ExchangeRate started");

            var model = addExchangeRateDto.MapExchangeRateDto();

            if (model == null)
            {
                _logger.LogInformation($"Adding ExchangeRate failed");

                return BadRequest("Unable to map dto");
            }

            await _unitOfWork.ExchangeRateRepo.AddAsync(model);
            await _unitOfWork.ConfirmAsync();

            _logger.LogInformation($"Adding ExchangeRate finished successfully");

            return Ok(addExchangeRateDto);
        }
    }
}