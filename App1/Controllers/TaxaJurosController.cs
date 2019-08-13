using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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