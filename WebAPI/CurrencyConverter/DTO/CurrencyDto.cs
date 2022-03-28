using System;
using System.Collections.Generic;

namespace CurrencyConverter.DTO
{
    public class CurrencyDto
    {
        public string Base { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Dictionary<string, double> Rates { get; set; } = new Dictionary<string, double>();
    }
}