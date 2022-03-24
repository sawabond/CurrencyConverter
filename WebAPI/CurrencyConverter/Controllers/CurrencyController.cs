using CurrencyConverter.DTO;
using CurrencyConverter.Helpers.Extentions;
using CurrencyConverter.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExchangeRate(int id)
        {
            var model = await _unitOfWork.ExchangeRateRepo
                .GetAsync(id);
            if (model == null)
            {
                return BadRequest($"There are not currencies with id {id}");
            }
            _unitOfWork.ExchangeRateRepo.Remove(model);
            await _unitOfWork.ConfirmAsync();
            var dto = new CurrencyDto();

            if (dto.MapFromExchangeRate(model))
            {
                return Ok(dto);
            }
            return BadRequest("Unable to map models");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateExchangeRate(ExchangeRateDto updateExchangeRateDto)
        {
            var model = await _unitOfWork.ExchangeRateRepo
                .GetByNameAsync(updateExchangeRateDto.CurrencyName);
            if (model.CurrencyName != updateExchangeRateDto.CurrencyName)
            {
                return BadRequest($"There are not currencies with name {updateExchangeRateDto.CurrencyName}");
            }

            model.Amount = updateExchangeRateDto.Amount;
            _unitOfWork.ExchangeRateRepo.Update(model);
            await _unitOfWork.ConfirmAsync();
            var dto = new CurrencyDto();

            if (dto.MapFromExchangeRate(model))
            {
                return Ok(dto);
            }
            return BadRequest("Unable to map models");
        }

        [HttpPost]
        public async Task<ActionResult<CurrencyDto>> AddExchangeRate(ExchangeRateDto addExchangeRateDto)
        {
            var model = new ExchangeRate
            {
                CurrencyName = addExchangeRateDto.CurrencyName,
                BaseCurrencyName = addExchangeRateDto.BaseCurrencyName,
                Amount = addExchangeRateDto.Amount
            };

            await _unitOfWork.ExchangeRateRepo.AddAsync(model);
            await _unitOfWork.ConfirmAsync();
            return CreatedAtAction(
                nameof(GetExchangeRate),
                new { BaseCurrencyName = model.BaseCurrencyName },
                model);
        }
    }
}