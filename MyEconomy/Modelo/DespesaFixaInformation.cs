using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class DespesaFixaInformation:ContasBancariasInformation
    {
        public int IdDespesaFixa { get; set; }

        public int IdClassificacao { get; set; }
        public string DescriaoDespesaFixa { get; set; }
        public decimal ValorDespesaFixa { get; set; }
        public decimal ValorTotalDespesaFixa { get; set; }
        public DateTime DataVencimentoDespesaFixa { get; set; }

        public DateTime DataVencimentoInicialDespesaFixa { get; set; }
        public DateTime DataVencimentoFinalDespesaFixa { get; set; }
        public int QuantParcelasDespesaFixa { get; set; }
        public int QuantParcelasaPagarDespesaFixa { get; set; }
        public bool Isdelete { get; set; }
    }
}