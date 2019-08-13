using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App2.Models
{
    public class OperadorJuros
    {
        public double ValorInicial { get; set; }
        public int Meses { get; set; }
        public double TaxaJuros { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
