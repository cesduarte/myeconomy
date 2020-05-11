using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class ContasAPagarInformation: DespesaFixaInformation
    {

        public int IdContasAPagar { get; set; }
        public DateTime DataVencimentoContasAPagar { get; set; }

        public string NParcelaContasAPagar { get; set; }
        public string StatusContasAPagar { get; set; }
        public int IdContaBancariaPagamentoContasAPagar { get; set; }
        public decimal ValorPagamentoContasAPagar { get; set; }
        public DateTime DataPagamentoContasAPagar { get; set; }
    }
}