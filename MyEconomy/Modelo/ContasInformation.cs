using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class ContasInformation:ContasBancariasInformation
    {
        public int IdContas { get; set; }

        public int IdClassificacao { get; set; }
        public string DescriaoContas { get; set; }
        public decimal  ValorContas { get; set; }
        public decimal ValorTotalContas { get; set; }
        public DateTime DataVencimentoContas { get; set; }

        public DateTime DataVencimentoInicialContas { get; set; }
        public DateTime DataVencimentoFinalContas { get; set; }
        public int QuantParcelasContas { get; set; }
        public int QuantParcelasaPagarContas { get; set; }
        public bool Isdelete { get; set; }
    }
}