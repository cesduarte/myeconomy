using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class InvestimentoInformation: ClasseGenericaInformation
    {
        public int IdInvestimento { get; set; }
        public string DescricaoInvestimento { get; set; }
        public decimal SaldoInvestimento { get; set; }
        public DateTime DataInvestimento { get; set; }
        public bool Isdelete { get; set; }
    }
}