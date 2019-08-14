using Microsoft.AspNetCore.Mvc;

namespace App1.Controllers
{
    [Route("/taxajuros")]
    public class TaxaJurosController : Controller
    {
        [HttpGet]
        public double ObterTaxa()
        {
            return 0.01;
        }

    }
}