using StockAnalyzer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockAnalyzer.Windows.Services
{
    public class MockStockService : IStockService
    {
        public Task<IEnumerable<StockPrice>> GetStockPricesFor(string ticker, CancellationToken cancellationToken)
        {
            var stocks = new List<StockPrice>()
            {
                new StockPrice{ Ticker = "MSTF", Change = 0.5m,ChangePercent = 0.75m },
                new StockPrice{ Ticker = "MSTF", Change = 0.2m,ChangePercent = 0.15m },
                new StockPrice{ Ticker = "GOOGL", Change = 0.3m,ChangePercent = 0.27m },
                new StockPrice{ Ticker = "GOOGL", Change = 0.5m,ChangePercent = 0.75m },
            };

            return Task.FromResult(stocks.Where(stock=>stock.Ticker == ticker));
        }
    }
}
