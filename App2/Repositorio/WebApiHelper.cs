using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App2.Repositorio
{
    public class WebApiHelper
    {
        private string url = "";
        HttpClient taxa ;

        public WebApiHelper(string url)
        {
            this.url = url;
            taxa = new HttpClient();
        }

        public double GetAsync()
        {
           Uri uri = new Uri(url);
            taxa.BaseAddress = new Uri(uri.ToString());
            //HttpResponseMessage data = await taxa.GetAsync(url);
            taxa.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = taxa.GetAsync("taxajuros").Result;
             
                var ret = JsonConvert.DeserializeObject<double>(response.Content.ReadAsStringAsync().Result);
            return ret;
        }
    }
}