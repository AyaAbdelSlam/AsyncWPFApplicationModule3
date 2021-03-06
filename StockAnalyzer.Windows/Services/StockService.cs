﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StockAnalyzer.Core.Domain;

namespace StockAnalyzer.Windows.Services
{
    public class StockService:IStockService
    {
        int i = 0;
        public async Task<IEnumerable<StockPrice>> GetStockPricesFor(string ticker, CancellationToken cancellationToken)
        {
            await Task.Delay((i++)*100);
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync($"http://localhost:61363/api/stocks/{ticker}", cancellationToken);

                result.EnsureSuccessStatusCode();

                var content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(content);
            }
        }
    }
}
