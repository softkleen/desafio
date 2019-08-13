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
        static CancellationTokenSource tokenSource ;
        [HttpGet]
        public decimal CalculaJuros(double valorinicial, int meses)
        {
            OperadorJuros operadorJuros = new OperadorJuros
            {
                ValorInicial = valorinicial,
                Meses = meses
            }; 
            OperadorJurosRepositorio operadorRepositorio = new OperadorJurosRepositorio();
            tokenSource = new CancellationTokenSource();
            Task<double> taxajuros = operadorRepositorio.GetAsync(tokenSource.Token);
            taxajuros.ContinueWith(task =>
            {
                operadorJuros.TaxaJuros = task.Result;
                operadorJuros.ValorFinal = Convert.ToDecimal(Math.Pow(operadorJuros.ValorInicial * (1 + operadorJuros.TaxaJuros), operadorJuros.Meses));
                Environment.Exit(0);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            taxajuros.ContinueWith(
               HandleError,
               TaskContinuationOptions.OnlyOnFaulted);

            taxajuros.ContinueWith(
                HandleCancellation,
                TaskContinuationOptions.OnlyOnCanceled);

            return operadorJuros.ValorFinal;
        }
        private static void HandleError(Task<double> task)
        {
            Console.WriteLine("\n Há um problema na recuperação dos dados");
            Environment.Exit(1);
        }

        private static void HandleCancellation(Task<double> task)
        {
            Console.WriteLine("\n Aoperação foi cancelada");
            Environment.Exit(0);
        }


    }
}