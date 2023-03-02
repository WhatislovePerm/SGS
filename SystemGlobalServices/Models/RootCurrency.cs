using System;
namespace SystemGlobalServices.Models
{
    public struct RootCurrency
    {
        public Dictionary<string, Currency> Valute { get; set; }

        public DateTime Date { get; set; }

        public DateTime PreviousDate { get; set; }

        public string PreviousURL { get; set; }

        public string Timestamp { get; set; }

    }
}

