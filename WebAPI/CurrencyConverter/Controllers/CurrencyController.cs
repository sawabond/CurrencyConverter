using CurrencyConverter.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CurrencyDto>> GetExchangeRate()
        {
            var dto = new CurrencyDto();
            return Ok(dto);
        }
    }
}