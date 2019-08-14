using App2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace App2.Repositorio
{
    public class OperadorJurosRepositorio
    {
        HttpClient jurosApp1 = new HttpClient();

        public OperadorJurosRepositorio()
        {
           jurosApp1.BaseAddress = new Uri("http://localhost:5505/taxajuros");
           jurosApp1.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<double> GetAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1000);

            cancellationToken.ThrowIfCancellationRequested();

            HttpResponseMessage response = await jurosApp1.GetAsync("taxajuros", cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<double>(stringResult);
            }
            return new double();
        }
       

    }
}
