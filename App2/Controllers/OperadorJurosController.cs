using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App2.Models;
using App2.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App2.Controllers
{
    [Produces("application/json")]
    [Route("/calculajuros/{valorinicial}/{meses}")]
    public class OperadorJurosController : ControllerBase
    {
        [HttpGet]
        public decimal CalculaJuros(double valorinicial, int meses)
        {
            
            WebApiHelper helper = new WebApiHelper("http://localhost:5505/");
            var data = helper.GetAsync();
            OperadorJuros operadorJuros = new OperadorJuros
            {
                ValorInicial = valorinicial,
                Meses = meses,
                TaxaJuros = Convert.ToDouble(data)
            };
            operadorJuros.ValorFinal = Convert.ToDecimal(Math.Pow(operadorJuros.ValorInicial * (1 + operadorJuros.TaxaJuros), operadorJuros.Meses));

            return operadorJuros.ValorFinal;
        }
    }
}